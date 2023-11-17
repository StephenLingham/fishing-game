using UnityEngine;
using UnityEngine.UI;

public class FishCatching : MonoBehaviour
{
    private float _fishCatchingTimer = 0;

    private readonly float _timeToDisplayFish = 2;
    private float _displayFishTimer = 0;
    private bool _displayingFish = false;

    public Transform CaughtFishImage;
    public Transform DisplayText;
    public Transform TextCaughtFish;
    public Transform UniqueFishText;

    private Text _textCaughtFishComponent;
    private Image _caughtFishImageComponent;
    private Text _displayTextComponent;
    private Text _uniqueFishTextComponent;

    private void Start()
    {
        _textCaughtFishComponent = TextCaughtFish.GetComponent<Text>();
        _caughtFishImageComponent = CaughtFishImage.GetComponent<Image>();
        _displayTextComponent = DisplayText.GetComponent<Text>();
        _uniqueFishTextComponent = UniqueFishText.GetComponent<Text>();
    }

    void Update()
    {
        _fishCatchingTimer += Time.deltaTime;

        if (_fishCatchingTimer >= GlobalState.TimeToCatchFish)
        {
            _fishCatchingTimer = 0;

            CatchFish();
        }

        UpdateTimeTillNextFishText();

        UpdateUniqueFishCaughtText();

        UpdateDisplayingFish();
    }

    private void UpdateUniqueFishCaughtText()
    {
        var uniqueFishText = $"Unique fish caught this level: {GlobalState.NumberOfUniqueFishCaughtThisLevel} out of {10}";

        _uniqueFishTextComponent.text = uniqueFishText;
    }

    private void UpdateTimeTillNextFishText()
    {
        var displayText = $"Time till next fish: {_fishCatchingTimer:0.0} / {GlobalState.TimeToCatchFish}";

        _displayTextComponent.text = displayText;
    }

    void UpdateDisplayingFish()
    {
        if (!_displayingFish)
        {
            return;
        }

        _displayFishTimer += Time.deltaTime;

        if (_displayFishTimer >= _timeToDisplayFish)
        {
            _displayFishTimer = 0;
            _displayingFish = false;
            _caughtFishImageComponent.enabled = false;
            _textCaughtFishComponent.enabled = false;
        }
    }

    void CatchFish()
    {
        var fish = GlobalState.AllFish[Random.Range(0, 10 + GlobalState.CurrentLevel * 10)];

        _caughtFishImageComponent.overrideSprite = fish.Sprite;

        var newFishCaught = !GlobalState.UniqueFishAlreadyCaught(fish.Id);

        var newFishText = newFishCaught
            ? "\nNew fish!"
            : string.Empty;

        var textCaughtFish = $"You caught {fish.Name}!{newFishText}";
        _textCaughtFishComponent.text = textCaughtFish;

        _textCaughtFishComponent.enabled = true;
        _caughtFishImageComponent.enabled = true;
        _displayingFish = true;

        GlobalState.CurrentFishCount++;

        GlobalState.AllTimeTotalFishCaught++;

        if (newFishCaught)
        {
            GlobalState.AddUniqueFish(fish.Id);
        }
    }
}
