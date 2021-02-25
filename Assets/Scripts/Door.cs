using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Door : MonoBehaviour
{
    public GameObject doorInteractWindow;
    public Text difficultyText;
    public bool isInRange = false;
    private Lock _lock;
    
    void Start()
    {
        _lock = GetComponent<Lock>();
        
    }
    void Update()
    {
        if (_lock.difficulty == 1)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else if (_lock.difficulty == 2)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }
        else if (_lock.difficulty == 3)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(isInRange)
            {
                _lock.PickLock();
                doorInteractWindow.SetActive(false);
            }   
        }
    }
    void OnTriggerEnter(Collider other)
    {
        #region Lock difficulty text
        if (_lock.difficulty == 1)
        {
            difficultyText.text = "Easy";
        }
        else if (_lock.difficulty == 2)
        {

            difficultyText.text = "Normal";
        }
        else if (_lock.difficulty == 3)
        {
            difficultyText.text = "Hard";
        }
        #endregion

        doorInteractWindow.SetActive(true);
        isInRange = true;
    }
    void OnTriggerExit(Collider other)
    {
        doorInteractWindow.SetActive(false);
        isInRange = false;
    }
}
