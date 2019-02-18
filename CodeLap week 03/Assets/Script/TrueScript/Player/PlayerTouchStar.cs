using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchStar : MonoBehaviour
{   
    //set playerNumber
    public int playerNumber;
    
    //set system manager to check gameEnd
    public SystemManager systemManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            Destroy(other.gameObject); //destroy star
            ScoreManager.scoreManager.playerScore[playerNumber - 1].score += other.GetComponent<StarScore>().score; //add score
            StarSpawner.starSpawner.spawnStar(); //spawn new star
            
            systemManager.gameEnd(); //check if gameEnd
        }
    }
}
