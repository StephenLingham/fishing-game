using UnityEngine;

public class ResizeUiElement : MonoBehaviour
{
    public RectTransform uiElement;
    public float widthAsPercentageOfScreenHeight;
    public float heightAsPercentageOfScreenHeight;

    void Start()
    {
        float newWidth = Screen.height * widthAsPercentageOfScreenHeight;
        float newHeight = Screen.height * heightAsPercentageOfScreenHeight;

        uiElement.sizeDelta = new Vector2(newWidth, newHeight);
    }
}
