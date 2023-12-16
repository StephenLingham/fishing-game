using System;
using TMPro;
using UnityEngine;

public class UpdateDisplayText : MonoBehaviour
{
    public TMP_Text CurrentFishCaughtText;
    public TMP_Text TotalFishCaughtText;
    public TMP_Text UpgradeFishingSkillText;
    public TMP_Text TotalUniqueFishCaughtText;
    public TMP_Text TimeSpentFishingText;
    public TMP_Text UniqueFishText;

    void Update()
    {
        CurrentFishCaughtText.text = $"Current fish: {GlobalState.CurrentFishCount}";
        TotalFishCaughtText.text = $"Total fish caught: {GlobalState.AllTimeTotalFishCaught}";

        var upgradeCostText = GlobalState.FishingSkill < GlobalState.MaxFishingSkill
            ? $"{GlobalState.CurrentFishCount}/{GlobalState.FishingSkillUpgradeCost}"
            : "Max";

        UpgradeFishingSkillText.text = $"Upgrade fishing skill\n({upgradeCostText})";

        TotalUniqueFishCaughtText.text = $"Total unique fish caught: {GlobalState.TotalUniqueFishCaught}";

        TimeSpentFishingText.text = $"Total time spent fishing: {TimeSpan.FromSeconds(GlobalState.TimeSpentFishing):hh':'mm':'ss}";

        UniqueFishText.text = $"Unique fish caught from this level: {GlobalState.NumberOfUniqueFishCaughtThisLevel} out of {10}";
    }
}
