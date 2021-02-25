using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{


    public static Train Instance { get; private set; }
    public int lag;
    private GameObject[] waypoints;
    private int index = 0;
    public float defaultspeed;
    public float speed;
    public float delay;

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;

    }

    private void Update()
    {
        if (lag > 2) speed = 0.75f * speed +  speed;
        else speed = defaultspeed;
        if (delay <= 0)
        {
            UpdateList();
            gameObject.transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
            if (gameObject.transform.position == waypoints[index].transform.position)
            {
                index++;
                lag -=1;
            }

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
