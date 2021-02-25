using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{

    private GameObject[] waypoints;
    private int index = 0;
    public float speed;
    public float delay;

    private void Update()
    {
        if (delay <= 0)
        {
            UpdateList();
            gameObject.transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
            if (gameObject.transform.position == waypoints[index].transform.position) index++;

            Quaternion OriginalRot = transform.rotation;
            transform.LookAt(waypoints[index].transform.position);
            Quaternion NewRot = transform.rotation;
            transform.rotation = OriginalRot;
            transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, 4 * speed * Time.deltaTime);
        }
        else
            delay -= Time.deltaTime;
    }

    private void UpdateList()
    {
        waypoints = GameObject.FindGameObjectsWithTag("wp");
    }
}
