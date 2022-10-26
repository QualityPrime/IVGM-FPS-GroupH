using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalElevator : MonoBehaviour
{
    public GameObject FinalElevatorObj;

    void OnTriggerEnter () {
        FinalElevatorObj.GetComponent<Animation>().Play ("FinalElevator");
    }
}
