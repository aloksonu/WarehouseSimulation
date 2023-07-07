using TMPro;
using UnityEngine;
using Utilities;

namespace WarehouseSimulation.Scripts
{
    public class PlayerScore : MonoSingleton<PlayerScore>
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI scoreTextMeshProUGUI;
        private float _fadeDuration = 0.2f;
        private int score;
        // private int subLevelNumber;
        void Start()
        {
            //_canvasGroup.UpdateState(false, 0);
            //subLevelNumber = 1;
            ResetScore();
        }
        internal void BringIn()
        {
            _canvasGroup.UpdateState(true, _fadeDuration);
        }
        internal void BringOut()
        {
            _canvasGroup.UpdateState(false, _fadeDuration);
        }

        internal void ResetScore()
        {
            score = 0;
            scoreTextMeshProUGUI.text = "Score: "+score.ToString();
        }
        internal void UpdateScore(int s)
        {

            score += s;
            scoreTextMeshProUGUI.text = "Score: " + score.ToString();
      
        }

        internal int GetScore()
        {
            return score;
        }
    }
}
