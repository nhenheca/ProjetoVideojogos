using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkBuys : MonoBehaviour
{
    [SerializeField] private int[] weaponPrices;
    [SerializeField] private int[] ammoPrices;
    [SerializeField] private int[] buffPrices;
    [SerializeField] private bool[] hasBuff;

    private bool isDoubleCashOn = false;

    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("GUNS");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoubleCashOn)
            doublCash();
    }

    public void buyWeapon(int weaponPos)
    {
        int freeMoney = GameManager.Instance.getMoney();
        if(weaponPos == 1)//shotgun
        {
            if(freeMoney >= weaponPrices[weaponPos - 1])
            {
                GameManager.Instance.addMoney(-weaponPrices[weaponPos - 1]);
                GameObject obj = parent.transform.GetChild(weaponPos).gameObject;
                GameManager.Instance.addWeaponToArray(obj);
            }
        }
        else if(weaponPos == 2)//smg
        {
            if (freeMoney >= weaponPrices[weaponPos - 1])
            {
                GameManager.Instance.addMoney(-weaponPrices[weaponPos - 1]);
                GameObject obj = parent.transform.GetChild(weaponPos).gameObject;
                GameManager.Instance.addWeaponToArray(obj);
            }
        }
        else if(weaponPos == 3)//rifle
        {
            if (freeMoney >= weaponPrices[weaponPos - 1])
            {
                GameManager.Instance.addMoney(-weaponPrices[weaponPos - 1]);
                GameObject obj = parent.transform.GetChild(weaponPos).gameObject;
                GameManager.Instance.addWeaponToArray(obj);
            }
        }
        else if(weaponPos == 4)//rpg
        {
            if (freeMoney >= weaponPrices[weaponPos - 1])
            {
                GameManager.Instance.addMoney(-weaponPrices[weaponPos - 1]);
                GameObject obj = parent.transform.GetChild(weaponPos).gameObject;
                GameManager.Instance.addWeaponToArray(obj);
            }
        }
    }

    public void buyAmmo(int ammoPos)
    {
        if (ammoPos == 0)
        {
            GameManager.Instance.ammoPistolSmg += 90;
            GameManager.Instance.addMoney(-ammoPrices[0]);
        }else if(ammoPos == 1)
        {
            GameManager.Instance.ammoShotgun += 30;
            GameManager.Instance.addMoney(-ammoPrices[1]);
        }
        else if (ammoPos == 2)
        {
            GameManager.Instance.ammoRifle += 30;
            GameManager.Instance.addMoney(-ammoPrices[2]);
        }
        else if (ammoPos == 3)
        {
            GameManager.Instance.ammoRpg += 3;
            GameManager.Instance.addMoney(-ammoPrices[3]);
        }
    }
    public void buyBuff(int buffPos)
    {
        if (buffPos == 0 && hasBuff[0]==false)
        {
            StartCoroutine(packAPunch());
            GameManager.Instance.addMoney(-buffPrices[0]);
        }
        else if (buffPos == 1 && hasBuff[1] == false)
        {
            doublCash();
            GameManager.Instance.addMoney(-buffPrices[1]);
        }
        else if (buffPos == 2 && hasBuff[2] == false)
        {
            StartCoroutine(doubleTap());
            GameManager.Instance.addMoney(-buffPrices[2]);

        }
        else if (buffPos == 3 && hasBuff[3] == false)
        {
            StartCoroutine(sanic());
            GameManager.Instance.addMoney(-buffPrices[3]);
        }
        else if (buffPos == 4 && hasBuff[4] == false)
        {
            StartCoroutine(infiniteAmmo());
            GameManager.Instance.addMoney(-buffPrices[4]);
        }
    }

    private IEnumerator packAPunch()
    {
        hasBuff[0] = true;

        foreach (GameObject go in GameManager.Instance.weapons)
        {
            if(go.name != "Placeholder")
            {
                go.GetComponent<raycast>().gunDamage *= 2;
            }
        }
        yield return new WaitForSeconds(15f);

        hasBuff[0] = false;
        foreach (GameObject go in GameManager.Instance.weapons)
        {
            if (go.name != "Placeholder")
            {
                go.GetComponent<raycast>().gunDamage/= 2;
            }
        }
    }

    private IEnumerator doubleTap()
    {
        hasBuff[2] = true;
        GameObject[] go = GameManager.Instance.weapons;

        for (int i = 0; i < go.Length; i++)
        {
            if (go[i].name != "Placeholder")
            {
                go[i].GetComponent<raycast>().fireRate /= 2;
            }
        }

        yield return new WaitForSeconds(30f);
        hasBuff[2] = false;

        for (int i = 0; i < go.Length; i++)
        {
            if (go[i].name != "Placeholder")
            {
                go[i].GetComponent<raycast>().fireRate *= 2;
            }
        }
    }

    private IEnumerator infiniteAmmo()
    {
        hasBuff[4] = true;

        GameObject[] go = GameManager.Instance.weapons;

        for (int i = 0; i < go.Length; i++)
        {
            if (go[i].name != "Placeholder")
            {
                go[i].GetComponent<raycast>().consumeAmmo = false;
            }
        }

        yield return new WaitForSeconds(30f);
        hasBuff[4] = false;

        for (int i = 0; i < go.Length; i++)
        {
            if (go[i].name != "Placeholder")
            {
                go[i].GetComponent<raycast>().consumeAmmo = true;
            }
        }
    }

    private IEnumerator sanic()
    {
        hasBuff[3] = true;
        GameObject player = GameObject.Find("PLAYER");
        player.GetComponent<Movement>().speed *= 2;

        yield return new WaitForSeconds(30f);
        hasBuff[3] = false;
        player.GetComponent<Movement>().speed /= 2;
    }

    private void doublCash()
    {
        hasBuff[1] = true;
        StartCoroutine(StopDoubleCash());
        isDoubleCashOn = true;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in enemies)
        {
            if (go != null)
            {
                if (go.GetComponent<enemy>().value == 1 || go.GetComponent<enemy>().value == 2 || go.GetComponent<enemy>().value == 3)
                {
                    go.GetComponent<enemy>().value *= 2;
                }
            }
        }
    }

    private IEnumerator StopDoubleCash()
    {
        yield return new WaitForSeconds(30f);
        isDoubleCashOn = false;
        hasBuff[1] = false;
    }
}
