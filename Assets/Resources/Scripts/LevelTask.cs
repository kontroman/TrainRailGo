using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTask : MonoBehaviour
{
    public static LevelTask Instance { get; private set; }

    private List<GameObject> passangers;


    private int maxPassangersOnLevel;
    [SerializeField]
    public int passFor3stars;    
    [SerializeField]
    public int passFor2stars;    
    [SerializeField]
    public int passFor1stars;


    private int currentPassangersInTrain;

    [SerializeField]
    private int maxTiles;
    private int currentTiles;

    public event OnVariableChangeDelegate OnPassangersChange;
    public event OnVariableChangeDelegate OnTilesChange;
    public delegate void OnVariableChangeDelegate(int _newVal);

    public int CurrentTiles
    {
        get { return currentTiles; }
        set
        {
            if (currentTiles == value) return;
            currentTiles = value;
            if (OnTilesChange != null) OnTilesChange(currentTiles);
        }
    }
    public int CurrentPassangers
    {
        get { return currentPassangersInTrain; }
        set
        {
            if (currentPassangersInTrain == value) return;
            currentPassangersInTrain = value;
            if (OnPassangersChange != null) OnPassangersChange(currentPassangersInTrain);
        }
    }
    public int MaxPassangers
    {
        get { return maxPassangersOnLevel; }
        private set { maxPassangersOnLevel = value; }
    }

    private void Awake()
    {
        if (Instance != null)
            return;
        else
            Instance = this;
        Init();
    }
    public void Init()
    {
        CollectAllPassangers();
        MaxPassangers = passangers.Count;
        CurrentPassangers = 0;
        StartCoroutine(Tiles());
    }
    private void CollectAllPassangers()
    {
        passangers = new List<GameObject>(GameObject.FindGameObjectsWithTag("Passanger"));
    }

    IEnumerator Tiles()
    {
        yield return new WaitForSeconds(.2f);
        CurrentTiles = maxTiles;
    }
}
