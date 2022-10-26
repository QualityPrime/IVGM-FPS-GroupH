using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : MonoBehaviour
{
    public GameObject Player;
    public float x;
    public float y;
    public float z;


    void OnTriggerEnter () {
        Player.transform.position = new Vector3(x, y, z);
    }
}
