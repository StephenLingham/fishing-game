using UnityEngine;
using UnityEngine.UI;

public class FishCatching : MonoBehaviour
{
    private float _timeToCatchFish = 5;
    private float _fishCatchingTimer = 0;

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

        var displayText = $"Time till next fish: {_timeToCatchFish - _fishCatchingTimer:0.0}";

        DisplayText.GetComponent<Text>().text = displayText;
    }

    void CatchFish()
    {
        // Debug.Log("Caught fish");

        GlobalState.NumberOfFish++;

        CaughtFishImage.GetComponent<Image>().overrideSprite = FishImages.GetComponent<FishImages>().Image1;
    }
}
