using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelName : MonoBehaviour
{
    public Button btnLevel;
    public LevelsName levelsName;
    //internal string strLevelName;
    void Start()
    {
        btnLevel.onClick.AddListener(OnClickLeveButton);
    }

    private void OnClickLeveButton()
    {
        LevelPanel.Instance.levelName = levelsName.ToString();
        LevelPanel.Instance.OnContinueButtonPressed();
        Debug.Log(LevelPanel.Instance.levelName);
    }
}

public enum LevelsName
{

    NotSet = -1,
    Receiving = 0,
    Putaway = 1,
    Storage = 2,
    Picking = 3,
    Transport = 4,
    Shipping = 5,
}
