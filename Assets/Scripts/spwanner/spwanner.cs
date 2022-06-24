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
        coroutine = startSpawns(round);
        seedData();
    }

    // Update is called once per frame
    void Update()
    {
        skipRound();
        if (hasStarted == true)
        {
            StartCoroutine(coroutine);
            hasStarted = false;
        }
    }

    private void seedData()
    {
        SChild[] round1 = new SChild[] { new SChild(10, enemyType[0], 1.2f, 0f) };
        SChild[] round2 = new SChild[] { new SChild(20, enemyType[0], 1f, 0f) };
        SChild[] round3 = new SChild[] { new SChild(15, enemyType[0], 0.5f, 0f) };
        SChild[] round4 = new SChild[] { new SChild(20, enemyType[0], 0.5f, 0f) };
        SChild[] round5 = new SChild[] { new SChild(25, enemyType[0], 0.3f, 0f) };

        SChild[] round6 = new SChild[] { new SChild(5, enemyType[0], 1f, 0.5f), new SChild(3, enemyType[10], 1f, 0f), new SChild(5, enemyType[0], 1f, 0f) };
        SChild[] round7 = new SChild[] { new SChild(5, enemyType[10], 0.5f, 0.5f), new SChild(5, enemyType[0], 1f, 0f) };
        SChild[] round8 = new SChild[] { new SChild(10, enemyType[0], 0.5f, 0.5f), new SChild(10, enemyType[10], 0.5f, 0f) };
        SChild[] round9 = new SChild[] { new SChild(40, enemyType[0], 0.5f, 0f) };
        SChild[] round10 = new SChild[] { new SChild(10, enemyType[0], 0.5f, 0.5f), new SChild(3, enemyType[3], 1.5f, 2f), new SChild(15, enemyType[0], 0.5f, 0f) };

        SChild[] round11 = new SChild[] { new SChild(5, enemyType[0], 0.5f, 0.5f), new SChild(5, enemyType[3], 1.5f, 2f), new SChild(10, enemyType[0], 0.5f, 0f) };
        SChild[] round12 = new SChild[] { new SChild(5, enemyType[3], 1.5f, 0.5f), new SChild(3, enemyType[10], 0.5f, 2f) };
        SChild[] round13 = new SChild[] { new SChild(5, enemyType[0], 0.5f, 0.5f), new SChild(5, enemyType[3], 1.5f, 2f), new SChild(5, enemyType[10], 0.5f, 0f), new SChild(5, enemyType[0], 0.5f, 0.5f) };
        SChild[] round14 = new SChild[] { new SChild(10, enemyType[3], 1f, 0f) };
        SChild[] round15 = new SChild[] { new SChild(10, enemyType[0], 0.5f, 0.5f), new SChild(15, enemyType[3], 1f, 2f), new SChild(5, enemyType[10], 0.5f, 0f) };

        SChild[] round16 = new SChild[] { new SChild(10, enemyType[0], 0.5f, 0.5f), new SChild(15, enemyType[3], 1f, 2f), new SChild(5, enemyType[10], 0.5f, 0f) };
        SChild[] round17 = new SChild[] { new SChild(20, enemyType[3], 1f, 0.5f) };
        SChild[] round18 = new SChild[] { new SChild(10, enemyType[3], 0.5f, 0.5f), new SChild(20, enemyType[10], 0.5f, 2f), new SChild(10, enemyType[0], 0.5f, 0f) };
        SChild[] round19 = new SChild[] { new SChild(15, enemyType[0], 0.5f, 0.5f), new SChild(10, enemyType[3], 0.5f, 2f) };
        SChild[] round20 = new SChild[] { new SChild(1, enemyType[6], 0.5f, 0.5f) };

        SChild[] round21 = new SChild[] { new SChild(10, enemyType[3], 0.5f, 0.5f), new SChild(5, enemyType[10], 1.5f, 2f), new SChild(10, enemyType[3], 0.5f, 0f) };
        SChild[] round22 = new SChild[] { new SChild(5, enemyType[3], 0.3f, 0.5f), new SChild(3, enemyType[6], 1f, 0f) };
        SChild[] round23 = new SChild[] { new SChild(25, enemyType[10], 0.3f, 0.5f), new SChild(10, enemyType[0], 0.5f, 0f) };
        SChild[] round24 = new SChild[] { new SChild(5, enemyType[6], 1.5f, 0.5f), new SChild(5, enemyType[3], 0.5f, 2f) };
        SChild[] round25 = new SChild[] { new SChild(10, enemyType[6], 1f, 0.5f) };

        SChild[] round26 = new SChild[] { new SChild(15, enemyType[6], 0.5f, 0.5f), new SChild(5, enemyType[9], 0.5f, 0.5f) };
        SChild[] round27 = new SChild[] { new SChild(15, enemyType[6], 0.5f, 0.5f), new SChild(10, enemyType[10], 0.3f, 0.5f), new SChild(10, enemyType[9], 0.5f, 0.5f) };
        SChild[] round28 = new SChild[] { new SChild(10, enemyType[9], 0.5f, 0.5f), new SChild(10, enemyType[10], 0.3f, 0.5f), new SChild(10, enemyType[6], 0.5f, 0.5f) };
        SChild[] round29 = new SChild[] { new SChild(30, enemyType[6], 0.5f, 0.5f), new SChild(10, enemyType[10], 0.3f, 0.5f), new SChild(10, enemyType[9], 0.5f, 0.5f) };
        SChild[] round30 = new SChild[] { new SChild(1, enemyType[11], 0.5f, 0.5f) };

        roundsData = new SChild[][] { round1, round2, round3, round4, round5, round6, round7, round8, round9, round10, round11, round12, round13, round14, round15, round16, round17, round18, round19, round20,
        round21, round22, round23, round24, round25, round26, round27, round28, round29, round30 };
    }

    private IEnumerator startSpawns(int newI)
    {
        for (int i = newI; i < roundsData.Length; i++)
        {
            if (i == roundsData.Length - 1)
            {
                Destroy(GameObject.Find("el_professoro"));
            }

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
