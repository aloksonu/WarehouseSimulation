
using System.Collections.Generic;
using UnityEngine.UI;


[System.Serializable]
public class LevelDataWrapper
{
    public List<LevelData> levelData = new List<LevelData>();
}
[System.Serializable]
public class LevelData
{
    public Button button;
    public LevelsName levelsName;
    public bool isLocked;
    public int score;
}
