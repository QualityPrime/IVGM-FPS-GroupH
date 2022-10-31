using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] 
    Transform tp;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = tp.transform.position;
    }
}
