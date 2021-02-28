using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * get angle from mouse x and y position
 * generate random number between 1 and 180 for lock angle
 * sweetspot leniency should be able to complete lock when in the range of the lock angle and sweet spot
 * sweet spot diff should show you are getting close to the lock
 * the more difficult the smaller the sweetspot leniency and diff is 
 */

public class Lockpicking : MonoBehaviour
{
    public Lock _lock;
    public int lockAngle; //the position the lockpick needs to be to unlock the lock
    public float mouseX, mouseY;
    public float curAngle;
    public Vector2 _currentMousePosition;
    public GameObject lockpick;

    public int lockPickSweetSpot = 15;
    public int lockPickDiff = 30;

    private void Awake()
    {
        lockPickSweetSpot = 15;
        if(_lock.currentDifficulty == 1)
        {
            lockPickDiff = lockPickSweetSpot * 2;
        }
        else if (_lock.currentDifficulty == 2)
        {
            lockPickSweetSpot /= 2;
            lockPickDiff = lockPickSweetSpot * 2;
        }
        else if (_lock.currentDifficulty == 3)
        {
            lockPickSweetSpot /= 3;
            lockPickDiff = lockPickSweetSpot * 2;
        }

        lockAngle = Random.Range(-360, 360);
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePosition.x - lockpick.transform.position.x;

        mouseX = Mathf.Clamp(mouseX, -360.0f, 360.0f);
        
        if((int)mouseX == lockAngle)
        {
            Debug.Log("Lock picked");
        }
    }
}

