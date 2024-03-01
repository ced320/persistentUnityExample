using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Dictionary<string, int> playerWithCoins = new Dictionary<string, int>();
    public Dictionary<string, string[]> playerWithPlanes = new Dictionary<string, string[]>();
    public List<string> allPlayers = new List<string>();

    public string name;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData() 
    {
        this.playerWithCoins = new Dictionary<string, int>();
        this.allPlayers = new List<string>();
        this.playerWithPlanes = new Dictionary<string, string[]>();
    }
}