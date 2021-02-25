using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ProgressBar : MonoBehaviour
{
    public static ProgressBar Instance { get; private set; }
    private int MaxValue;
    private Image _bar;

    private void Start()
    {
        if (Instance != null)
            return;
        else
            Instance = this;
        Init();
    }

    public void Init()
    {
        MaxValue = 0;
        _bar = GetComponent<Image>();
        LevelTask.Instance.OnPassangersChange += ValueChangedHandler;
    }

    private void ValueChangedHandler(int newVal)
    {
        if (MaxValue == 0) GetMaxValue();
        _bar.fillAmount = (float)newVal / (float)MaxValue;
    }

    private void GetMaxValue()
    {
        MaxValue = LevelTask.Instance.MaxPassangers;
    }
}
