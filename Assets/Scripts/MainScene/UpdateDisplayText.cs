using System;
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
    public TMP_Text TimeSpentFishingText;

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

        var upgradeCostText = GlobalState.FishingSkill < GlobalState.MaxFishingSkill
            ? $"{GlobalState.CurrentFishCount}/{GlobalState.FishingSkillUpgradeCost}"
            : "Max";

        _upgradeFishingSkillText.text = $"Upgrade fishing skill\n({upgradeCostText})";

        TotalUniqueFishCaughtText.text = $"Total unique fish caught: {GlobalState.TotalUniqueFishCaught}";

        TimeSpentFishingText.text = $"Total time spent fishing: {TimeSpan.FromSeconds(GlobalState.TimeSpentFishing):hh':'mm':'ss}";
    }
}
