﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //set this as static
    public static PlayerController playerController;
    
    //initiate the player class
    public Player_Info[] playerInfo;
    
    //start
    void Awake()
    {
        playerController = this;
    }
}

[System.Serializable]
//set up player class to assign button and statistic
public class Player_Info
{
    public string name;
    public Rigidbody2D rigidBody;
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;
    public int chosenClasses;
    public bool jumpEnable;
}
