using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities;

public class TimeManager : MonoSingleton<TimeManager>
{
    private float _currentTimeLeft;
    IEnumerator _timeEnumerator;
    private int _minutes, _seconds;
    [SerializeField] private TextMeshProUGUI timerTextMeshProUGUI;
    void Start()
    {
        _timeEnumerator = TimerRoutine();
        StartModule();
    }

    private IEnumerator TimerRoutine()
    {
        while (_currentTimeLeft >= 0)
        {
            _minutes = (int)_currentTimeLeft / 60;
            _seconds = (int)_currentTimeLeft % 60;
            timerTextMeshProUGUI.text = _minutes.ToString() + ":" + _seconds.ToString("00");
            _currentTimeLeft++;
            yield return new WaitForSeconds(1.0f);
        }  
    }

    internal void StartModule()
    {
        _currentTimeLeft = 0;
        StopCoroutine(_timeEnumerator);
        StartCoroutine(_timeEnumerator);
    }

    public void PauseTimer()
    {
        StopCoroutine(_timeEnumerator);
    }
    //public void StartTimer()
    //{
    //    // StopCoroutine(co);
    //    StartCoroutine(_timeEnumerator);
    //}
}
