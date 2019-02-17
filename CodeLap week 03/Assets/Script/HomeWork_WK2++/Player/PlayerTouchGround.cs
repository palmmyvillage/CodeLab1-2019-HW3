using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchGround : MonoBehaviour
{
    //set Type for what number of player this object is
    private Player_Info[] player;
    
    //set number to take reference
    public int playerNumber;
    
    //start
    void Start()
    {
        //set it so it's easier to mention player
        player = PlayerDatabase.playerDatabase.playerInfo;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            player[playerNumber - 1].jumpEnable = true;
        }
    }//check when collisionEnter to toggle enableJump every time

    public void OnCollisionStay2D(Collision2D other) //check collisionStay to enable jump in PlayerController
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            player[playerNumber - 1].jumpEnable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) //check collisionExit to disable jump in PlayerController
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            player[playerNumber - 1].jumpEnable = false;
        }
    }
}
