using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class IdeaGenerator : MonoBehaviour
{
    //public
    public GameObject outputObject;
    public TMP_Dropdown modelMenu;
    public TMP_Dropdown difficultyMenu;

    //private
    private bool difficultySet = false;
    private int maximumDifficulty;
    private string idea = "";
    private string error = "Error: Difficulty has not been set.";

    //lists of inputs
    List<string> models = new List<string>()
    {
        "a door",
        "a chair",
        "a bed",
        "a dinnertable",
        "a throne",
        "a small container",
        "a melee weapon",
        "a ranged weapon",
        "a light",
        "a car",
        "a hat",
        "an instrument",
        "a statue",
        "a machine",
        "a spaceship",
        "a boiler",
        "a tree",
        "a robot",
        "a vase",
        "a cart",
        "a closet/wardrobe",
        "a train/tram/metro",
        "a treasurechest",
        "a chandelier",
        "a boat",
        "an aircraft",
        "a billboard/sign",
        "a streetlight",
        "a motorcycle"
    };
    List<string> locs = new List<string>()
    {
        "in East-Europe",
        "in West-Europe",
        "in England",
        "in North America",
        "in South America",
        "in Northern Africa",
        "in Southern Africa",
        "in Middle East",
        "in India",
        "in China",
        "in Japan",
        "on Mars",
        "on The Moon"
    };
    List<string> times = new List<string>()
    {
        "classic era",
        "early Middle Ages",
        "late Middle Ages",
        "Rennaissance",
        "Victorian era",
        "early industrial era",
        "First World War",
        "Second World War",
        "80s",
        "modern era",
        "nearby future",
        "technologocially advanced future",
        "post-apocalyptic future",
        "dystopian future"
    };
    List<string> moods = new List<string>()
    {
        "psychedelic ",
        "somber ",
        "creepy ",
        "joyful ",
        "humerous ",
        "mysterious ",
        "ominous ",
        "calm ",
        "lonely ",
        "chaotic ",
        "romantic ",
        "wholesome ",
        "dreamy ",
        "peaceful ",
        "silly ",
        "depressed "
    };
    List<string> styles = new List<string>()
    {
        "photo-realistic","photo-realistic","photo-realistic","photo-realistic",
        "saturated realistic","saturated realistic",
        "angular low poly",
        "round low poly",
        "minimalism","minimalism",
        "wind waker",
        "borderlands"
    };
    List<string> creatures = new List<string>()
    {
        "an arachnoid",
        "an ape",
        "a troll",
        "a cyclops",
        "a dragon/wyvern",
        "a golem",
        "a gremlin",
        "a kraken",
        "a hydra",
        "an orc",
        "a horse",
        "a satyr/faun",
        "a pegasus",
        "a phoenix",
        "a griffin",
        "a minotaur",
        "a hellhound",
        "a werewolf",
        "a centaur",
        "a yeti",
        "a naga"
    };
    List<string> fPlaces = new List<string>()
    {
        "in an elven kingdom",
        "in an orc city",
        "in an orc encampment",
        "in a dwarven city",
        "in a dwarven mine",
        "in a wizard tower",
        "in a legendary ruin",
        "in a fantasy castle",
        "in a hellish landscape",
    };
    List<string> places = new List<string>()
    {
        "in a dense forest",
        "on snowy mountains",
        "in a desert",
        "on an island",
        "in a city",
        "on a grass plane",
        "in a cave",
        "in the sky",
        "in outer space",
        "on an alien planet",
        "beside a cliff",
        "nearby a waterfall",
        "at the foot of a giant tree",
        "in a hole in the ground",
        "in a rainforest",
        "in a savanna",
        "in a tundra",
        "in a marsh",
        "by a lake",
        "by the sea"
    };
    List<string> characters = new List<string>()
    {
        "a soldier",
        "a hero",
        "an upset child",
        "an adventurer",
        "a salesman",
        "an angel",
        "a jester",
        "an assassin",
        "a lost child",
        "a warrior",
        "a hunter",
        "an elderly person",
        "a sportsman",
        "a superhero",
        "the heir to the throne",
        "a lonely ruler",
        "a member of the maffia",
        "a peasant",
        "the leader of a tribe",
        "a sorcerer",
        "a druid",
        "a hermit"
    };
    List<string> creationWords = new List<string>()
    {
        "Make",
        "Create",
        "Design",
        "Try making",
        "Try creating",
        "Try designing"
    };

    //lists to filter by
    List<string> noIndustryTimes = new List<string>()
    {
        "classic era",
        "early Middle Ages",
        "late Middle Ages",
    };
    List<string> noTechTimes = new List<string>()
    {
        "classic era",
        "early Middle Ages",
        "late Middle Ages",
        "Rennaissance",
        "Victorian era"
    };
    List<string> noAdvancedTechTimes = new List<string>()
    {
        "classic era",
        "early Middle Ages",
        "late Middle Ages",
        "Rennaissance",
        "Victorian era",
        "early industrial era",
        "First World War",
        "Second World War",
        "80s"
    };
    List<string> spaceLocs = new List<string>()
    {
        "on Mars",
        "on The Moon"
    };
    List<string> strangePlaces = new List<string>()
    {
        "in the sky",
        "in outer space",
        "in a hole in the ground"
    };

    List<string> noStrangePlacesModels = new List<string>()
    {
        "a machine",
        "a spaceship",
        "a robot",
        "an aircraft"
    };
    List<string> noFantModels = new List<string>()
    {
        "a car",
        "a spaceship",
        "a boiler",
        "a machine",
        "a robot",
        "a train/tram/metro",
        "a boat",
        "an aircraft",
        "a streetlight",
        "a motorcycle"
    };
    List<string> noTechTimesModels = new List<string>()
    {
        "a car",
        "a machine",
        "a boiler",
        "a train/tram/metro",
        "a boat",
        "an aircraft",
        "a streetlight",
        "a motorcycle"
    };
    List<string> noSpaceModels = new List<string>()
    {
        "a boat",
        "a tree",
        "a vase",
        "a train/tram/metro",
        "a cart",
        "a chandelier"
    };

    //empty lists, to be filled after filtering by difficulty
    List<string> filteredModels = new List<string>() { };
    List<string> filteredCreatures = new List<string>() { };
    List<string> filteredCharacters = new List<string>() { };
    List<string> filteredFantModels = new List<string>() { };

    List<string> templates = new List<string>() { };

    //dictionaries with combofilter and difficultyfilters
    Dictionary<string, List<string>> filters = new Dictionary<string, List<string>>();
    Dictionary<string, int> modelsDifficulty = new Dictionary<string, int>();
    Dictionary<string, int> creaturesDifficulty = new Dictionary<string, int>();
    Dictionary<string, int> charactersDifficulty = new Dictionary<string, int>();
    Dictionary<string, int> modelsFantDifficulty = new Dictionary<string, int>();

    void Start() {
        //filling the combofilter dictionary
        foreach (string model in models.Concat(creatures).Concat(characters)) {
            filters.Add($"{model}-location", locs);
            filters.Add($"{model}-time", times);
            filters.Add($"{model}-fPlace", fPlaces);
            filters.Add($"{model}-place", places); }

        foreach(string model in noTechTimesModels) {
            filters[$"{model}-time"] = Filter(noTechTimes, times); }

        foreach (string model in noStrangePlacesModels) {
            filters[$"{model}-place"] = Filter(strangePlaces, places); }

        foreach(string model in noSpaceModels) {
            filters[$"{model}-location"] = Filter(spaceLocs, locs); }

        filters["a spaceship-time"] = Filter(noAdvancedTechTimes, times);
        filters["a robot-time"] = Filter(noAdvancedTechTimes, times);
        filters["a chandelier-time"] = Filter(noIndustryTimes, times);

        //filling the difficultyfilters
        foreach (string model in models) {
            modelsDifficulty.Add($"{model}", 1); }

        foreach (string model in creatures) {
            creaturesDifficulty.Add($"{model}", 2); }

        foreach (string model in characters) {
            charactersDifficulty.Add($"{model}", 3); }

        modelsDifficulty["a car"] = 2;
        modelsDifficulty["a motorcycle"] = 2;
        modelsDifficulty["a spaceship"] = 3;
        modelsDifficulty["a tree"] = 2;
        modelsDifficulty["a robot"] = 2;
        modelsDifficulty["a train/tram/metro"] = 2;
        modelsDifficulty["a chandelier"] = 2;
        modelsDifficulty["a boat"] = 2;
        modelsDifficulty["an aircraft"] = 2;

        modelsFantDifficulty = modelsDifficulty;

        creaturesDifficulty["a dragon/wyvern"] = 3;
        creaturesDifficulty["a kraken"] = 3;
        creaturesDifficulty["a hydra"] = 3;
        creaturesDifficulty["a pegasus"] = 3;
        creaturesDifficulty["a griffin"] = 3;
        creaturesDifficulty["a phoenix"] = 3;
    }

    public void Generate() {
        //check if the dropdown difficulty has been selected
        if(difficultySet == true) {
            //checking models settings
            Models_IndexChanged();

            //creating instance of templates list
            List<string> templatesInstance = templates;

            //filtering by set difficulty
            filteredModels = DifficultyFinder(modelsDifficulty);

            filteredFantModels = DifficultyFinder(modelsFantDifficulty);

            for (int i = 0; i < noFantModels.Count; i++) {
                filteredFantModels.Remove(noFantModels[i]); }

            filteredCreatures = DifficultyFinder(creaturesDifficulty);

            if (!filteredCreatures.Any())
                templatesInstance.Remove("creature");

            filteredCharacters = DifficultyFinder(charactersDifficulty);

            if (!filteredCharacters.Any())
                templatesInstance.Remove("character");

            //selecting random template and starting word
            var template = RanInd(templatesInstance);
            var firstWord = RanInd(creationWords);

            //0.7 chance of no mood
            bool randBool = (Random.value > 0.7f);
            List<string> maybeMoods = new List<string>() { };

            if (randBool == true)
                maybeMoods = moods;

            //filling templates
            if (template == "humanObject") {
                var model = RanInd(filteredModels);
                var locFilter = filters[$"{model}-location"];
                var timeFilter = filters[$"{model}-time"];
                if (Random.value > 0.5f)
                    locFilter = filters[$"{model}-place"];

                idea = $"{firstWord} {model} set {RanInd(locFilter)} in the {RanInd(timeFilter)} in a {RanInd(maybeMoods)}{RanInd(styles)} style.";
            }
            else if (template == "creature") {
                var model = RanInd(filteredCreatures);
                var locFilter = filters[$"{model}-place"];
                if (Random.value > 0.5f)
                    locFilter = filters[$"{model}-fPlace"];

                idea = $"{firstWord} {model} living {RanInd(locFilter)} in a {RanInd(maybeMoods)}{RanInd(styles)} style.";
            }
            else if (template == "alienObject") {
                var model = RanInd(filteredFantModels);
                var locFilter = filters[$"{model}-fPlace"];

                idea = $"{firstWord} {model} set {RanInd(locFilter)} in a {RanInd(maybeMoods)}{RanInd(styles)} style.";
            }
            else if (template == "character") {
                var model = RanInd(filteredCharacters);
                var locFilter = filters[$"{model}-location"];
                int randPlace = Random.Range(0, 3);
                if (randPlace == 0)
                    locFilter = filters[$"{model}-place"];
                else if (randPlace == 1)
                    locFilter = filters[$"{model}-fPlace"];

                idea = $"{firstWord} {model} living {RanInd(locFilter)} in a {RanInd(maybeMoods)}{RanInd(styles)} style.";
            }
            //output
            outputObject.GetComponent<TMP_Text>().text = idea;
        }
        else if (difficultySet == false) {
            //error message if difficulty has not been set
            outputObject.GetComponent<TMP_Text>().text = error;
        }
    }

    string RanInd(List<string> list) {
        //function to pick a random from list

        if (!list.Any())
            return "";
        else
            return list[Random.Range(0, list.Count)];
    }

    List<string> Filter(List<string> filter, List<string> list) {
        //function to remove one list from another and return as new list

        return list.Where(m => (filter.Any(r => r != m))).ToList();
    }

    List<string> DifficultyFinder(Dictionary<string, int> dictionary) {
        //function to filter a dictionary by integervalue and return as new list

        if(!dictionary.Any())
            return new List<string>() { };

        return dictionary.Where(t => t.Value <= maximumDifficulty).Select(t => t.Key).ToList();
    }

    public void Models_IndexChanged() {
        //update the templates on whether the dropdown has changed

        switch (modelMenu.value) {
            case 0:
                templates = new List<string>() {
                    "humanObject",
                    "creature",
                    "alienObject",
                    "character" };
                break;
            case 1:
                templates = new List<string>() {
                    "humanObject",
                    "alienObject" };
                break;
            case 2:
                templates = new List<string>() {
                    "creature" };
                break;
            case 3:
                templates = new List<string>() {
                    "character" };
                break;
        }
    }

    public void Difficulty_IndexChanged() {
        //update the difficultySetting if the dropdown has changed

        maximumDifficulty = difficultyMenu.value;

        if (difficultyMenu.value == 0)
            difficultySet = false;
        else
            difficultySet = true;
    }
}