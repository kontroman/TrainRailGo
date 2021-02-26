using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelecter : MonoBehaviour
{
    private void Start()
    {
        Waypoint.Instance.AddPoint(transform.Find("1"));
        Waypoint.Instance.AddPoint(transform.Find("2"));
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<TileState>().State == State.Station)
        {
            BuildManager.Instance.CachedTile = other.gameObject;
            gameObject.GetComponent<TileSelecter>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            BuildManager.Instance.LastTile = true;
        }
        if (other.gameObject.GetComponent<TileState>().State == State.Roadable)
        {
            BuildManager.Instance.CachedTile = other.gameObject;
            gameObject.GetComponent<TileSelecter>().enabled = false;
            other.gameObject.GetComponent<TileState>().State = State.Road;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.gameObject.GetComponent<TileState>().State == State.Block
            || other.gameObject.GetComponent<TileState>().State == State.Road)
            WInLose.Instance.GameOver();
    }
}
