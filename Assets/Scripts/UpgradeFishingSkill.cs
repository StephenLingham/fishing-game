using TMPro;
using UnityEngine;

public class UpgradeFishingSkill : MonoBehaviour
{
    public Transform FishingSkillText;
    private TMP_Text _fishingSkillTextComponent;

    public void Start()
    {
        _fishingSkillTextComponent = FishingSkillText.GetComponent<TMP_Text>();
    }

    public void Update()
    {
        _fishingSkillTextComponent.text = $"Fishing skill: {GlobalState.FishingSkill}";
    }

    public void Upgrade()
    {
        if (GlobalState.CurrentFishCount >= GlobalState.FishingSkillUpgradeCost)
        {
            GlobalState.CurrentFishCount -= GlobalState.FishingSkillUpgradeCost;
            GlobalState.FishingSkill++;
        }
    }
}
