using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;
using WarehouseSimulation.Scripts.DataSave;

namespace WarehouseSimulation.Scripts
{
    public class LevelComplete : MonoSingleton<LevelComplete>
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button btnNext, btnHome;
        [SerializeField] private TextMeshProUGUI gameCompleteTextMeshProUGUI;
        private float _fadeDuration = 0.2f;

        private string _gameCompleteText ="Congratulation To Complete";

        void Start()
        {
            _canvasGroup.UpdateState(false, 0);
            btnNext.onClick.AddListener(OnNextButtonPressed);
            btnHome.onClick.AddListener(OnHomeButtonPressed);
        }
        private void OnDestroy()
        {
            btnNext.onClick.RemoveAllListeners();
            btnHome.onClick.RemoveAllListeners();
        }
        internal void BringIn()
        {
            //gameCompleteTextMeshProUGUI.text = $"{_gameCompleteText}{LevelPanel.Instance.levelName}";
            gameCompleteTextMeshProUGUI.text = _gameCompleteText + " " + LevelPanel.Instance.levelName;
            _canvasGroup.UpdateState(true, _fadeDuration);
            UnlockNextLevel();
        }
        internal void BringOut()
        {
            _canvasGroup.UpdateState(false, _fadeDuration);
        }

        internal void OnNextButtonPressed()
        {
            _canvasGroup.UpdateState(false, _fadeDuration, () => {
                Player.Instance.SetPlayerTransformPosition();
                Player.Instance.SetPlayerTransformPosition();
            });
        }
        internal void OnHomeButtonPressed()
        {
            StartCoroutine(UloadScene());
        }

        IEnumerator UloadScene()
        {
            yield return SceneManager.UnloadSceneAsync("WarehouseGamePlay");
        }

        private void UnlockNextLevel()
        {
            if(LevelPanel.Instance.levelName == "Receiving")
            {
                DataManager.Instance.UpdateLock(LevelsName.Putaway, false);
            }
            else if (LevelPanel.Instance.levelName == "Putaway")
            {
                DataManager.Instance.UpdateLock(LevelsName.InventoryManagement, false);
            }
            else if (LevelPanel.Instance.levelName == "InventoryManagement")
            {
                DataManager.Instance.UpdateLock(LevelsName.Picking, false);
            }
            else if (LevelPanel.Instance.levelName == "Picking")
            {
                DataManager.Instance.UpdateLock(LevelsName.ItemSortation, false);
            }
            else if (LevelPanel.Instance.levelName == "ItemSortation")
            {
                DataManager.Instance.UpdateLock(LevelsName.Packing, false);
            }
            else if (LevelPanel.Instance.levelName == "Packing")
            {
                DataManager.Instance.UpdateLock(LevelsName.Despatch, false);
            }
        }
    }
}
