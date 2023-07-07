using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using WarehouseSimulation.Scripts.Audio;

namespace WarehouseSimulation.Scripts
{
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
            GenericAudioManager.Instance.PlaySound(AudioName.GameBG);
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
            GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
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
            //GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
            Application.Quit();
        }
        internal void BringIn()
        {
            // GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
            _canvasGroup.UpdateState(true, _fadeDuration);
        }
    }
}
