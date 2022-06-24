using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTrigger : MonoBehaviour
{
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.mapHp <= 0)
        {
            Time.timeScale=0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        enemy enemy = other.GetComponent<enemy>();
        if (enemy != null)
        {
            GameManager.Instance.mapHp -= enemy.getDamage();
            enemy.destroyItself();
        }
    }
}
