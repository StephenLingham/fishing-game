using UnityEngine;

public class HandleEnableNextLevelButton : MonoBehaviour
{
    public Transform NextLevelButton;

    public void Update()
    {
        UpdateNextLevelButtonEnabled();
    }

    private void UpdateNextLevelButtonEnabled()
    {
        var nextLevelIsUnlocked = GlobalState.LevelUnlocked(GlobalState.CurrentLevel + 1);

        NextLevelButton.gameObject.SetActive(nextLevelIsUnlocked);
    }
}
