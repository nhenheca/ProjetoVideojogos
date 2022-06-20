using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] childs;
    [SerializeField] public int value;
    [SerializeField] private int damage;
    [SerializeField] private float painTrigger;
    private bool painTriggerState = false;
    [SerializeField] private int hp;
    private bool hasPaid;

    [SerializeField] private Sprite[] sprites;
    private NavMeshAgent agent;
    private SpriteRenderer spriteRenderer;
    private WaitForSeconds painDuration = new WaitForSeconds(0.2f);

    private AudioSource enemyAudio;
    [SerializeField] private AudioClip hurt;
    [SerializeField] private AudioClip death;

    private path pathReference;

    [SerializeField] public bool isResistance;

    [SerializeField] public bool isElProfessoro;

    // Start is called before the first frame update
    void Start()
    {
        pathReference = GetComponent<path>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        painTrigger = hp * painTrigger;
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void doDamage(int damage)
    {
        hp = hp - damage;
        
        if(!isElProfessoro)
            StartCoroutine(painReaction());

        if(Random.Range(0, 2) >= 1)
        {
            enemyAudio.PlayOneShot(hurt, 0.1f);
        }

        if (hp <= 0 && hasPaid==false)
        {
            hasPaid = true;
            AudioSource.PlayClipAtPoint(death, this.transform.position, 0.10f);
            GameManager.Instance.addMoney(value);
            if (childs.Length != 0)
            {
                GameObject childAux = Instantiate(childs[Random.Range(0,3)], this.transform.position, Quaternion.identity);
                path path = childAux.GetComponent<path>();
                path.destPoint = pathReference.destPoint;
            }
            Destroy(gameObject); 
        }
        
        if(hp <= painTrigger && painTriggerState==false)
        {
            painTriggerState = true;
            spriteRenderer.sprite = sprites[1];
            agent.speed = agent.speed * 2;
        }
    }
    private IEnumerator painReaction()
    {
        spriteRenderer.sprite = sprites[1];        
        yield return painDuration;
        spriteRenderer.sprite = sprites[0];
        if(painTriggerState)
            spriteRenderer.sprite = sprites[1];
    }
    public int getDamage()
    {
        return damage;
    }
    public void destroyItself()
    {
        Destroy(this.gameObject);
    }
}
