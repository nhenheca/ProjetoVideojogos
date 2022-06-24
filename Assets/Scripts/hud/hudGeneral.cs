using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hudGeneral : MonoBehaviour
{
    [SerializeField] GameObject[] hud;
    TextMeshProUGUI moneyText;
    TextMeshProUGUI hpText;
    TextMeshProUGUI ammoText;
    TextMeshProUGUI hpmapText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText = hud[0].GetComponent<TextMeshProUGUI>();
        hpText = hud[1].GetComponent<TextMeshProUGUI>();
        ammoText = hud[2].GetComponent<TextMeshProUGUI>();
        hpmapText = hud[3].GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = GameManager.Instance.getMoney().ToString();
        hpText.text = GameManager.Instance.getHp().ToString();
        hpmapText.text = GameManager.Instance.mapHp.ToString();
        updateAmmoHUD();
    }

    private string getCurrentAcitveWeapon()
    {
        string name = "";
        GameObject weapons = GameObject.Find("GUNS");
        int max = weapons.transform.childCount;
        for (int i = 0; i < max; i++)
        {
            if(weapons.transform.GetChild(i).gameObject.active)
                name = weapons.transform.GetChild(i).name;
        }
        return name;
    }

    private void updateAmmoHUD()
    {
        string name = getCurrentAcitveWeapon();
        if (name == "Pistol")
        {
            ammoText.text = GameManager.Instance.ammoPistolSmg.ToString();
        }
        else if(name == "Shotgun")
        {
            ammoText.text = GameManager.Instance.ammoShotgun.ToString();
        }
        else if (name == "Smg")
        {
            ammoText.text = GameManager.Instance.ammoPistolSmg.ToString();
        }
        else if (name == "Rifle")
        {
            ammoText.text = GameManager.Instance.ammoRifle.ToString();
        }
        else
        {
            ammoText.text = GameManager.Instance.ammoRpg.ToString();
        }
    }
}
