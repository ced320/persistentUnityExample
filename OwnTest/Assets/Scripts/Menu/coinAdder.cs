using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinAdder : MonoBehaviour
{
    GameManager gameManager; 
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCoin()
    {
        gameManager.SetCoins(gameManager.GetCoins() + 1);
    }
}
