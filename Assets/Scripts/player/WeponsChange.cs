using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponsChange : MonoBehaviour
{
    private GameObject[] weapons;
    private int currentWeapon=0;
    // Start is called before the first frame update
    void Start()
    {
        weapons = GameManager.Instance.getArrayOfWeapons();
        weapons[currentWeapon].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if(currentWeapon-1 < 0)
            {
                currentWeapon = 0;
            }else if(weapons[currentWeapon-1] != null)
            {
                currentWeapon--;
                weapons[currentWeapon + 1].SetActive(false);
                weapons[currentWeapon].SetActive(true);
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (currentWeapon + 1 >= weapons.Length)
            {
                currentWeapon = weapons.Length-1;
            }
            else if (weapons[currentWeapon + 1] != null)
            {
                currentWeapon++;
                weapons[currentWeapon - 1].SetActive(false);
                weapons[currentWeapon].SetActive(true);
            }
        }
    }
}
