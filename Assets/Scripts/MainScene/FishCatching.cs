using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishCatching : MonoBehaviour
{
    private float _fishCatchingTimer = 0;

    private readonly float _timeToDisplayFish = 2;
    private float _displayFishTimer = 0;
    private bool _displayingFish = false;

    public Transform CaughtFishImage;
    public TMP_Text TimeTillNextFishText;
    public TMP_Text CaughtFishText;
    //public Transform TextCaughtFish;
    public Transform UniqueFishText;

    //private Text _textCaughtFishComponent;
    private Image _caughtFishImageComponent;
    private Text _uniqueFishTextComponent;

    public ParticleSystem StarParticles1;
    public ParticleSystem StarParticles2;
    public ParticleSystem StarParticles3;

    private void Start()
    {
        //_textCaughtFishComponent = TextCaughtFish.GetComponent<Text>();
        _caughtFishImageComponent = CaughtFishImage.GetComponent<Image>();
        _uniqueFishTextComponent = UniqueFishText.GetComponent<Text>();
    }

    void Update()
    {
        GlobalState.TimeSpentFishing += Time.deltaTime;

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
        var uniqueFishText = $"Unique fish caught from this level: {GlobalState.NumberOfUniqueFishCaughtThisLevel} out of {10}";

        _uniqueFishTextComponent.text = uniqueFishText;
    }

    private void UpdateTimeTillNextFishText()
    {
        var timeTillNextFishDisplayText = $"Time till next fish: {_fishCatchingTimer:0.0} / {GlobalState.TimeToCatchFish}";

        TimeTillNextFishText.text = timeTillNextFishDisplayText;
    }

    void UpdateDisplayingFish()
    {
        if (!_displayingFish || GlobalState.TimeToCatchFish <= _timeToDisplayFish)
        {
            return;
        }

        _displayFishTimer += Time.deltaTime;

        if (_displayFishTimer >= _timeToDisplayFish)
        {
            _displayFishTimer = 0;
            _displayingFish = false;
            _caughtFishImageComponent.enabled = false;
            CaughtFishText.enabled = false;
            StopNewFishCaughtParticles();
        }
    }

    void CatchFish()
    {
        var fish = GlobalState.AllFish[Random.Range(0, 10 + GlobalState.CurrentLevel * 10)];

        _caughtFishImageComponent.overrideSprite = fish.Sprite;

        var newFishCaught = !GlobalState.UniqueFishAlreadyCaught(fish.Id);

        if (newFishCaught)
        {
            PlayNewFishCaughtParticles();
        }
        else
        {
            StopNewFishCaughtParticles();
        }

        var newFishText = newFishCaught
            ? "\nNew fish!"
            : string.Empty;

        var textCaughtFish = $"You caught {fish.Name}!{newFishText}";
        CaughtFishText.text = textCaughtFish;

        CaughtFishText.enabled = true;
        _caughtFishImageComponent.enabled = true;
        _displayingFish = true;

        GlobalState.CurrentFishCount++;

        GlobalState.AllTimeTotalFishCaught++;

        if (newFishCaught)
        {
            GlobalState.AddUniqueFish(fish.Id);
        }
    }

    private void PlayNewFishCaughtParticles()
    {
        StarParticles1.Play();
        StarParticles2.Play();
        StarParticles3.Play();
    }

    private void StopNewFishCaughtParticles()
    {
        StarParticles1.Stop();
        StarParticles2.Stop();
        StarParticles3.Stop();
    }
}
