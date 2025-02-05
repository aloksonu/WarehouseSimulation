using System.Collections;
using TMPro;
using UnityEngine;
using Utilities;

namespace WarehouseSimulation.Scripts
{
    public class TimeManager : MonoSingleton<TimeManager>
    {
        private float _currentTimeLeft;
        IEnumerator _timeEnumerator;
        private int _minutes, _seconds;
        [SerializeField] private TextMeshProUGUI timerTextMeshProUGUI;

        internal bool isTimePaused;
        void Start()
        {
            isTimePaused = false;
            _timeEnumerator = TimerRoutine();
            ClearTimer();
        }

        private IEnumerator TimerRoutine()
        {
            while (_currentTimeLeft >= 0)
            {
                while (isTimePaused == true)
                {
                    yield return null;
                }
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
            //if(_timeEnumerator!=null)
            StopCoroutine(_timeEnumerator);
            StartCoroutine(_timeEnumerator);
        }

        public void PauseTimer()
        {
            StopCoroutine(_timeEnumerator);
        }
        public void ClearTimer()
        {
            _currentTimeLeft = 0;
            _minutes = (int)_currentTimeLeft / 60;
            _seconds = (int)_currentTimeLeft % 60;
            timerTextMeshProUGUI.text = _minutes.ToString() + ":" + _seconds.ToString("00");
        }
        //public void StartTimer()
        //{
        //    // StopCoroutine(co);
        //    StartCoroutine(_timeEnumerator);
        //}
    }
}
