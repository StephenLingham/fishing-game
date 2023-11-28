using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeFishingSkill : MonoBehaviour
{
    public Transform FishingSkillText;
    private TMP_Text _fishingSkillTextComponent;

    public Button UpgradeFishingSkillButton;

    public void Start()
    {
        _fishingSkillTextComponent = FishingSkillText.GetComponent<TMP_Text>();
    }

    public void Update()
    {
        _fishingSkillTextComponent.text = $"Fishing skill: {GlobalState.FishingSkill}";

        if (GlobalState.FishingSkill >= GlobalState.MaxFishingSkill)
        {
            UpgradeFishingSkillButton.enabled = false;
        }
    }

    public void Upgrade()
    {
        if (GlobalState.FishingSkill >= GlobalState.MaxFishingSkill)
        {
            return;
        }

        if (GlobalState.CurrentFishCount >= GlobalState.FishingSkillUpgradeCost)
        {
            GlobalState.CurrentFishCount -= GlobalState.FishingSkillUpgradeCost;
            GlobalState.FishingSkill++;
        }
    }
}
