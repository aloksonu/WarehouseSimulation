using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class StartPanel : MonoSingleton<StartPanel>
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnContinue, btnClose;
    [SerializeField] private TMP_InputField inputFieldName;
    [SerializeField] private TextMeshProUGUI nameBlankText;
    internal string playerName;
    private float _fadeDuration = 0.2f;
    void Start()
    {
        //_canvasGroup.UpdateState(false, 0);
        nameBlankText.text = "";
        btnContinue.onClick.AddListener(OnContinueButtonPressed);
        btnClose.onClick.AddListener(OnCloseButtonPressed);
    }
    private void OnDestroy()
    {
        btnContinue.onClick.RemoveAllListeners();
        btnClose.onClick.RemoveAllListeners();
    }
    private void OnContinueButtonPressed()
    {
        playerName = inputFieldName.text;
        if (!String.IsNullOrEmpty(playerName))
        {
            _canvasGroup.UpdateState(false, _fadeDuration,()=> {

                LevelPanel.Instance.BringIn();
                nameBlankText.text = "";
                inputFieldName.text = "";
            });
        }
        else
        {
            nameBlankText.text = "Name Can Not Be Blank";
        }
    }
    private void OnCloseButtonPressed()
    {
        Application.Quit();
    }
    internal void BringIn()
    {
        _canvasGroup.UpdateState(true, _fadeDuration);
    }
}
