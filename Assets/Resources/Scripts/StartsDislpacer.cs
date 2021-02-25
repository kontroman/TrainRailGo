using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartsDislpacer : MonoBehaviour
{
    private void Start()
    {
        DisplayStars();
    }

    private void DisplayStars()
    {
        GameObject LeftStar = GameObject.Find("StarLeft");
        GameObject RightStar = GameObject.Find("StarRight");
        GameObject CenterStar = GameObject.Find("StarCenter");

        if (LevelTask.Instance.CurrentPassangers < LevelTask.Instance.passFor1stars) return;
        if(LevelTask.Instance.CurrentPassangers >= LevelTask.Instance.passFor1stars &&
            LevelTask.Instance.CurrentPassangers < LevelTask.Instance.passFor2stars)
        {
            CenterStar.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/star");
        }
        if (LevelTask.Instance.CurrentPassangers >= LevelTask.Instance.passFor2stars &&
            LevelTask.Instance.CurrentPassangers < LevelTask.Instance.passFor3stars)
        {
            LeftStar.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/star");
            RightStar.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/star");
        }
        if (LevelTask.Instance.CurrentPassangers >= LevelTask.Instance.passFor3stars)
        {
            CenterStar.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/star");
            LeftStar.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/star");
            RightStar.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/star");
        }
    }    

}
