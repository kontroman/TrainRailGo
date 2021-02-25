using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    private int index = 0;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float delay;

    private void Update()
    {
        if (delay <= 0)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, Waypoint.Instance.WayPoints[index].transform.position, speed * Time.deltaTime);
            if (gameObject.transform.position == Waypoint.Instance.WayPoints[index].transform.position) index++;
            RotateToTarget();
        }
        else delay -= Time.deltaTime;
    }

    private void RotateToTarget()
    {
        Quaternion OriginalRot = transform.rotation;
        transform.LookAt(Waypoint.Instance.WayPoints[index].transform.position);
        Quaternion NewRot = transform.rotation;
        transform.rotation = OriginalRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, 4 * speed * Time.deltaTime);
    }
}
