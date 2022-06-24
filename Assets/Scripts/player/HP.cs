using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    private int playerHp;
    // Start is called before the first frame update
    void Start()
    {
        playerHp = GameManager.Instance.getHp();
    }

    // Update is called once per frame
    void Update()
    {
        playerHp = GameManager.Instance.getHp();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            GameManager.Instance.hp -= Random.Range(1, 3);
            Destroy(collision.gameObject);
        }
        
        if (GameManager.Instance.hp <= 0)
        {
            Time.timeScale = 0f;
        }
    }
}
