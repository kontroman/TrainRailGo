using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileButtons : MonoBehaviour
{

    [SerializeField] UnityEvent anEvent;
    public string direction;
    public Vector3 _rotation;
    private GameObject[] Buttons;

    private void Start()
    {
        Buttons = GameObject.FindGameObjectsWithTag("Button");
    }
    private void Update()
    {
        //gameObject.transform.rotation = Quaternion.Euler(_rotation.x, _rotation.y, _rotation.z);
    }

    private void OnMouseDown()
    {
        anEvent.Invoke();
    }

    public void EventClick()
    {
        if (BuildManager.Instance.allowed)
        {
            // LevelTask.Instance.CurrentTiles -= 1;
            Train.Instance.lag++;
            BuildManager.Instance.BuildNewRoad(direction, gameObject.transform.rotation);
            RotateButtons();
        }
    }

    private void RotateButtons()
    {
        foreach(GameObject _tile in Buttons)
        {
            switch (direction)
            {
                case "Right":
                    _tile.transform.Rotate(new Vector3(0f, 60f, 0f), Space.World);
                    break;                
                case "Forward":
                    break;                
                case "Left":
                    _tile.transform.Rotate(new Vector3(0f, -60f, 0f), Space.World);
                    break;
            }
        }
    }
}
