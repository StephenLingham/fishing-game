using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateBackToLevelSelect : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
