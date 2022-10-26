using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapOpen : MonoBehaviour
{
    public GameObject TrapDoor;

    void OnTriggerEnter () {
        TrapDoor.GetComponent<Animation> ().Play ("TrapAnim");
        
    }
}
