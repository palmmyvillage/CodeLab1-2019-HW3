using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //set this to be static
    public static ScoreManager scoreManager;
    
    //initiate the class
    public Player_Score[] playerScore;

    void Awake()
    {
        scoreManager = this;
    }

}

[System.Serializable]
//set up score for each player
public class Player_Score
{
    public string name;
    public int score;
}