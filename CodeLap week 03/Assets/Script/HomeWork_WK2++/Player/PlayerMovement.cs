using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   //initiate the player class
    private Player_Info[] player;
    private Class_Info[] Class;

    // Start is called before the first frame update
    void Start()
    {
        //ini each classArray
        player = PlayerController.playerController.playerInfo;
        Class = ClassManager.classManager.classInfo;
        
        //add Gravity
        //use for so that it apply to any number of players
        for (int i = 0; i < player.Length; i++)
        {
            playerGravity(i);
            playerRotation(i);
        }
    }

    // Update is called once per frame
    void Update()
    {        
        //add Abilities to Run and Jump
        //use for so that it apply to any number of players
        for (int i = 0; i < player.Length; i++)
        {
            playerRunning(i);
            playerJumping(i);
        }
    }

    //set function to move each player with force
    public void playerRunning(int playerNumber) //set how player run
    {
        // set updated speed
        float xSpeed = player[playerNumber].rigidBody.velocity.x;
        float ySpeed = player[playerNumber].rigidBody.velocity.y;
        
        //set xLimit to use
        float xSpeedLimit = Class[player[playerNumber].chosenClasses].runningLimit;

        //force will always add to player
        Vector2 newForce = new Vector2();

        //Horizontal movement
        if (Input.GetKey(player[playerNumber].Left)) //move left
        {
            newForce.x -= Class[player[playerNumber].chosenClasses].runningForce;
        }

        if (Input.GetKey(player[playerNumber].Right)) //move right
        {
            newForce.x += Class[player[playerNumber].chosenClasses].runningForce;
        }

        //set limitSpeed to moving Horizontal
        if (xSpeed >= xSpeedLimit)
        {
            player[playerNumber].rigidBody.velocity = new Vector2(xSpeedLimit, ySpeed);
        }
        else if (xSpeed <= -xSpeedLimit)
        {
            player[playerNumber].rigidBody.velocity = new Vector2(-xSpeedLimit, ySpeed);
        }

        // add new force to object to move
        player[playerNumber].rigidBody.AddForce(newForce);
    }

    public void playerGravity(int playerNumber) //set how player affected by gravity
    {
        //set new gravity
        float gravity = Class[player[playerNumber].chosenClasses].gravityInput;
        
        player[playerNumber].rigidBody.gravityScale = gravity;
    }

    public void playerJumping(int playerNumber) //set how player Jump
    {
        float xSpeed = player[playerNumber].rigidBody.velocity.x;
        float ySpeed = player[playerNumber].rigidBody.velocity.y;
        
        //set bool to use for this one
        bool jumpEnable = player[playerNumber].jumpEnable;
        KeyCode jumpButton = player[playerNumber].Up;

        //force will always add to player
        Vector2 newForce = new Vector2();

        //check if jump possible or not
        if (jumpEnable == true)
        {
            if (Input.GetKeyDown(jumpButton)) //jump
            {
                player[playerNumber].rigidBody.velocity = new Vector2(xSpeed,0);
                StartCoroutine(nullifyFalling(playerNumber));
            }
        }
    }

    public void playerRotation(int playerNumber) // set ability to rotate player
    {
        player[playerNumber].rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    
    IEnumerator nullifyFalling(int playerNumber) //nullify falling velocity before making A JUMP
    {
        yield return 0;
        //set jumpingInput
        float jumpInput = Class[player[playerNumber].chosenClasses].jumpingForce;
        
        //force will always add to player
        Vector2 newForce = new Vector2();
        
        newForce.y += jumpInput;
        player[playerNumber].rigidBody.AddForce(newForce);
    }
}
