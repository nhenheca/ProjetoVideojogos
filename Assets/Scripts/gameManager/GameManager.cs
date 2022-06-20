using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private int money;

    public int ammoPistolSmg;
    public int ammoShotgun;
    public int ammoRifle;
    public int ammoRpg;

    [SerializeField] public GameObject[] weapons;

    private int currentWepaon = 1;
    
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public int getMoney()
    {
        return money;
    }
    public void setMoney(int money)
    {
        this.money = money;
    }
    public void addMoney(int money)
    {
        this.money += money;
    }

    public GameObject[] getArrayOfWeapons()
    {
        return weapons;
    }

    public void addWeaponToArray(GameObject weapon)
    {
        weapons[currentWepaon] = weapon;
        currentWepaon++;
    }
}
