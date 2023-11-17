using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateBackToSplashScreen : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("SplashScreen");
        }
    }
}
