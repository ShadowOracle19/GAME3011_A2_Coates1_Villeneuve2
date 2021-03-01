using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Door : MonoBehaviour
{
    [Header("Door Variables")]
    public GameObject doorInteractWindow;
    public Text difficultyText;
    public bool isInRange = false;
    public PlayerBehaviour playerBehaviour;
    public CameraController cameraController;

    [Header("Lock variables")]
    public GameObject LockpickingWindow;
    public int difficulty; //1(Easy), 2(Normal), 3(Hard)
    public bool isLockpickingWindowActive = false;
    public Text lockpickLevelText;

    [Header("Lockpick Variables")]
    public int lockPickSweetSpot = 15;
    public int lockPickDiff = 30;
    public int lockAngle; //the position the lockpick needs to be to unlock the lock
    public float mouseX;
    public GameObject lockpickCenter;
    public GameObject lockpick;


    public Text timerText;
    public float timer;

    [SerializeField]
    private int attempts;

    public AudioClip picking;
    AudioSource audioSource;

    void Start()
    {
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        cameraController = FindObjectOfType<CameraController>();
        audioSource = GetComponent<AudioSource>();
        lockAngle = Random.Range(-180, 180);
        //difficulty = Random.Range(1, 4); //uncomment to make door difficulty random
        
        #region sets door difficulty sweet spot
        if (difficulty == 1)//easy
        {
            lockPickSweetSpot = 25;
            lockPickDiff = 50;
            
        }
        else if (difficulty == 2)//normal
        {
            lockPickSweetSpot = 15;
            lockPickDiff = 30;

        }
        else if (difficulty >= 3)//hard
        {
            lockPickSweetSpot = 10;
            lockPickDiff = 25;
            attempts = 6;

        }
        #endregion
    }
    void Update()
    {
        lockpickLevelText.text = playerBehaviour.lockpickLevel.ToString();


        #region difficulty colors
        if (difficulty == 1)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else if (difficulty == 2)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }
        else if (difficulty == 3)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(isInRange)
            {
                switch (difficulty)
                {
                    case 1:
                        timer = 60;
                        attempts = 10;

                        break;
                    case 2:
                        timer = 30;
                        attempts = 8;

                        break;
                    case 3:
                        timer = 20;
                        attempts = 6;

                        break;
                }
                PickLock();
                doorInteractWindow.SetActive(false);

            }
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isLockpickingWindowActive)
                ExitLockPicking();
        }

        if(isLockpickingWindowActive)
        {
            isLockpickingWindowActive = true;
            mouseX = Input.mousePosition.x - lockpickCenter.transform.position.x;

            mouseX = Mathf.Clamp(mouseX, -180.0f, 180.0f);

            lockpickCenter.transform.localRotation = Quaternion.Euler(0f, 0f, -mouseX);


            timer -= Time.deltaTime;

            string minutes = ((int)timer / 60).ToString();
            string seconds = (timer % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;

            if(timer <= 0)
            {
                Debug.Log("You didn't make it in time!");
                ExitLockPicking();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (Mathf.Abs(lockAngle - mouseX) <= (lockPickSweetSpot * 1 + ((playerBehaviour.lockpickLevel - 1) / 10)))
                {
                
                    gameObject.transform.position = new Vector3(0f, -20f, 0f);
                    playerBehaviour.lockpickLevel++;
                    ExitLockPicking();
                    return;
                    
                }
                else if (Mathf.Abs(lockAngle - mouseX) <= lockPickDiff)
                {
                    Debug.Log("you are close");
                    attempts--;
                    audioSource.PlayOneShot(picking, 0.7f);
                }
                else
                {
                    attempts--;
                }

                if(attempts <= 0)
                {
                    ExitLockPicking();
                    Debug.Log("Your lockpick broke!");
                }
            }
            
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        #region Lock difficulty text
        if (difficulty == 1)
        {
            difficultyText.text = "Easy";
        }
        else if (difficulty == 2)
        {

            difficultyText.text = "Normal";
        }
        else if (difficulty == 3)
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

    public void PickLock()
    {
        Cursor.lockState = CursorLockMode.None;
        playerBehaviour.enabled = false;
        cameraController.enabled = false;
        LockpickingWindow.SetActive(true);
        isLockpickingWindowActive = true;
    }

    public void ExitLockPicking()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBehaviour.enabled = true;
        cameraController.enabled = true;
        LockpickingWindow.SetActive(false);
        isLockpickingWindowActive = false;
    }
}
