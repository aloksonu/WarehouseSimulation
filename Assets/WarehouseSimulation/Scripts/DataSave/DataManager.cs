using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class DataManager : MonoSingleton<DataManager>
{
    private string DataKey = "GameData";
    public LevelDataWrapper db;
    void Start()
    {
        PlayerPrefs.DeleteAll(); // remove from final build
        UnlockAllLevelForDemo(); // remove from final build
        FetchStudentScoreTrainingMode();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }
       else if (Input.GetKeyUp(KeyCode.P))
        {
            UpdateLock(LevelsName.Putaway, false);
        }
        else if (Input.GetKeyUp(KeyCode.I))
        {
            UpdateLock(LevelsName.InventoryManagement, false);
        }
    }

    internal void SaveStudentScoreTrainingMode()
    {
        string json = JsonUtility.ToJson(db);
        PlayerPrefs.SetString(DataKey, json);
        Debug.Log("Save="+json);
    }

    internal void FetchStudentScoreTrainingMode()
    {

        if (!PlayerPrefs.HasKey(DataKey))
        {
            SaveStudentScoreTrainingMode();
        }
        string json = PlayerPrefs.GetString(DataKey);
        JsonUtility.FromJsonOverwrite(json, db);

        UpdateAllProcessButtons();
    }

    internal void UpdateLock(LevelsName levelName , bool b)
    {
         db.levelData[(int)levelName].isLocked = b;
        UpdateAllProcessButtons();
        SaveStudentScoreTrainingMode();
    }

    private void UpdateAllProcessButtons()
    {
        foreach(LevelData d in db.levelData)
        {
            d.button.interactable = !d.isLocked;
        }
    }

    private void UnlockAllLevelForDemo()
    {
        foreach (LevelData d in db.levelData)
        {
            d.isLocked = false;
            d.button.interactable = !d.isLocked;
        }
    }
}
