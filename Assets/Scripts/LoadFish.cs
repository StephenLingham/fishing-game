using UnityEngine;

public class LoadFish : MonoBehaviour
{
    public void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            var fish = new Fish
            {
                Id = i,
                Name = GlobalState.FishNames[i],
                //Sprite = Resources.Load<Sprite>($"Images/Fish/{i + 1}")
                Sprite = Resources.Load<Sprite>($"4")
            };

            GlobalState.AllFish.Add(fish);
        }
    }
}
