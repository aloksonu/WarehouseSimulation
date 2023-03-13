using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities;

public class PlayerScore : MonoSingleton<PlayerScore>
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI scoreTextMeshProUGUI;
    private float _fadeDuration = 0.2f;
    private int score;
    void Start()
    {
        //_canvasGroup.UpdateState(false, 0);
        Reset();
    }
    internal void BringIn()
    {
        _canvasGroup.UpdateState(true, _fadeDuration);
    }
    internal void BringOut()
    {
        _canvasGroup.UpdateState(false, _fadeDuration);
    }

    internal void Reset()
    {
        score = 0;
    }
    internal void UpdateScore()
    {

        score += 10;
        scoreTextMeshProUGUI.text = score.ToString();
      
    }

    internal int GetScore()
    {
        return score;
    }
}
