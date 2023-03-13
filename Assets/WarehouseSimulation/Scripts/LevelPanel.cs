using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

public class LevelPanel : MonoSingleton<LevelPanel>
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnContinue, btnBack;
    private float _fadeDuration = 0.2f;
    private string _currentSceneName = "WarehouseGamePlay";
    void Start()
    {
        _canvasGroup.UpdateState(false, 0);
        btnContinue.onClick.AddListener(OnContinueButtonPressed);
        btnBack.onClick.AddListener(OnBackButtonPressed);
    }
    private void OnDestroy()
    {
        btnContinue.onClick.RemoveAllListeners();
        btnBack.onClick.RemoveAllListeners();
    }
    private void OnContinueButtonPressed()
    {
        _canvasGroup.UpdateState(true, _fadeDuration, () => {
            StartCoroutine(_loadGame());
        });
    }
    private void OnBackButtonPressed()
    {
        _canvasGroup.UpdateState(false, _fadeDuration,()=> {
            StartPanel.Instance.BringIn();
        });
    }
    internal void BringIn()
    {
        _canvasGroup.UpdateState(true, _fadeDuration);
    }
    internal void BringOut()
    {
        _canvasGroup.UpdateState(false, _fadeDuration);
    }

    private IEnumerator _loadGame()
    {
        // yield return SceneManager.UnloadSceneAsync(_currentSceneName);
        LoadingPanel.Instance.BringIn();
        yield return SceneManager.LoadSceneAsync(_currentSceneName, LoadSceneMode.Additive);
        BringOut();
        LoadingPanel.Instance.BringOut();
        StartPanel.Instance.BringIn();
    }
}
