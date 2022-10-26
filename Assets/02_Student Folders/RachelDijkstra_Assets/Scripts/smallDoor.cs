using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallDoor : MonoBehaviour
{
    Animator anim;
    bool opened;

    void Awake()
    {
        anim = GetComponent<Animator>();
        DebugUtility.HandleErrorIfNullGetComponent<Animator, smallDoor>(anim, this, gameObject);
        opened = false;
    }

    private void OnTriggerEnter()
    {
        if (!opened)
        {
            StartCoroutine(OpenAndCloseDoor());
        }
    }

    IEnumerator OpenAndCloseDoor()
    {
        anim.SetTrigger("Open");
        opened = true;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);

        //After we have waited 5 seconds print the time again.
        anim.SetTrigger("Close");
        opened = false;
    }
}
