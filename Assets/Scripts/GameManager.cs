using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; 

    Player player;    
    public int clearMinigameCount = 0;
    public float minigameTimeStart = 4;
    public float minigameTimeLimit = 1;
    private float currMinigameMaxTime=4;
    private float currMinigameTime=4;

    public bool isMinigaming = false;
    public float playerSpeedTemp;
    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<Player>();
        currMinigameMaxTime = minigameTimeStart;
    }
    private void Start()
    {
        currMinigameTime = currMinigameMaxTime;
        playerSpeedTemp = player.speed;
    }
    private void Update()
    {
        if (isMinigaming == true)
        {
            player.speed = 0;
            currMinigameTime -= 1f * Time.deltaTime;
        }
        else
        {
            currMinigameTime = currMinigameMaxTime;
            player.speed = playerSpeedTemp;
        }
        //½ÇÆÐ
        if (currMinigameTime <= 0)
        {
            GameOver();
        }
    }
    public void MinigameStart()
    {
        currMinigameTime = currMinigameMaxTime;
        isMinigaming = true;
    }
    public void ClearMinigame()
    {        
        clearMinigameCount++;
        isMinigaming = false;
        if (currMinigameMaxTime > minigameTimeLimit)
        {
            currMinigameMaxTime -= 0.1f;
        }     
    }
    public void GameOver()
    {
        Debug.Log("over");
    }
    public void GameClear(){
        if (clearMinigameCount > 20)
        {
            Debug.Log("clear");
        }
    }
}
