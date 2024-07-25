using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager instance; 

    Player player;
    Animator animator;
    //미니게임 클리어 횟수
    public int clearMinigameCount = 0;
    //0번 클리어했을떄의 미니게임 시간
    public float minigameTimeStart = 4;
    //미니게임 시간의 한계치
    public float minigameTimeLimit = 1;
    //현재 미니게임 시간
    private float currMinigameMaxTime=4;
    //0.1씩 감소되는 미니게임 실시간 플레이타임
    private float currMinigameTime=4;

    public bool isMinigaming = false;
    public float playerSpeedTemp;
    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
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
        //실패
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
