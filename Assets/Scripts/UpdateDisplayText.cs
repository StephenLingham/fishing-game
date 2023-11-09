using TMPro;
using UnityEngine;

public class UpdateDisplayText : MonoBehaviour
{
    public Transform CurrentFishCaughtText;
    public Transform TotalFishCaughtText;
    private TMP_Text _currentFishCaughtTextComponent;
    private TMP_Text _totalFishCaughtTextComponent;

    void Start()
    {
        _currentFishCaughtTextComponent = CurrentFishCaughtText.GetComponent<TMP_Text>();
        _totalFishCaughtTextComponent = TotalFishCaughtText.GetComponent<TMP_Text>();
    }

    void Update()
    {
        _currentFishCaughtTextComponent.text = $"Current fish: {GlobalState.CurrentFishCount}";
        _totalFishCaughtTextComponent.text = $"Total fish caught: {GlobalState.AllTimeTotalFishCaught}";
    }
}
