using UnityEngine;

public class ToggleHud : MonoBehaviour
{
    public Transform Hud;

    public void Toggle()
    {
        Hud.gameObject.SetActive(!Hud.gameObject.activeSelf);
    }
}
