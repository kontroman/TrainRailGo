using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Train")
            StartCoroutine(Win());
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(.3f);
        WInLose.Instance.LevelDone();
    }
}
