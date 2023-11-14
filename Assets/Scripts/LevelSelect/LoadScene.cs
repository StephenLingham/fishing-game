using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        if (!GlobalState.LevelUnlocked(level))
        {
            return;
        }

        GlobalState.CurrentLevel = level;
        LoadMainScene();
    }

    private void LoadMainScene()
    {
        GlobalState.UpdateNumberOfUniqueFishCaughtThisLevel();
        SceneManager.LoadScene("MainScene");
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
