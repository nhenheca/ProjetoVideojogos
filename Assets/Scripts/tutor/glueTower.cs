using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class glueTower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits = Physics.BoxCastAll(this.transform.position, new Vector3(5,5,5), new Vector3(0,1,0), Quaternion.identity);

        if (hits.Length != 0)
        {
            for (int j = 0; j < hits.Length; j++)
            {
                NavMeshAgent enemy = hits[j].collider.GetComponent<NavMeshAgent>();

                if (enemy != null)
                {
                    if(enemy.speed>=2.7f)
                        enemy.speed *= 0.5f;
                }
            }
        }
    }
}
