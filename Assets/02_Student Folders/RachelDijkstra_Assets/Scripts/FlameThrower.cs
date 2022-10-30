using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public float secsToNext = 2.0f;
    bool activated;
    public GameObject flames;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        secsToNext -= Time.deltaTime; 
            if(secsToNext <= 0)
            {
                secsToNext = 2.0f;
                if (activated)
                { 
                    flames.SetActive(false);
                    activated = false;
                }
                else{ 
                    flames.SetActive(true);
                    activated = true;
                }
            }
    }
}
