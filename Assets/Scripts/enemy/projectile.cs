using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private GameObject player;
    public GameObject projectileObject;
    public float launchVelocity = 100000f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PLAYER");
        if(player != null)
            StartCoroutine(tryShoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator tryShoot()
    {
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        if (Random.Range(0, 10) == 1)
        {
            GameObject ball = Instantiate(projectileObject, transform.position, transform.rotation);
            
            Vector3 dir = player.transform.position - transform.position;
            dir = dir.normalized;
            ball.GetComponent<Rigidbody>().AddForce(dir * launchVelocity);
            Destroy(ball, 3f);
        }
        
        StartCoroutine(tryShoot());
    }
}
