using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    //set this as static
    public static PlayerController playerController;
    
    //initiate the player class
    public Player_Info[] playerInfo;
    
    //start
    void Awake()
    {
        
        //make static or destroy
        if (playerController == null)
        {
            DontDestroyOnLoad(gameObject);
            playerController = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
    [FormerlySerializedAs("myType")] public ClassManager.Class my;
    public bool jumpEnable;
}
