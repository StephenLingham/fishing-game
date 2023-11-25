using TMPro;
using UnityEngine;

public class UpdateDisplayText : MonoBehaviour
{
    public Transform CurrentFishCaughtText;
    public Transform TotalFishCaughtText;
    public Transform UpgradeFishingSkillText;

    private TMP_Text _currentFishCaughtTextComponent;
    private TMP_Text _totalFishCaughtTextComponent;
    private TMP_Text _upgradeFishingSkillText;

    public TMP_Text TotalUniqueFishCaughtText;

    void Start()
    {
        _currentFishCaughtTextComponent = CurrentFishCaughtText.GetComponent<TMP_Text>();
        _totalFishCaughtTextComponent = TotalFishCaughtText.GetComponent<TMP_Text>();
        _upgradeFishingSkillText = UpgradeFishingSkillText.GetComponent<TMP_Text>();
    }

    void Update()
    {
        _currentFishCaughtTextComponent.text = $"Current fish: {GlobalState.CurrentFishCount}";
        _totalFishCaughtTextComponent.text = $"Total fish caught: {GlobalState.AllTimeTotalFishCaught}";
        _upgradeFishingSkillText.text = $"Upgrade fishing skill\n({GlobalState.FishingSkillUpgradeCost} fish)";

        TotalUniqueFishCaughtText.text = $"Total unique fish caught: {GlobalState.TotalUniqueFishCaught}";
    }
}
