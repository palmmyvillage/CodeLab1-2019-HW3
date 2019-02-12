﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemScoreUI : MonoBehaviour
{
    //set variable to store Player's ScoreText
    public Text Player1Point;
    public Text Player2Point;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreController();
    }
    
    public void ScoreController()
    {
        Player1Point.text = "Player1 : " + ScoreManager.scoreManager.playerScore[0].score;
        Player2Point.text = "Player2 : " + ScoreManager.scoreManager.playerScore[1].score;
    }
}
