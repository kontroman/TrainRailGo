using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigTransparenty : MonoBehaviour
{
    public float speed;

    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;

        Color c = material.color;
        float current = 0;
        c.a = current;
        material.color = c;
    }

    private void Update()
    {
        if (material.color.a < 1f)
        {
            setAlpha();
        }
    }

    void setAlpha()
    {
        Color c = material.color;
        float current = c.a;
        current = Mathf.Min(current + speed * Time.deltaTime, 1.0f);
        c.a = current;
        material.color = c;
    }

}
