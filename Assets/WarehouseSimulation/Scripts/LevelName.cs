using UnityEngine;
using UnityEngine.UI;

namespace WarehouseSimulation.Scripts
{
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
        InventoryManagement = 2,
        Picking = 3,
        ItemSortation = 4,
        Packing = 5,
        Despatch = 6,
    }
}