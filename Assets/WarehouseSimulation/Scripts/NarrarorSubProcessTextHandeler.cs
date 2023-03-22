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
    internal string[] NPutaway = new string[3];
    internal string[] NInventoryManagement = new string[3];
    internal string[] NPicking = new string[3];

    public bool isNarratorOpen = false;
    void Start()
    {
        _canvasGroup.UpdateState(false, 0);
        SetNarrator();
        btnClose.onClick.AddListener(BringOutNarrator);
    }

    private void SetNarrator()
    {
        NReceiving[0] = "Required One Liner Definition";
        NReceiving[1] = "Required One Liner Definition";
        NReceiving[2] = "Required One Liner Definition";
        NReceiving[3] = "Required One Liner Definition";
        NReceiving[4] = "Required One Liner Definition";
        NReceiving[5] = "Required One Liner Definition";
        NReceiving[6] = "Required One Liner Definition";
        NReceiving[7] = "Required One Liner Definition";

        NPutaway[0] = "Required One Liner Definition";
        NPutaway[1] = "Required One Liner Definition";
        NPutaway[2] = "Required One Liner Definition";

        NInventoryManagement[0] = "Required One Liner Definition";
        NInventoryManagement[1] = "Required One Liner Definition";
        NInventoryManagement[2] = "Required One Liner Definition";

        NPicking[0] = "Required One Liner Definition";
        NPicking[1] = "Required One Liner Definition";
        NPicking[2] = "Required One Liner Definition";
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
        if (_onCompleteNarrator != null)
        {
            _canvasGroup.UpdateState(false, _fadeDuration, () => {

                _onCompleteNarrator();
                // isNarratorOpen = false;
                _onCompleteNarrator = null;
            });
        }
        else { 
        _canvasGroup.UpdateState(false, _fadeDuration, () => {
               // isNarratorOpen = false;
                _onCompleteNarrator = null;
            });
        }

    }

}
