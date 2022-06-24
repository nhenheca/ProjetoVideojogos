using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyTower : MonoBehaviour
{
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = addAmmo();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator addAmmo()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            GameManager.Instance.addMoney(3);
        }
    }
}