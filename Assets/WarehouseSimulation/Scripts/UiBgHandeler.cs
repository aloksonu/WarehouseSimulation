using UnityEngine;
using Utilities;

namespace WarehouseSimulation.Scripts
{
    public class UiBgHandeler : MonoSingleton<UiBgHandeler>
    {
        [SerializeField] private CanvasGroup canvasGroup;
        private float _fadeDuration = 0.2f;
        void Start()
        {
            canvasGroup.UpdateState(false, 0);
        }
        internal void BringIn()
        {
            canvasGroup.UpdateState(true, _fadeDuration);
        }
        internal void BringOut()
        {
            canvasGroup.UpdateState(false, _fadeDuration);
        }
    }
}
