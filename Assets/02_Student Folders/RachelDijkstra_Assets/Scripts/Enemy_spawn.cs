using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        if(enemy1 != null)
        {
            enemy1.SetActive(true);
            yield return new WaitForSeconds(2);
        }
        if (enemy2 != null)
        {
            enemy2.SetActive(true);
            yield return new WaitForSeconds(2);
        }
        if (enemy3 != null)
        {
            enemy3.SetActive(true);
            yield return new WaitForSeconds(2);
        }
        if (enemy4 != null)
        {
            enemy4.SetActive(true);
            yield return new WaitForSeconds(2);
        }
        if (enemy5 != null)
        {
            enemy5.SetActive(true);
            yield return new WaitForSeconds(2);
        }
    }
}
