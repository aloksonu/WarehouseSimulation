using Audio.Warehouse;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Tutorial : MonoSingleton<Tutorial>
{
    private const string T01 = "Use joystick to move player and collect all subprocess in correct order .";

    private static Action _onComplete;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private Button btnClose;
    private string _tText;
    private float _fadeDuration = 0.2f;
    void Start()
    {
        btnClose.onClick.AddListener(BringOut);
       // _canvasGroup.UpdateState(false,0);
    }

    private void OnDestroy()
    {
        btnClose.onClick.RemoveAllListeners();
    }

    internal void BringIn(string tText,
             Action onComplete = null, AudioName audioName = AudioName.NotSet)
    {
        _tText = tText;
        //panelText.text = _tText;
        panelText.text = T01;
        _onComplete = onComplete;
        _canvasGroup.UpdateState(true, _fadeDuration, () => { StartCoroutine(PlayAudio(audioName)); });
    }

    private IEnumerator PlayAudio(AudioName audioName)
    {
        if (audioName != AudioName.NotSet)
        {
            btnClose.interactable = false;
            yield return new WaitForSeconds(0.5f);
            GenericAudioManager.Instance.PlaySound(audioName);
            yield return new WaitForSeconds(GenericAudioManager.Instance.GetAudioLength(audioName));
            btnClose.interactable = true;
        }
    }

    internal void BringOut()
    {
        if (_onComplete != null)
        {
            _canvasGroup.UpdateState(false, _fadeDuration, () => {

                _onComplete();
                _onComplete = null;
            });

        }
    }

}
