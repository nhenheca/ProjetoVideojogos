using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkBuysTower : MonoBehaviour
{
    private GameObject trigger;
    [SerializeField] GameObject[] towers;
    [SerializeField] GameObject playerPos;
    [SerializeField] GameObject towerUi;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyPistolAmmo()
    {
        if (GameManager.Instance.getMoney() > 49)
        {
            trigger = playerPos.GetComponent<onBuysEnter>().referenceToTrigger;
            Instantiate(towers[0], trigger.transform.position, Quaternion.LookRotation(Vector3.up));

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            towerUi.SetActive(false);

            GameObject triggerParent = trigger.transform.parent.gameObject;
            Destroy(trigger);
            Destroy(triggerParent);

            GameManager.Instance.addMoney(-50);
        }
        
    }

    public void buyShotgunAmmo()
    {
        if (GameManager.Instance.getMoney() > 74)
        {
            trigger = playerPos.GetComponent<onBuysEnter>().referenceToTrigger;
            Instantiate(towers[1], trigger.transform.position, Quaternion.LookRotation(Vector3.up));

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            towerUi.SetActive(false);

            GameObject triggerParent = trigger.transform.parent.gameObject;
            Destroy(trigger);
            Destroy(triggerParent);

            GameManager.Instance.addMoney(-75);
        }
    }

    public void buyBuyRifleAmmo()
    {
        if (GameManager.Instance.getMoney() > 74)
        {
            trigger = playerPos.GetComponent<onBuysEnter>().referenceToTrigger;
            Instantiate(towers[2], trigger.transform.position, Quaternion.LookRotation(Vector3.up));

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            towerUi.SetActive(false);

            GameObject triggerParent = trigger.transform.parent.gameObject;
            Destroy(trigger);
            Destroy(triggerParent);
            
            GameManager.Instance.addMoney(-75);
        }
    }

    public void buyRpgAmmo()
    {
        if (GameManager.Instance.getMoney() > 89)
        {
            trigger = playerPos.GetComponent<onBuysEnter>().referenceToTrigger;
            Instantiate(towers[3], trigger.transform.position, Quaternion.LookRotation(Vector3.up));

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            towerUi.SetActive(false);

            GameObject triggerParent = trigger.transform.parent.gameObject;
            Destroy(trigger);
            Destroy(triggerParent);

            GameManager.Instance.addMoney(-90);
        }
    }

    public void buyLife()
    {
        if (GameManager.Instance.getMoney() > 99)
        {
            trigger = playerPos.GetComponent<onBuysEnter>().referenceToTrigger;
            Instantiate(towers[4], trigger.transform.position, Quaternion.LookRotation(Vector3.up));

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            towerUi.SetActive(false);

            GameObject triggerParent = trigger.transform.parent.gameObject;
            Destroy(trigger);
            Destroy(triggerParent);

            GameManager.Instance.addMoney(-100);
        }
    }

    public void buyMoney()
    {
        if (GameManager.Instance.getMoney() > 99)
        {
            trigger = playerPos.GetComponent<onBuysEnter>().referenceToTrigger;
            Instantiate(towers[5], trigger.transform.position, Quaternion.LookRotation(Vector3.up));

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            towerUi.SetActive(false);

            GameObject triggerParent = trigger.transform.parent.gameObject;
            Destroy(trigger);
            Destroy(triggerParent);

            GameManager.Instance.addMoney(-100);
        }
    }

    public void buyMoveSpeed()
    {
        if (GameManager.Instance.getMoney() > 99)
        {
            trigger = playerPos.GetComponent<onBuysEnter>().referenceToTrigger;
            Instantiate(towers[6], trigger.transform.position, Quaternion.LookRotation(Vector3.down));

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            towerUi.SetActive(false);

            GameObject triggerParent = trigger.transform.parent.gameObject;
            Destroy(trigger);
            Destroy(triggerParent);

            GameManager.Instance.addMoney(-100);
        }
    }

    public void buyShop()
    {
        if (GameManager.Instance.getMoney() > 99)
        {
            trigger = playerPos.GetComponent<onBuysEnter>().referenceToTrigger;
            Instantiate(towers[7], trigger.transform.position, Quaternion.LookRotation(Vector3.up));

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            towerUi.SetActive(false);

            GameObject triggerParent = trigger.transform.parent.gameObject;
            Destroy(trigger);
            Destroy(triggerParent);

            GameManager.Instance.addMoney(-100);
        }
    }

    public void buyGlue()
    {
        if (GameManager.Instance.getMoney() > 99)
        {
            trigger = playerPos.GetComponent<onBuysEnter>().referenceToTrigger;
            Instantiate(towers[8], trigger.transform.position, Quaternion.LookRotation(Vector3.up));

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            towerUi.SetActive(false);

            GameObject triggerParent = trigger.transform.parent.gameObject;
            Destroy(trigger);
            Destroy(triggerParent);

            GameManager.Instance.addMoney(-100);
        }
    }
}
