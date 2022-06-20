using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billborad : MonoBehaviour
{
    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("MainCamera").transform;
        this.transform.localRotation = Quaternion.Euler(180, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
    }
}
