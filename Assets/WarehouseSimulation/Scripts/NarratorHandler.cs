using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class NarratorHandler : MonoSingleton<NarratorHandler>
{
    private  Action _onComplete;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Button btnClose;
    [SerializeField] private Image img;

    public Sprite spriteReceiving;
    private const float _fadeDuration = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup.UpdateState(false, 0);
        btnClose.onClick.AddListener(BringOut);
    }
    private void OnDestroy()
    {
        btnClose.onClick.RemoveAllListeners();
    }
    internal void BringIn(Sprite spr, Action onComplete = null)
    {
        img.sprite = spr;
        _onComplete = onComplete;
        canvasGroup.UpdateState(true, _fadeDuration);
    }

    internal void BringOut()
    {
        canvasGroup.UpdateState(false, _fadeDuration, () => {

            if (_onComplete != null)
            {
                _onComplete();
                _onComplete = null;
            }
        });
    }
}
