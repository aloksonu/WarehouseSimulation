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
        NReceiving[0] = "Tipping: Offloading goods and verifying against the Purchase requisition"; //Tipping
        NReceiving[1] = "Open Trailer: Is a step in the system to notify the trailer is opened for verification and tipping"; //Open Traile
        NReceiving[2] = "Assign Lane: large number of shipments or carriers being used every day."; //Assign Lane
        NReceiving[3] = "Close Trailer: Once all assigned goods as per PR is tipped the trailer close steps is done";//Close Trailer
        NReceiving[4] = "Manual Receipt: for infrequent or irregular transactions, or for transactions conducted in the absence of" +
            " a terminal, cash register or point of sale."; //Manual Receipt
        NReceiving[5] = "New Sku check: scannable code to help vendors automatically track the movements of inventory"; //New Sku check
        NReceiving[6] = "PRC Check: PIER RECEIVING CHARGE: Checks against Export charges at Pier(ports) "; //PRC Check
        NReceiving[7] = "QA Check : Quality check by another associate to validate the goods against PR and damages/less Quality etc"; //QA Check

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
