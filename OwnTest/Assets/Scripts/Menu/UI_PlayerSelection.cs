using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class UI_PlayerSelection : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionsDropdown;

    private string[] players;
    private List<string> filteredResolutions;
    //private playerSelectedIndex = 0;
    //private string selectedPlayer = "init";
    private bool changedNumberOfExistingPlayers = true;
    GameManager gameManager; 
    [SerializeField] private InputField createPlayerInputField;
    [SerializeField] private InputField deletePlayerInputField;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();
        players = gameManager.GetAllPlayers();
        resolutionsDropdown.ClearOptions();
    }

    //IMPORTANT this is the method that calls all other methods to set a player
    public void SetPlayer() 
    {
        
        if(resolutionsDropdown.value < GameManager.GetInstance().GetAllPlayers().Length)
        {
            GameManager.GetInstance().SelectPlayer(players[resolutionsDropdown.value]);
        }
    }

    //IMPORTANT this is the method that calls all other methods to create a player
    public void CreateNewPlayer() 
    {
        if(createPlayerInputField.text == "") return;
        GameManager.GetInstance().ExternCreationOfPlayer(createPlayerInputField.text);
        createPlayerInputField.text = "";
        UpdateUI();
    } 

    //IMPORTANT this is the method that calls all other methods to delete a player
    public void DeletePlayer() 
    {
        if(deletePlayerInputField.text == "") return;
        GameManager.GetInstance().ExeternDeletionOfPlayer(deletePlayerInputField.text);
        deletePlayerInputField.text = "";
        UpdateUI();
    }



    public void UpdateUI() 
    {
        changedNumberOfExistingPlayers = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (changedNumberOfExistingPlayers) 
        {
            players = GameManager.GetInstance().GetAllPlayers();
            if(players.Length > 0) 
            {
                //Add list to dropdown
                resolutionsDropdown.ClearOptions();
                resolutionsDropdown.AddOptions(players.ToList());
                resolutionsDropdown.value = 0;
                resolutionsDropdown.RefreshShownValue();
                SetPlayer(); 
                changedNumberOfExistingPlayers = false;
            } 
        }
    }
}
