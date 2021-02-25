using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Train")
        {
            LevelTask.Instance.CurrentPassangers++;
            Destroy(gameObject);
        }
    }
}
