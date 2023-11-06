using UnityEngine;

public class LoadFish : MonoBehaviour
{
    public void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            var fish = new Fish
            {
                Id = i,
                Name = GlobalState.FishNames[i],
                Sprite = Resources.Load<Sprite>($"Images/Fish/{i + 1}")
            };

            GlobalState.AllFish.Add(fish);
        }
    }
}
