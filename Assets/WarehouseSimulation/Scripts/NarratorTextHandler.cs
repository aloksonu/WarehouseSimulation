using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class NarratorTextHandler : MonoSingleton<NarratorTextHandler>
{
    private static Action _onClickCrossButton, _onCompleteNarrator;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private Button btnClose;
    private string _narratorText;
    private float _fadeDuration = 0.4f;

    public string NReceiving = "The warehouse receiving process steps include delivery of the products, unloading from the delivery trunk, and inventory storage";
    public string NPutaway = "Put-away is actually one of the key components in terms of warehouse management." +
    " Its basically process of storing goods in a warehouse. Here we take items from inventory and them put them on the different pallet or shelves.";
    void Start()
    {
        _canvasGroup.UpdateState(false, 0);
        btnClose.onClick.AddListener(BringOutNarrator);
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
        _canvasGroup.UpdateState(true, _fadeDuration);
    }

    private void BringOnNarratorComplete()
    {
        if (_onCompleteNarrator != null)
        {
            _canvasGroup.UpdateState(false, _fadeDuration ,()=>{

                _onCompleteNarrator();
                _onCompleteNarrator = null;
            });

        }
    }

    internal void BringOutNarrator()
    {
        if (_onCompleteNarrator != null)
        {
            _canvasGroup.UpdateState(false, _fadeDuration, () => {

                _onCompleteNarrator();
                _onCompleteNarrator = null;
            });

        }
    }
}
