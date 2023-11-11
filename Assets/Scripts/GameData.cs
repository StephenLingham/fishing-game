using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public int CurrentFishCount;
    public int AllTimeTotalFishCaught;
    public List<int> UniqueFishCaught = new();
    public int FishingSkill = 1;
}
