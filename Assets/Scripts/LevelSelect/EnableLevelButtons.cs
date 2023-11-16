using UnityEngine;
using UnityEngine.UI;

public class EnableLevelButtons : MonoBehaviour
{
    public Transform Level1Button;
    public Transform Level2Button;
    public Transform Level3Button;
    public Transform Level4Button;
    public Transform Level5Button;
    public Transform Level6Button;
    public Transform Level7Button;
    public Transform Level8Button;
    public Transform Level9Button;
    public Transform Level10Button;

    public void Start()
    {
        Level1Button.GetComponent<Button>().interactable = GlobalState.LevelUnlocked(0);
        Level2Button.GetComponent<Button>().interactable = GlobalState.LevelUnlocked(1);
        Level3Button.GetComponent<Button>().interactable = GlobalState.LevelUnlocked(2);
        Level4Button.GetComponent<Button>().interactable = GlobalState.LevelUnlocked(3);
        Level5Button.GetComponent<Button>().interactable = GlobalState.LevelUnlocked(4);
        Level6Button.GetComponent<Button>().interactable = GlobalState.LevelUnlocked(5);
        Level7Button.GetComponent<Button>().interactable = GlobalState.LevelUnlocked(6);
        Level8Button.GetComponent<Button>().interactable = GlobalState.LevelUnlocked(7);
        Level9Button.GetComponent<Button>().interactable = GlobalState.LevelUnlocked(8);
        Level10Button.GetComponent<Button>().interactable = GlobalState.LevelUnlocked(9);
    }
}
