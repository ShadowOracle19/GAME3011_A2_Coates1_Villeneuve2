using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public GameObject LockpickingWindow;
    public int difficulty; //1(Easy), 2(Normal), 3(Hard)
    bool isLockpickingWindowActive = false;
    
    public Text lockpickLevelText;

    public PlayerBehaviour playerBehaviour;
    public CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (isLockpickingWindowActive)
                ExitLockPicking();
        }
        lockpickLevelText.text = playerBehaviour.lockpickLevel.ToString();
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
