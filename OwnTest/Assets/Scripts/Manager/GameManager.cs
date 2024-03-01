using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IDataPersistence
{
    
    private Dictionary<string, int> playerWithCoins = new Dictionary<string, int>();
    private Dictionary<string, string[]> playerWithPlanes = new Dictionary<string, string[]>();
    private List<string> allPlayers = new List<string>();
    private string selectedPlayer = "init";
    private int coins = 65;
    private string[] planes = {};
    // Start is called before the first frame update

    public static GameManager GetInstance()
    {
        return GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        string[] tempPlanes1 = {"A320, Boing737"};
        string[] tempPlanes2 = {"A380, Boing707"};
        AddPlayer("Nele", 23, tempPlanes1);
        AddPlayer("Tina", 19, tempPlanes2);
    }

    public void LoadData(GameData data)
    {
        this.allPlayers = data.allPlayers;
        this.playerWithCoins = data.playerWithCoins;
        this.playerWithPlanes = data.playerWithPlanes;
    }

    public void SaveData(GameData data)
    {
        data.allPlayers = this.allPlayers;
        data.playerWithCoins = this.playerWithCoins;
        data.playerWithPlanes = this.playerWithPlanes;
    }

    public bool SelectPlayer(string name) 
    {
        if(allPlayers.Contains(name))
        {
            //Save values for old player
            SavePlayerStats(selectedPlayer);
            //Set values for new player
            return LoadPlayerStats(name);
        }
        Debug.Log("Could not select player. Because player does not exist");
        return false;
    }

    private void SavePlayerStats(string name) 
    {
        if(playerWithCoins.ContainsKey(name))
        {
            playerWithCoins[name] = coins; 
            playerWithPlanes[name] = planes;          
        }
    }

    private bool LoadPlayerStats(string name) 
    {
        if(playerWithCoins.ContainsKey(name) && playerWithPlanes.ContainsKey(name))
        {
            selectedPlayer = name;
            coins = playerWithCoins[name];
            planes = playerWithPlanes[name];
            return true;
        }
        Debug.Log("Could not select player 2. Because player does not exist");
        return false;
    }

    public bool ExternCreationOfPlayer(string name) 
    {

        return AddPlayer(name,0, new string[0]);
    }

    public void ExeternDeletionOfPlayer(string name)
    {
        RemovePlayer(name);
    }

    private bool AddPlayer(string name, int coins, string[] ownedPlanes) 
    {
        if(allPlayers.Contains(name))
        {
            Debug.Log("Could not add player. Because player already exists");
            return false;
        }
        allPlayers.Add(name);
        playerWithCoins.Add(name, coins);
        playerWithPlanes.Add(name, ownedPlanes);
        return true;
    }

    private void RemovePlayer(string name) 
    {
        if(allPlayers.Contains(name))
        {
            allPlayers.Remove(name);
        }
        if(playerWithCoins.ContainsKey(name))
        {
           playerWithCoins.Remove(name); 
        }
        if(playerWithPlanes.ContainsKey(name))
        {
            playerWithPlanes.Remove(name);
        }
    }

    public string[] GetAllPlayers() 
    {
        List<string> keyList = new List<string>(this.playerWithCoins.Keys);
        return keyList.ToArray();
    }

    public int GetCoins() 
    {
        return coins;
    }

    public void SetCoins(int coins)
    {
        this.coins = coins;
        if (playerWithCoins.ContainsKey(selectedPlayer))
        {
            playerWithCoins[selectedPlayer] = coins;
        }
    }

    public string GetSelectedPlayerName()
    {
        return selectedPlayer;
    }

    public string[] GetAvaiblePlanesForPlayer() 
    {
        return planes;
    }

    public void SetAvaiblePlanesForPlayer(string[] newListWithPlanes) 
    {
        this.planes = newListWithPlanes;
        if (playerWithCoins.ContainsKey(selectedPlayer))
        {
            this.playerWithPlanes[selectedPlayer] = newListWithPlanes;
        }
    }


}
