using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class NarratorTextHandler : MonoSingleton<NarratorTextHandler>
{
    private static Action _onCompleteNarrator;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private Button btnClose;
    private string _narratorText;
    private float _fadeDuration = 0.2f;

    public string NReceiving = "Receiving- is the process of replenishing stocked inventory in the warehouse.";
    public string NPutaway = "Putaway- is a broad term that encompasses every stage in the process of receiving goods.";
    public string NInventoryManagement = "";
    public string NPicking = "";
    public string NItemSortation = "";
    public string NPacking = "";
    public string NDespatch = "";
    void Start()
    {
        NReceiving = "Dematic receiving systems ensure you have predictability from the time inventory enters your facility to when it leaves your operation.";
        NPutaway = "Putaway- is a broad term that encompasses every stage in the process of receiving goods.";
        NInventoryManagement = "Required One Liner Definition";
        NPicking = "Required One Liner Definition";
        NItemSortation = "Required One Liner Definition";
        NPacking = "Required One Liner Definition";
        NDespatch = "Required One Liner Definition";
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
