using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    protected GameManager _gameManager;
    protected PlayerMovement playerMove;
    public GameObject pauseCanvas;
    public GameObject playCanvas;
    public GameObject failCanvas;
    public GameObject winCanvas;
    public Text scoreText;


    private void Awake()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        pauseCanvas.SetActive(true);
        failCanvas.SetActive(false);
        winCanvas.SetActive(false);
    }

    private void Update()
    {
        switch (GameManager.gameState)
        {
            case GameState.Playing:
                pauseCanvas.SetActive(false);
                failCanvas.SetActive(false);
                winCanvas.SetActive(false);
                playCanvas.SetActive(true);
                scoreText.text = _gameManager.score.ToString();
                break;
            case GameState.Pause:
                pauseCanvas.SetActive(true);
                failCanvas.SetActive(false);
                winCanvas.SetActive(false);
                playCanvas.SetActive(false);
                break;
            case GameState.Fail:
                pauseCanvas.SetActive(false);
                failCanvas.SetActive(true);
                winCanvas.SetActive(false);
                playCanvas.SetActive(false);
                break;
            case GameState.Win:
                pauseCanvas.SetActive(false);
                failCanvas.SetActive(false);
                winCanvas.SetActive(true);
                playCanvas.SetActive(false);
                break;

        }
        
    }

    public void gameStart()
    {
        GameManager.gameState = GameState.Playing;
        playerMove.rb.isKinematic = false;
        playerMove.jump();
        playerMove.spin();
    }
    public void replay()
    {

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene, LoadSceneMode.Single);


    }
    public void nextLevel()
    {
        int nextSceneIndex = activeSceneIndex() + 1;
        int sceneIndex = SceneManager.sceneCountInBuildSettings - 1;


        if (nextSceneIndex <= sceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }

        if (nextSceneIndex > sceneIndex)
        {
            SceneManager.LoadScene(0);
        }

    }

    private int activeSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

}
