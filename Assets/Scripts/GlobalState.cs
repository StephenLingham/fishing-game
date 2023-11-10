using System.Collections.Generic;
using UnityEngine;

public static class GlobalState
{
    public static int CurrentFishCount
    {
        get
        {
            return PlayerPrefs.GetInt(nameof(CurrentFishCount), 0);
        }
        set
        {
            PlayerPrefs.SetInt(nameof(CurrentFishCount), value);
        }
    }

    public static int AllTimeTotalFishCaught { get; set; }
    public static HashSet<int> UniqueFishCaught { get; } = new();
    public static List<Fish> AllFish { get; } = new();
    public static int FishingSkill { get; set; } = 1;
    public static int FishingSkillUpgradeCost => FishingSkill;
    public static float TimeToCatchFish => 10f - (FishingSkill - 1) * 0.1f;
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
}
