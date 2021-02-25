using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WInLose : MonoBehaviour
{
    public static WInLose Instance { get; private set; }

    private bool start;
    private GameObject _canvas;
    private bool win, lose = false;


    private void Awake()
    {
        if (Instance != null)
            return;
        else Instance = this;

        Init();
    }

    public void Init()
    {
        win = lose = false;
        _canvas = GameObject.FindGameObjectWithTag("Canvas");
        start = false;
        Time.timeScale = 1;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        start = true;
    }

    /*private void LateUpdate()
    {
        if(win || lose) return;
        if (start)
        {
            if (LevelTask.Instance.CurrentTiles == 0)
            {
                GameOver();
            }
        }
    }*/

    public void GameOver()
    {
        lose = true;
        var loseMenu = Instantiate(Resources.Load<GameObject>("Prefabs/LoseMenu"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        loseMenu.transform.SetParent(_canvas.transform, false);
        Time.timeScale = 0;
    }

    public void LevelDone()
    {
        win = true;
        var winmenu = Instantiate(Resources.Load<GameObject>("Prefabs/WinMenu"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        winmenu.transform.SetParent(_canvas.transform, false);
        Time.timeScale = 0;
    }

}
