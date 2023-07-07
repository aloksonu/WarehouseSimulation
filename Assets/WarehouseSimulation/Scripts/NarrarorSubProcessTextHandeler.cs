using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using WarehouseSimulation.Scripts.Audio;

namespace WarehouseSimulation.Scripts
{
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
        internal string[] NPicking = new string[2];
        internal string[] NItemSortation = new string[2];
        internal string[] NPacking = new string[1];
        internal string[] NDespatch = new string[3];

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
            NReceiving[6] = "PRC Check: PIER RECEIVING CHARGE: Checks against Export charges at Pier(ports)�"; //PRC Check
            NReceiving[7] = "QA Check : Quality check by another associate to validate the goods against PR and damages/less Quality etc"; //QA Check

            NPutaway[0] = "Putaway Carton-�stores and later presents those goods to a point of use."; //Putaway Carton
            NPutaway[1] = "Hanging is used for putaway of pouches primarily for clothes"; //Hanging
            NPutaway[2] = "Oversized : Operations of oversized as well as overweight items which needs special handling."; //OverSized

            NInventoryManagement[0] = "Relocate: The act of transferring inventory items from one location to another within a system or organization.";//Relocate//ChatGpt
            NInventoryManagement[1] = "Audit Location is the process of checking the actual location of items against the planned/system driven locations to ensure Picking happens without error."; //Audit Location
            NInventoryManagement[2] = "Consolidation: The act of combining or merging inventory from multiple locations into a single location, typically to improve efficiency and reduce costs.";//Consolidation//ChatGpt

            NPicking[0] = "Standard Picking: The established method or process used to select and retrieve items from inventory for fulfilling customer orders.";//Standard Picking//ChatGpt
            NPicking[1] = "Hanging Picking: A picking technique where items are stored or suspended on hangers, typically used for garments or products with specific hanging requirements, allowing for easy identification and retrieval.";//Hanging Picking//ChatGpt
            //NPicking[2] = "Required One Liner Definition";

            NItemSortation[0] = "Staging: The process of temporarily storing or grouping items in a designated area before they are further processed or transported to their final destination.";//Staging//ChatGpt
            NItemSortation[1] = "Trolley Sort: A sortation method where items are placed on trolleys or carts and sorted manually or automatically based on their destination or specific criteria.";//Trolley Sort//ChatGpt

            NPacking[0] = "Packing: The process of carefully and securely preparing items for shipment or storage by appropriately wrapping, sealing, and packaging them to protect against damage or loss.";//Packing//ChatGpt

            NDespatch[0] = "Parcel sortation: the methods the postal systems and shipment carriers use to determine where and how to route mail and parcels for deliveries";//Parcel Sortation
            NDespatch[1] = "Handle Parcel: The physical action of receiving, inspecting, processing, and managing parcels or packages during the dispatch process to ensure accurate and timely delivery.";// Handle Parcel//ChatGpt
            NDespatch[2] = "Load TM is the process of loading items into the Transportation"; // Load TM
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
            isNarratorOpen = true;
            _canvasGroup.UpdateState(true, _fadeDuration, () =>{StartCoroutine(PlayAudio(audioName));});
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
}
