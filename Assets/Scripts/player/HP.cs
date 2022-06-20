using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private int playerHp = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            playerHp = playerHp - Random.Range(1, 3);
            Destroy(collision.gameObject);
        }
        
        if (playerHp <= 0)
        {
            Time.timeScale = 0f;
        }
    }
}
