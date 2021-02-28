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
    //public int lockAngle; //the position the lockpick needs to be to unlock the lock
    //public float mouseX, mouseY;
    //public float curAngle;
    //public Vector2 _currentMousePosition;
    //public GameObject lockpickCenter;

    //public int lockPickSweetSpot = 15;
    //public int lockPickDiff = 30;
    //public int difficulty;
    //public Door door;
    //private void Awake()
    //{
    //    difficulty = door.difficulty;
    //    if(door.difficulty == 1)
    //    {
    //        lockPickSweetSpot = 50;
    //        lockPickDiff = 75;
    //    }
    //    else if (door.difficulty == 2)
    //    {
    //        lockPickSweetSpot = 25;
    //        lockPickDiff = 50;
    //    }
    //    else if (door.difficulty == 3)
    //    {
    //        lockPickSweetSpot = 15;
    //        lockPickDiff = 30;
    //    }

    //    lockAngle = Random.Range(-360, 360);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    mouseX = Input.mousePosition.x - lockpick.transform.position.x;

    //    mouseX = Mathf.Clamp(mouseX, -360.0f, 360.0f);
        
    //    if(!((int)mouseX <= lockAngle - lockPickSweetSpot || (int)mouseX >= lockAngle + lockPickSweetSpot))
    //    {
    //        if(Input.GetKeyDown(KeyCode.D))
    //        {
    //            door.gameObject.transform.position = new Vector3(0f, -20f, 0f);
    //            door.ExitLockPicking();
    //        }
    //    }
    //}

    //public void SetLock(Door _door)
    //{
    //    door = _door;
    //}
}

