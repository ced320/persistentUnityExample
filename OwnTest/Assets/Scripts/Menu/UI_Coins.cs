using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Coins : MonoBehaviour
{
    public TextMeshProUGUI output;
    public TextMeshProUGUI selectedPlayer;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();
        output.text = "Init";
    }

    // Update is called once per frame
    void Update()
    {
        output.text = "Coins: " + gameManager.GetCoins();
        selectedPlayer.text = gameManager.GetSelectedPlayerName();
    }
}
