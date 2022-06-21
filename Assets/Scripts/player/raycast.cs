using UnityEngine;
using System.Collections;
using System;

public class raycast : MonoBehaviour
{
    [SerializeField]
    private AudioClip shot;
    private AudioSource gunAudio;

    [SerializeField]
    private GameObject impactEffect;
    [SerializeField]
    private ParticleSystem muzzleflash;

    [SerializeField]
    private float explosiveValue;
    [SerializeField]
    private bool isPellet;
    [SerializeField]
    private bool isExplosive;
    [SerializeField]
    private int pierceValue;
    [SerializeField]
    private bool isPierce;
    [SerializeField]
    private int nRays = 1;
    [SerializeField]
    private float spread = 1;
    [SerializeField]
    public int gunDamage = 1;
    [SerializeField]                                                        
    public float fireRate = 0.25f;
    [SerializeField]                                                        
    private float weaponRange = 50f;
    
    private float nextFire;                                     

    private Camera fpsCam;

    // Alterações aqui. Animations já não deve ser usado a não ser para animações Legacy
    // Devemos recorrer ao Animator
    // Fonte: https://forum.unity.com/threads/animationclip-must-be-marked-as-legacy.213952/

    //[SerializeField] private Animation animations;
    private Animator animator;

    private int ammoPistolSmg;
    private int ammoShotgun;
    private int ammoRifle;
    private int ammoRpg;

    public bool consumeAmmo = true;

    void Start()
    {
        // Alterações aqui. Ir buscar o Componente do Animator e não o do Animation
        animator = GetComponent<Animator>();
        //animations = GetComponent<Animation>();

        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
        
        ammoPistolSmg = GameManager.Instance.ammoPistolSmg;
        ammoShotgun = GameManager.Instance.ammoShotgun;
        ammoRifle = GameManager.Instance.ammoRifle;
        ammoRpg = GameManager.Instance.ammoRpg;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Atenção: Há alterações no Animator do Pistol. Teve de ser criado um novo "IdleState" e uma transição do "reload"
            // para esse novo estado, de modo a se poder voltar a fazer o reload após a animação corre a primeira vez.
            // Ver janela do Animator.
            animator.Play("reload");
        }
        // Check if the player has pressed the fire button and if enough time has elapsed since they last fired
        if (Input.GetButton("Fire1") && Time.time > nextFire /*&& ammo>0*/)
        {   
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            Vector3 finalPoint = new Vector3(fpsCam.transform.forward.x + UnityEngine.Random.Range(-spread, spread), fpsCam.transform.forward.y + UnityEngine.Random.Range(-spread, spread), fpsCam.transform.forward.z + UnityEngine.Random.Range(-spread, spread));
            LayerMask mask = LayerMask.GetMask("Enemy");
            Ray ray = new Ray(rayOrigin, finalPoint);

            if (isPierce==false && isExplosive==false && isPellet==false && GameManager.Instance.ammoPistolSmg > 0){
                normalRaycast(ray, mask);
                if(consumeAmmo==true)
                    GameManager.Instance.ammoPistolSmg--;
                gunAudio.PlayOneShot(shot, 0.5f);
            }
            else if(isPellet && GameManager.Instance.ammoShotgun > 0)
            {
                pelletRaycast(ray, mask);
                if (consumeAmmo == true)
                    GameManager.Instance.ammoShotgun--;
                gunAudio.PlayOneShot(shot, 0.5f);
            }
            else if(isPierce && GameManager.Instance.ammoRifle > 0)
            {
                pierceRaycast(ray, mask);
                if (consumeAmmo == true)
                    GameManager.Instance.ammoRifle--;
                gunAudio.PlayOneShot(shot, 0.5f);
            }
            else if (isExplosive && GameManager.Instance.ammoRpg > 0)
            {
                explosiveRaycast(ray, mask);
                if (consumeAmmo == true)
                    GameManager.Instance.ammoRpg--;
                gunAudio.PlayOneShot(shot, 0.5f);
            }  
            
            nextFire = Time.time + fireRate;
        }
    }

    private RaycastHit[] bubbleSort(RaycastHit[] hits)
    {
        int n = hits.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (hits[j].distance > hits[j + 1].distance)
                {
                    // swap temp and arr[i]
                    float temp = hits[j].distance;
                    hits[j] = hits[j + 1];
                    hits[j + 1].distance = temp;
                }

        return hits;
    }
    private void normalRaycast(Ray ray, LayerMask mask)
    {
        muzzleflash.Play();

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, weaponRange, mask))
        {
            enemy enemy = hit.collider.GetComponent<enemy>();

            if (enemy != null && enemy.isResistance==false)
            {
                enemy.doDamage(gunDamage);
            }
        }

        Physics.Raycast(ray, out hit, weaponRange);
        GameObject go = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(go, 1.5f);
    }
    private void pelletRaycast(Ray ray, LayerMask mask)
    {
        Vector3 origin = ray.origin;
        muzzleflash.Play();

        for (int i = 0; i < nRays; i++)
        {
            Vector3 finalPoint = new Vector3(fpsCam.transform.forward.x + UnityEngine.Random.Range(-spread, spread), fpsCam.transform.forward.y + UnityEngine.Random.Range(-spread, spread), fpsCam.transform.forward.z + UnityEngine.Random.Range(-spread, spread));
            Ray newRay = new Ray(origin, finalPoint);
            RaycastHit hit;
            if (Physics.Raycast(newRay, out hit, weaponRange, mask))
            {
                enemy enemy = hit.collider.GetComponent<enemy>();

                if (enemy != null && enemy.isResistance == false)
                {
                    enemy.doDamage(gunDamage);
                }
            }

            Physics.Raycast(newRay, out hit, weaponRange);
            GameObject go = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(go, 1.5f);
        }
    }
    private void pierceRaycast(Ray ray, LayerMask mask)
    {
        muzzleflash.Play();

        RaycastHit[] hits = Physics.RaycastAll(ray, weaponRange, mask);
        hits = bubbleSort(hits);

        if (hits.Length != 0)
        {
            for (int j = 0; j < hits.Length; j++)
            {
                if (j < pierceValue)
                {
                    GameObject go = Instantiate(impactEffect, hits[j].point, Quaternion.LookRotation(hits[j].normal));
                    Destroy(go, 1.5f);

                    enemy enemy = hits[j].collider.GetComponent<enemy>();

                    if (enemy != null && enemy.isResistance == false)
                    {
                        enemy.doDamage(gunDamage);
                    }
                }
                else
                {
                    break;
                }
            }
        }   
    }
    private void explosiveRaycast(Ray ray, LayerMask mask)
    {
        float x = (-gunDamage)/explosiveValue;
        
        muzzleflash.Play();

        RaycastHit hit;
        Physics.Raycast(ray, out hit, weaponRange);
        Vector3 centerOfExplosion = hit.point;

        RaycastHit[] hits = Physics.SphereCastAll(ray, explosiveValue, weaponRange, mask);

        if (hits.Length != 0)
        {
            for (int j = 0; j < hits.Length; j++)
            {
                enemy enemy = hits[j].collider.GetComponent<enemy>();

                if (enemy != null)
                {                  
                    Vector3 centerOfEnemy = hits[j].point;
                    float distance = System.Math.Abs(Vector3.Distance(centerOfExplosion, centerOfEnemy));

                    float damageToAplly = System.Math.Abs(distance * x+gunDamage);
                    int finalDamage = (int)Math.Ceiling(damageToAplly);

                    enemy.doDamage(+finalDamage);
                }
            }
        }

        GameObject go = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(go, 1.5f);
    }
}