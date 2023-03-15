using UnityEngine;
using Utilities;

public class LevelComplete : MonoSingleton<LevelComplete>
{
    [SerializeField] private CanvasGroup _canvasGroup;
    private float _fadeDuration = 0.2f;

    void Start()
    {
        _canvasGroup.UpdateState(false, 0);
    }
    internal void BringIn()
    {
        _canvasGroup.UpdateState(true, _fadeDuration);
    }
    internal void BringOut()
    {
        _canvasGroup.UpdateState(false, _fadeDuration);
    }
}
