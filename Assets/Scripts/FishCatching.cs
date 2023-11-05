using UnityEngine;
using UnityEngine.UI;

public class FishCatching : MonoBehaviour
{
    private float _timeToCatchFish = 4;
    private float _fishCatchingTimer = 0;

    private float _timeToDisplayFish = 1.5f;
    private float _displayFishTimer = 0;
    private bool _displayingFish = false;

    public Transform CaughtFishImage;
    public Transform FishImages;
    public Transform DisplayText;

    void Update()
    {
        _fishCatchingTimer += Time.deltaTime;

        if (_fishCatchingTimer >= _timeToCatchFish)
        {
            _fishCatchingTimer = 0;

            CatchFish();
        }

        UpdateDisplayingFish();

        var displayText = $"Time till next fish: {_timeToCatchFish - _fishCatchingTimer:0.0}";

        DisplayText.GetComponent<Text>().text = displayText;
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
            CaughtFishImage.GetComponent<Image>().enabled = false;
        }
    }

    void CatchFish()
    {
        GlobalState.NumberOfFish++;

        CaughtFishImage.GetComponent<Image>().overrideSprite = FishImages.GetComponent<FishImages>().Image1;
        CaughtFishImage.GetComponent<Image>().enabled = true;
        _displayingFish = true;
    }
}
