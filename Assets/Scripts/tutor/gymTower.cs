using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gymTower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("PLAYER");
        player.GetComponent<Movement>().speed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
