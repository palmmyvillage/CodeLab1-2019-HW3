using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SystemController : MonoBehaviour
{
    //set this as static
    public static SystemController systemController;
    
    //set endGameButton
    public SystemButton systemGameButton;
    public WinnerTextColor[] winnerTextColor;
    
    //set state of pauseGame
    public bool pauseGame;
    public GameObject pausePanel;
    //set state to endGame
    public bool endGame;
    public GameObject endPanel;
    public Text winner;
    
    //awake is called right when scene loaded
    void Awake()
    {
        if (systemController == null)
        {
            DontDestroyOnLoad(gameObject);
            systemController = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //to initialize start
        pauseGame = false;
        endGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        //set to press pause
        pauseGameButtonDown();

        //set what happen in pauseGame
        if (pauseGame == true)
        {
            pauseGameOption();
        }
        
        //set what happen in endgame
        if (endGame == true)
        {
            endOption();
        }
    }

    // use this to set how to pressing pause
    public void pauseGameButtonDown()
    {
        //set to press pause
        if (Input.GetKeyDown(systemGameButton.pause))
        {
            if (pauseGame == false)
            {
                pauseGameEnter();
            }
            else
            {
                pauseGameExit();
            }
        }
    }

    //use this to enter pauseGame Option
    public void pauseGameEnter()
    {
        //this work only when endGame is not present
        if (endGame == false)
        {
            //set game state to pause
            pauseGame = true;
            //stop time
            Time.timeScale = 0.0f;
            //toggle pausePanel
            pausePanel.SetActive(!pausePanel.activeInHierarchy);
        }
    }
    
    //how pause option works
    public void pauseGameOption()
    {
        //press restart to restart
        if (Input.GetKeyDown(systemGameButton.restartGame))
        {
            SceneOrder.sceneOrder.GoToScene(SceneOrder.sceneOrder.sceneList.Menu); //restart scene
            StartGame.startMenu.enterMenu();
            Time.timeScale = 1.0f; //make time move on
        }
        
        //press qiuit to quit
        if (Input.GetKeyDown(systemGameButton.quit))
        {
            Application.Quit(); // closeGame
        }
    }
    
    //how to unpause
    public void pauseGameExit()
    {
        //this work only when endGame is not present
        if (endGame == false)
        {
            //set game state to pause
            pauseGame = false;
            //resume time
            Time.timeScale = 1.0f;
            //toggle pause game panel
            pausePanel.SetActive(!pausePanel.activeInHierarchy);
        }
    }
    
    //entering endGame
    public void endGameEnter()
    {
        //set endgameState
        endGame = true;
        
        //stop game
        Time.timeScale = 0.0f;
    }
    
    //how end work
    public void endOption()
    {
        //press restart to restart
        if (Input.GetKeyDown(systemGameButton.restartGame))
        {
            SceneOrder.sceneOrder.GoToScene(SceneOrder.sceneOrder.sceneList.Menu); //restart scene
            StartGame.startMenu.enterMenu();
            Time.timeScale = 1.0f; //make time move on
            endGame = false; // get out of endGameState
        }
        
        //press qiuit to quit
        if (Input.GetKeyDown(systemGameButton.quit))
        {
            Application.Quit(); // closeGame
        }
    }

    //use this to endGames when stars are all collected
    public void gameEnds()
    {
        {
            int P1score = ScoreManager.scoreManager.playerScore[0].currentScore;
            int P2score = ScoreManager.scoreManager.playerScore[1].currentScore;

            endPanel.SetActive(true);
            if (P1score > P2score)
            {
                endPanel.GetComponent<Image>().color = winnerTextColor[0].background;
                winner.text = winnerTextColor[0].name + " Win";
                winner.color = winnerTextColor[0].winningText;
            }
            else if (P1score < P2score)
            {
                endPanel.GetComponent<Image>().color = winnerTextColor[1].background;
                winner.text = winnerTextColor[1].name + " Win";
                winner.color = winnerTextColor[1].winningText;
            }
            else if (P1score == P2score)
            {
                endPanel.GetComponent<Image>().color = winnerTextColor[2].background;
                winner.text = "Draw";
                winner.color = winnerTextColor[2].winningText;
            }
            systemController.endGameEnter();
        }
    }
    
    
    
   //set this as state
}

[System.Serializable]
//set up player class to assign button
public class SystemButton
{
    public KeyCode pause;
    public KeyCode restartLevel;
    public KeyCode restartGame;
    public KeyCode quit;
}

[System.Serializable]
//set up color on text
public class WinnerTextColor
{
    public string name;
    public Color winningText;
    public Color background;
}

