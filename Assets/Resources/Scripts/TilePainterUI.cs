using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilePainterUI : MonoBehaviour
{
    //private GameObject tilePrefab;
    //private List<GameObject> tiles = new List<GameObject>(100);
    //private Vector2 coordinates;
    //private GameObject _canvas;

    private void Start()
    {
        // Init();
    }

    /*public void Init()
    {
        coordinates = new Vector2(100f, 40f);
        tilePrefab = Resources.Load<GameObject>("Prefabs/Tile");
        _canvas = GameObject.FindGameObjectWithTag("Canvas");
        LevelTask.Instance.OnTilesChange += ValueChangedHandler;
        LevelTask.Instance.Init();
    }*/

    /* private void ValueChangedHandler(int newVal)
    {
        DeleteTiles();
        for (int i = 0; i < newVal; i++) CreateNewTile();
    }*/
    
    /*private void CreateNewTile()
    {
        GameObject tile = Instantiate(tilePrefab, coordinates, Quaternion.identity);
        tile.transform.SetParent(_canvas.transform, false);
        tile.GetComponent<Image>().rectTransform.anchorMin = new Vector2(0f, 0f);
        tile.GetComponent<Image>().rectTransform.anchorMax = new Vector2(0f, 0f);
        tile.GetComponent<Image>().rectTransform.pivot = new Vector2(.5f, .5f);
        tiles.Add(tile);
        coordinates.y += 30;
    }*/
    
    /*private void DeleteTiles()
    {
        foreach (GameObject go in tiles) Destroy(go);
        tiles.Clear();
        coordinates = new Vector2(100f, 40f);
    }*/
}
