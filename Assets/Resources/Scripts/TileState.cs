using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Block,
    Roadable,
    Road,
    Station
};

public class TileState : MonoBehaviour
{
    public State State;

    private void Start()
    {

    }
}
