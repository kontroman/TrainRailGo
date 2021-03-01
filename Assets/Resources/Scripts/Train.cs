using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public static Train Instance { get; private set; }

    public float tileDistance;
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
        if (tileDistance > 3 && speed == defaultspeed) speed = 2f * speed;
        else speed = defaultspeed;

        if (delay <= 0)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, Waypoint.Instance.WayPoints[index].position, speed * Time.deltaTime);
            if (gameObject.transform.position == Waypoint.Instance.WayPoints[index].position)
            {
                index++;
                if (index == Waypoint.Instance.WayPoints.Count) WInLose.Instance.GameOver();
                if(tileDistance > 0) tileDistance -= .5f;
            }
            RotateToTarget();
        }
        else
            delay -= Time.deltaTime;
    }

    private void RotateToTarget()
    {
        Quaternion OriginalRot = transform.rotation;
        transform.LookAt(Waypoint.Instance.WayPoints[index].position);
        Quaternion NewRot = transform.rotation;
        transform.rotation = OriginalRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, 4 * speed * Time.deltaTime);
    }
}
