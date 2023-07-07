using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

namespace WarehouseSimulation.Scripts
{
    public class LevelFail : MonoSingleton<LevelFail>
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button btnRetry, btnHome;
        [SerializeField] private TextMeshProUGUI levelFailTextMeshProUGUI;
        private float _fadeDuration = 0.2f;
        void Start()
        {
            _canvasGroup.UpdateState(false, 0);
            btnRetry.onClick.AddListener(OnRetryButtonPressed);
            btnHome.onClick.AddListener(OnHomeButtonPressed);
        }

        private void OnDestroy()
        {
            btnRetry.onClick.RemoveAllListeners();
            btnHome.onClick.RemoveAllListeners();
        }
        internal void BringIn()
        {
            //levelFailTextMeshProUGUI.text = _gameCompleteText + " " + LevelPanel.Instance.levelName;
            _canvasGroup.UpdateState(true, _fadeDuration);
        }
        internal void BringOut()
        {
            _canvasGroup.UpdateState(false, _fadeDuration);
        }

        internal void OnRetryButtonPressed()
        {
            UiBgHandeler.Instance.BringOut();
            _canvasGroup.UpdateState(false, _fadeDuration, () => {
                Player.Instance.SetPlayerTransformPosition();
                Player.Instance.SetLevel();
                PlayerScore.Instance.ResetScore();
                HealthManager.Instance.ResetHealth();
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
    }
}
