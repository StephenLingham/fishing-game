using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class GlobalState
{
    private const decimal percentageOfUniqueFishNeededToUnlockNextLevel = 0.8m;
    private const string GameDataFileName = "GameData.json";
    public const int MaxFishingSkill = 90;
    private static GameData _gameData = new();

    public static int CurrentFishCount
    {
        get => _gameData.CurrentFishCount;
        set
        {
            _gameData.CurrentFishCount = value;
            SaveGameState();
        }
    }

    public static int AllTimeTotalFishCaught
    {
        get => _gameData.AllTimeTotalFishCaught;
        set
        {
            _gameData.AllTimeTotalFishCaught = value;
            SaveGameState();
        }
    }

    public static bool UniqueFishAlreadyCaught(int id)
    {
        return _gameData.UniqueFishCaught.Contains(id);
    }

    public static void AddUniqueFish(int id)
    {
        if (_gameData.UniqueFishCaught.Contains(id))
        {
            return;
        }

        _gameData.UniqueFishCaught.Add(id);

        UpdateLevelsUnlocked();

        UpdateNumberOfUniqueFishCaughtThisLevel();

        SaveGameState();
    }

    public static int TotalUniqueFishCaught => _gameData.UniqueFishCaught.Count;

    public static int NumberOfUniqueFishCaughtThisLevel { get; private set; } = 0;

    public static void UpdateNumberOfUniqueFishCaughtThisLevel()
    {
        var numberOfUniqueFishCaughtThisLevel = 0;

        var uniqueFishInLevel = UniqueFishInLevel(CurrentLevel);

        foreach (var fish in uniqueFishInLevel)
        {
            if (_gameData.UniqueFishCaught.Contains(fish))
            {
                numberOfUniqueFishCaughtThisLevel++;
            }
        }

        NumberOfUniqueFishCaughtThisLevel = numberOfUniqueFishCaughtThisLevel;
    }

    public static int FishingSkill
    {
        get => _gameData.FishingSkill;
        set
        {
            _gameData.FishingSkill = value;
            SaveGameState();
        }
    }

    public static int CurrentLevel = 0;
    public static int FishingSkillUpgradeCost => (FishingSkill / 3) + 1;
    public static float TimeToCatchFish => (float)(10m - FishingSkill * 0.1m);
    public static List<Fish> AllFish { get; } = new();
    public static List<string> FishNames { get; } = new()
    {
        "Aqualithor",
        "Oceandragon",
        "Sirensea",
        "Krakenscale",
        "Nauticus",
        "Draconfin",
        "Mermaidon",
        "Coralaura",
        "Leviathora",
        "Neptulos",
        "Aquarion",
        "Serpentide",
        "Marphoenix",
        "Thalassorax",
        "Lunara",
        "Drakorin",
        "Hydralore",
        "Spectrashoal",
        "Orichalmaiden",
        "Starfinix",
        "Tidaltalon",
        "Celestialfin",
        "Oceandream",
        "Quetzalquill",
        "Marvogale",
        "Oysterion",
        "Aquaticorn",
        "Coralisk",
        "Typhoonix",
        "Aurorafin",
        "Krystalith",
        "Celestion",
        "Nixolyte",
        "Tritonius",
        "Zephyrseal",
        "Quicksilverfin",
        "Nebulisk",
        "Orangetide",
        "Aquaraptor",
        "Bubblenova",
        "Nereidora",
        "Abyssaria",
        "Stardracona",
        "Meluseidon",
        "Aquastar",
        "Pearlyth",
        "Lagoonian",
        "Melufyre",
        "Dracoraqua",
        "Typhocean",
        "Chrysopiscis",
        "Nautiflame",
        "Corallion",
        "Seashimmer",
        "Echomara",
        "Glacianara",
        "Oceangazer",
        "Quetzalfin",
        "Zephyrserpent",
        "Lunarora",
        "Hydralune",
        "Coralfyre",
        "Marvocean",
        "Oceanigma",
        "Serpentora",
        "Aquanix",
        "Krakensong",
        "Atlantideus",
        "Orangeterra",
        "Celestigale",
        "Aquaradian",
        "Oceanebula",
        "Thundertail",
        "Leviosaur",
        "Serpentara",
        "Nixoluna",
        "Levithral",
        "Spectraflame",
        "Nautichroma",
        "Celestifire",
        "Quicksilvora",
        "Spectrasea",
        "Nebulith",
        "Stardracona",
        "Meluphira",
        "Hydradream",
        "Nephritail",
        "Quetzalora",
        "Tidalfire",
        "Nereiscale",
        "Drakarix",
        "Aquafyre",
        "Thalassorin",
        "Oceantaur",
        "Serenafin",
        "Nixomara",
        "Oceanara",
        "Aquarora",
        "Astrafin",
        "Mythrilfin"
    };

    private static void SaveGameState()
    {
        var json = JsonUtility.ToJson(_gameData);

        var fullFilePath = Path.Combine(Application.persistentDataPath, GameDataFileName);

        File.WriteAllText(fullFilePath, json);
    }

    public static void LoadGameState()
    {
        var fullFilePath = Path.Combine(Application.persistentDataPath, GameDataFileName);

        if (!File.Exists(fullFilePath))
        {
            return;
        }

        var json = File.ReadAllText(fullFilePath);

        _gameData = JsonUtility.FromJson<GameData>(json);
    }

    public static void UpdateLevelsUnlocked()
    {
        for (int i = 0; i < _gameData.LevelsUnlocked.Count; i++)
        {
            _gameData.LevelsUnlocked[i] = CalculateLevelUnlocked(i);
        }
    }

    public static bool LevelUnlocked(int level)
    {
        if (level < 0 || level >= _gameData.LevelsUnlocked.Count)
        {
            return false;
        }

        return _gameData.LevelsUnlocked[level];
    }

    private static bool CalculateLevelUnlocked(int level)
    {
        if (level == 0)
        {
            return true;
        }

        if (level > 9)
        {
            return false;
        }

        var uniqueFishInPreviousLevels = UniqueFishInPreviousLevels(level);

        var numberOfUniqueFish = uniqueFishInPreviousLevels.Count;
        var numberOfUniqueFishCaught = 0;

        foreach (var fish in uniqueFishInPreviousLevels)
        {
            if (_gameData.UniqueFishCaught.Contains(fish))
            {
                numberOfUniqueFishCaught++;
            }
        }

        var percentageOfUniqueFishCaught = (decimal)numberOfUniqueFishCaught / numberOfUniqueFish;

        var levelUnlocked = percentageOfUniqueFishCaught >= percentageOfUniqueFishNeededToUnlockNextLevel;

        return levelUnlocked;
    }

    private static List<int> UniqueFishInLevel(int level)
    {
        var firstFishIndexForLevel = level * 10;

        return Enumerable
            .Range(firstFishIndexForLevel, 10)
            .ToList();
    }

    private static List<int> UniqueFishInPreviousLevels(int level)
    {
        return Enumerable
            .Range(0, level * 10)
            .ToList();
    }
}
