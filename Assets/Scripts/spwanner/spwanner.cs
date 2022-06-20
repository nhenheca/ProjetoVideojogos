using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class spwanner : MonoBehaviour
{
    [SerializeField]
    private bool hasStarted = false;
    private bool skipwaitTime = false;
    [SerializeField]
    private int timeBetweenRounds;
    [SerializeField]
    private GameObject[] enemyType;

    SChild[][] roundsData;

    private IEnumerator coroutine;

    private int round =0;

    // Start is called before the first frame update
    void Start()
    {
        //coroutine = startSpawns(round);
        //seedData();
    }

    // Update is called once per frame
    void Update()
    {
        /*skipRound();
        if (hasStarted == true)
        {
            StartCoroutine(coroutine);
            hasStarted = false;
        }*/
    }

    private void seedData()
    {
        SChild[] round1 = new SChild[] { new SChild(20, enemyType[0], 1f, 0f) };
        SChild[] round2 = new SChild[] { new SChild(35, enemyType[0], 0.5f, 0f) };
        SChild[] round3 = new SChild[] { new SChild(10, enemyType[0], 0.5f, 0.5f), new SChild(5, enemyType[1], 0.5f, 2f), new SChild(15, enemyType[0], 0.5f, 0.5f) };
        
        roundsData = new SChild[][] { round1, round2, round3 };  
    }

    private IEnumerator startSpawns(int newI)
    {
        for (int i = newI; i < roundsData.Length; i++)
        {
            round = i;
            SChild[] auxArray = roundsData[i];
            for (int j=0; j < roundsData[i].Length; j++)
            {
                SChild aux = auxArray[j];
                for (int k=0; k < aux.number; k++)
                {     
                    Instantiate(aux.type, this.transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(aux.space);
                }
                yield return new WaitForSeconds(aux.spaceEnemy);
            }
            skipwaitTime = true;
            yield return new WaitForSeconds(timeBetweenRounds);
        }
    }

    private void skipRound()
    {
        if (Input.GetButton("Fire2") && skipwaitTime == true)
        {
            skipwaitTime = false;
            StopCoroutine(coroutine);
            coroutine = startSpawns(round+1);
            StartCoroutine(coroutine);    
        }
    }
    
    public class SChild
    {
        public int number;
        public GameObject type;
        public float space;
        public float spaceEnemy;

        public SChild(int number, GameObject type, float space, float spaceEnemy)
        {
            this.number = number;
            this.type = type;
            this.space = space;
            this.spaceEnemy = spaceEnemy;
        }
    }
}
