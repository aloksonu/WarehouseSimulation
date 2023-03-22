using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class NarrarorSubProcessTextHandeler : MonoSingleton<NarrarorSubProcessTextHandeler>
{
    private static Action  _onCompleteNarrator;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private Button btnClose;
    private string _narratorText;
    private float _fadeDuration = 0.2f;

    internal string[] NReceiving = new string[8];
    //public string NTipping = "1";
    //public string OpenTrailer = "2";
    //public string AssignLane = "3";
    //public string CloseTrailer = "4";
    //public string ManualReceipt = "5";
    //public string NewSkuChecks = "6";
    //public string PRCChecks = "7";
    //public string QAChecks = "8";

    public bool isNarratorOpen = false;
    void Start()
    {
        _canvasGroup.UpdateState(false, 0);
        SetNarrator();
        btnClose.onClick.AddListener(BringOutNarrator);
    }

    private void SetNarrator()
    {
        NReceiving[0] = "1";
        NReceiving[1] = "2";
        NReceiving[2] = "3";
        NReceiving[3] = "4";
        NReceiving[4] = "5";
        NReceiving[5] = "6";
        NReceiving[6] = "7";
        NReceiving[7] = "8";
    }

    private void OnDestroy()
    {
        btnClose.onClick.RemoveAllListeners();
    }

    internal void BringInNarrator(string narratorText,
             Action onCompleteNarrator = null)
    {
        _narratorText = narratorText;
        panelText.text = _narratorText;
        _onCompleteNarrator = onCompleteNarrator;
        isNarratorOpen = true;
        _canvasGroup.UpdateState(true, _fadeDuration);
    }

    private void BringOnNarratorComplete()
    {
        if (_onCompleteNarrator != null)
        {
            _canvasGroup.UpdateState(false, _fadeDuration, () => {

                _onCompleteNarrator();
                isNarratorOpen = false;
                _onCompleteNarrator = null;
            });

        }
    }

    internal void BringOutNarrator()
    {

        isNarratorOpen = false;
        _canvasGroup.UpdateState(false, _fadeDuration, () => {

                _onCompleteNarrator();
               // isNarratorOpen = false;
                _onCompleteNarrator = null;
            });

    }

}
