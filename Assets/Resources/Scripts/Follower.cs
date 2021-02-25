using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject target;
    public float speed;

    private void Start()
    {
        transform.position = target.transform.position;
    }
    private void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        Quaternion OriginalRot = transform.rotation;
        transform.LookAt(target.transform.position);
        Quaternion NewRot = transform.rotation;
        transform.rotation = OriginalRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, 8 * speed * Time.deltaTime);
    }
}
