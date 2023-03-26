using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  enum GameState
{
    Pause,Playing,Fail,Win
}


public class GameManager : MonoBehaviour
{
    public static GameState gameState = GameState.Pause;


    public int score;

   


    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Pause;

    }

    // Update is called once per frame
    void Update()
    {
        print(gameState);
    }
}
