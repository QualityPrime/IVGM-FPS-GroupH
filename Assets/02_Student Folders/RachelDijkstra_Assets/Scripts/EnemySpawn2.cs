using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(spawn2());
    }

    IEnumerator spawn2()
    {
        if (enemy1 != null)
        {
            enemy1.SetActive(true);
            yield return new WaitForSeconds(4);
        }
        if (enemy2 != null)
        {
            enemy2.SetActive(true);
            yield return new WaitForSeconds(4);
        }
        if (enemy3 != null)
        {
            enemy3.SetActive(true);
            yield return new WaitForSeconds(4);
        }
    }
}

