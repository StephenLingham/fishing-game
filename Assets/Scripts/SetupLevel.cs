using UnityEngine;
using UnityEngine.UI;

public class SetupLevel : MonoBehaviour
{
    public Transform LevelBackground;

    public Sprite Level1BackgroundImage;
    public Sprite Level2BackgroundImage;
    public Sprite Level3BackgroundImage;
    public Sprite Level4BackgroundImage;
    public Sprite Level5BackgroundImage;
    public Sprite Level6BackgroundImage;
    public Sprite Level7BackgroundImage;
    public Sprite Level8BackgroundImage;
    public Sprite Level9BackgroundImage;
    public Sprite Level10BackgroundImage;

    public void Start()
    {
        Debug.Log("Current level: " + GlobalState.CurrentLevel);

        switch (GlobalState.CurrentLevel)
        {
            case 0:
                LevelBackground.GetComponent<Image>().sprite = Level1BackgroundImage; 
                break;
            case 1:
                LevelBackground.GetComponent<Image>().sprite = Level2BackgroundImage;
                break;
            case 2:
                LevelBackground.GetComponent<Image>().sprite = Level3BackgroundImage;
                break;
            case 3:
                LevelBackground.GetComponent<Image>().sprite = Level4BackgroundImage;
                break;
            case 4:
                LevelBackground.GetComponent<Image>().sprite = Level5BackgroundImage;
                break;
            case 5:
                LevelBackground.GetComponent<Image>().sprite = Level6BackgroundImage;
                break;
            case 6:
                LevelBackground.GetComponent<Image>().sprite = Level7BackgroundImage;
                break;
            case 7:
                LevelBackground.GetComponent<Image>().sprite = Level8BackgroundImage;
                break;
            case 8:
                LevelBackground.GetComponent<Image>().sprite = Level9BackgroundImage;
                break;
            case 9:
                LevelBackground.GetComponent<Image>().sprite = Level10BackgroundImage;
                break;
        }
    }
}
