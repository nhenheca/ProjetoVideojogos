using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBuysEnter : MonoBehaviour
{
    [SerializeField] GameObject tutorUi;
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
        if (other.gameObject.tag == "Tutor")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tutorUi.SetActive(true);
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
    }
}
