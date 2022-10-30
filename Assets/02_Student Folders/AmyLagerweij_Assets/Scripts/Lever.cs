using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    bool doorOpen = false;

    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            doorOpen = true;
            Debug.Log("Door Opened");
        }
    }
}
