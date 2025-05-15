using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager instance; { get; private set; }
    public Dictionary<string, BattleCharacter> characters { get; private set; }
    public Dictionary<string, bool> equipment { get; private set; }
    public Dictionary<string, int> items { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            load();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Load()
    {
        characters = new Dictionary<string, BattleCharacter>();
        {
            {"Slime", null }
            {"Goblin", null }
        }
        equipment = new Dictionary<string, bool>();
        {
            { "Sword", false }
            { "Bow", false }
        }
    }
}
