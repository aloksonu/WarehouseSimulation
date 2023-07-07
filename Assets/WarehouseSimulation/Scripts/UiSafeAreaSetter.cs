using UnityEngine;

namespace WarehouseSimulation.Scripts
{
    [RequireComponent(typeof(Canvas))]
    public class UiSafeAreaSetter : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform panelSafeArea;

        private void OnValidate()
        {
            if (gameObject.name.Contains("SafeArea") == false)
                gameObject.name += " (with SafeArea)";

            //if (firstChild && firstChild.name != "SafeArea")
            //{
            //    GameObject safeAreaGo = Instantiate(new GameObject("SafeArea"), transform);
            //    foreach (Transform child in transform)
            //    {
            //        if (child != safeAreaGo.transform)
            //            child.parent = safeAreaGo.transform;
            //    }
            //}

            if (!canvas)
                canvas = GetComponent<Canvas>();

            if (!panelSafeArea)
            {
                Transform firstChild = transform.GetChild(0);
                if (firstChild && firstChild.name == "SafeArea")
                    panelSafeArea = firstChild.GetComponent<RectTransform>();
            }

        }

        private void Awake()
        {
            ApplySafeArea();
        }

        private void ApplySafeArea()
        {
            if (panelSafeArea == null) return;

            Rect safeArea = Screen.safeArea;

            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= canvas.pixelRect.width;
            anchorMin.y /= canvas.pixelRect.height;

            anchorMax.x /= canvas.pixelRect.width;
            anchorMax.y /= canvas.pixelRect.height;

            panelSafeArea.anchorMin = anchorMin;
            panelSafeArea.anchorMax = anchorMax;
        }
    }
}