using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class GlobalState
{
    private const string GameDataFileName = "GameData.json";
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

        SaveGameState();
    }

    public static int TotalUniqueFishCaught => _gameData.UniqueFishCaught.Count;

    public static int FishingSkill
    {
        get => _gameData.FishingSkill;
        set
        {
            _gameData.FishingSkill = value;
            SaveGameState();
        }
    }

    public static int FishingSkillUpgradeCost => FishingSkill + 1;
    public static float TimeToCatchFish => 10f - FishingSkill * 0.1f;
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
}
