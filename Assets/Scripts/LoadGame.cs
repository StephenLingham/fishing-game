using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public void Awake()
    {
        GlobalState.LoadGameState();
    }
}
