using UnityEngine;
using UnityEngine.UI;

public class FishCatching : MonoBehaviour
{
    private float _timeToCatchFish = 3;
    private float _fishCatchingTimer = 0;

    private float _timeToDisplayFish = 1.5f;
    private float _displayFishTimer = 0;
    private bool _displayingFish = false;

    public Transform CaughtFishImage;
    public Transform FishImages;
    public Transform DisplayText;
    public Transform TextCaughtFish;

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
        GlobalState.CurrentFishCaught++;
        GlobalState.TotalFishCaught++;

        Debug.Log("All fish count: " + GlobalState.AllFish.Count);

        var fishCaught = GlobalState.AllFish[Random.Range(0, GlobalState.AllFish.Count)];

        Debug.Log("Fish ID: " + fishCaught.Id);

        //CaughtFishImage.GetComponent<Image>().overrideSprite = FishImages.GetComponent<FishImages>().Image1;
        CaughtFishImage.GetComponent<Image>().overrideSprite = fishCaught.Sprite;

        TextCaughtFish.GetComponent<Text>().text = $"You caught {fishCaught.Name}!";

        CaughtFishImage.GetComponent<Image>().enabled = true;
        _displayingFish = true;
    }
}
