using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopTower : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        weapons[0].GetComponent<raycast>().fireRate = 0.20f;
        weapons[1].GetComponent<raycast>().fireRate = 0.7f;
        weapons[2].GetComponent<raycast>().fireRate = 0.11f;
        weapons[3].GetComponent<raycast>().fireRate = 0.23f;
        weapons[4].GetComponent<raycast>().fireRate = 0.9f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
