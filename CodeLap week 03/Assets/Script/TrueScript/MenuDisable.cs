using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuDisable : MonoBehaviour
{      
      //set this as Static
      public static MenuDisable menuDisable;
      
      //set up player
      public GameObject player1;
      public GameObject player2;

      void Awake()
      {
            menuDisable = this;
      }
      
      //called at first frame
      private void Start()
      {
            DisablingFunction(); //do this when it called the first time
      }

      public void DisablingFunction()
      {
            StartCoroutine(Disabling());
      }

      public IEnumerator Disabling() //use this to disabling player's ability to move
      {
            yield return 0;
            if (SceneManager.GetActiveScene().name == SceneOrder.sceneOrder.sceneList.Menu)
            {
                  GetComponent<PlayerMovement>().enabled = false; //disable movement
                  
                  //disable players
                  player1.SetActive(false);
                  player2.SetActive(false);
            }
            else
            {
                  GetComponent<PlayerMovement>().enabled = true; //enable movement
                  
                  //enable players
                  player1.SetActive(true);
                  player2.SetActive(true);
            }
      }
}
