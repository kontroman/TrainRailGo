﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance { get; private set; }

    [SerializeField]
    private GameObject currentTile;
    [SerializeField]
    private GameObject currentSelectionRed;

    private GameObject leftTile;
    private GameObject forwardTile;
    private GameObject rightTile;

    private GameObject DigSite;
    private GameObject SelectionRed;
    private GameObject cachedTile;
    [SerializeField]
    private GameObject defaultTile;

    public bool allowed = true;
    private bool last = false;
    public bool LastTile = false;
    private GameObject road;

    public GameObject CachedTile
    {
        get { return cachedTile; }
        set { cachedTile = value; }
    }

    private Vector3 coordinates;

    private void Awake()
    {
        if (Instance != null) return;
        else
            Instance = this;
        Init();
    }

    public void Init()
    {
        DigSite =       Resources.Load <GameObject> ("Prefabs/DigSite");
        SelectionRed =  Resources.Load <GameObject> ("Prefabs/SelectionRed");
        leftTile =      Resources.Load <GameObject> ("Prefabs/RoadLeft");
        rightTile =     Resources.Load <GameObject> ("Prefabs/RoadRight");
        forwardTile =   Resources.Load <GameObject> ("Prefabs/RoadStraight");
    }

    public void BuildNewRoad(string type, Quaternion rotation)
    {
        if (!last)
        {
            CheckCachedTile();

            switch (type)
            {
                case "Left":
                    road = Instantiate(leftTile, currentTile.transform.position, rotation);
                    break;
                case "Forward":
                    road = Instantiate(forwardTile, currentTile.transform.position, rotation);
                    break;
                case "Right":
                    road = Instantiate(rightTile, currentTile.transform.position, rotation);
                    break;
            }

            allowed = false;
            if (LastTile) last = true;
            StartCoroutine(waiter());

        }
    }

    private void CheckCachedTile()
    {
        if (cachedTile == null)
        {
            Destroy(currentTile);
            Destroy(currentSelectionRed);
            currentTile = Instantiate(defaultTile, DigSite.transform.position, Quaternion.identity);
        }
        else
        {
            cachedTile.SetActive(true);
            Destroy(currentTile);
            Destroy(currentSelectionRed);
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(.3f);
        AssignNewDigAndSelection(cachedTile.transform, cachedTile.transform);
        yield return new WaitForSeconds(0.7f);
        allowed = true;
    }
    public void AssignNewDigAndSelection(Transform _dig, Transform _selection)
    {
        if (!last)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/DustStorm"), _dig.transform.position, Quaternion.Euler(new Vector3(-180f, 0f, -90f)));
            currentTile = Instantiate(DigSite, _dig.position, Quaternion.identity);
            currentSelectionRed = Instantiate(SelectionRed, _selection.position, Quaternion.identity);
            cachedTile.SetActive(false);
        }
    }

}
