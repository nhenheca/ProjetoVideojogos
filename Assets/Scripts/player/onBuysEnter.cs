using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBuysEnter : MonoBehaviour
{
    public GameObject referenceToTrigger;
    [SerializeField] GameObject tutorUi;
    [SerializeField] GameObject towerUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        referenceToTrigger = other.gameObject;
        if (other.gameObject.tag == "Tutor")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tutorUi.SetActive(true);
        }
        if (other.gameObject.tag == "Tower")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            towerUi.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tutor")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            tutorUi.SetActive(false);
        }
        if (other.gameObject.tag == "Tower")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            towerUi.SetActive(false);
        }
    }
}
