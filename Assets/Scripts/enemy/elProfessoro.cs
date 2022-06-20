using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elProfessoro : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    private path pathReference;

    // Start is called before the first frame update
    void Start()
    {
        pathReference = GetComponent<path>();
        StartCoroutine(spwanEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private IEnumerator spwanEnemies()
    {
        for(int i=0; i<Random.Range(3, 6); i++)
        {
            GameObject childAux =Instantiate(enemies[Random.Range(0, 11)], this.transform.position, Quaternion.identity);
            path path = childAux.GetComponent<path>();
            path.destPoint = pathReference.destPoint;
            yield return new WaitForSeconds(0.75f);
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine(spwanEnemies());
    }
}
