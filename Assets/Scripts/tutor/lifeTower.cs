using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeTower : MonoBehaviour
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
            yield return new WaitForSeconds(15);
            GameManager.Instance.hp += 1;
        }
    }
}