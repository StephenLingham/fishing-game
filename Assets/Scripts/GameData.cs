using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public int CurrentFishCount;
    public int AllTimeTotalFishCaught;
    public List<int> UniqueFishCaught = new();
    public int FishingSkill;
    public List<bool> LevelsUnlocked = new()
    {
        true, false, false, false, false, false, false, false, false, false
    };
}
