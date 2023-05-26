using Audio.Warehouse;
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

    public string NReceiving = "";
    public string NPutaway = "";
    public string NInventoryManagement = "";
    public string NPicking = "";
    public string NItemSortation = "";
    public string NPacking = "";
    public string NDespatch = "";
    void Start()
    {
        NReceiving = "Dematic receiving systems ensure you have predictability from the time inventory enters your facility to when it leaves your operation.";
        NPutaway = "Putaway : a rule-based system of moving received items to the assigned places in warehouses.";
        NInventoryManagement = "Inventory management in a warehouse is crucial for meeting customer demand," +
            " reducing waste and losses, and improving overall supply chain efficiency.";
        NPicking = "Picking : System driven item retrieval based on either voice, visual or handheld driven instruction.";
        NItemSortation = "Sortation : the process of identifying individual items on a conveyor system and diverting them to correct locations using a variety of devices controlled by task-specific software.";
        NPacking = "Packing : pack the items using appropriate materials in appropriate container to pack the products, weighing the package, and labeling it with the relevant invoice or packing slip for shipping process to take it fwd.";
        NDespatch = "Despatch in a warehouse refers to the process of preparing and shipping products or items to customers" +
            " or other destinations.";
        _canvasGroup.UpdateState(false, 0);
        btnClose.onClick.AddListener(BringOutNarrator);
    }

    private void OnDestroy()
    {
        btnClose.onClick.RemoveAllListeners();
    }

    internal void BringInNarrator(string narratorText,
             Action onCompleteNarrator = null, AudioName audioName = AudioName.NotSet)
    {
        _narratorText = narratorText;
        panelText.text = _narratorText;
        _onCompleteNarrator = onCompleteNarrator;
        _canvasGroup.UpdateState(true, _fadeDuration, () => { StartCoroutine(PlayAudio(audioName));});
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
