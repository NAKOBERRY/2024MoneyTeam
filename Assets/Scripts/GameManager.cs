using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //미니게임 클리어 횟수
    public int clearMinigameCount = 0;
    //0번 클리어했을떄의 미니게임 시간
    public float minigameTimeStart = 4;
    //미니게임 시간의 한계치
    public float minigameTimeLimit = 1;
    //현재 미니게임 시간
    private float currMinigameMaxTime;
    //0.1씩 감소되는 미니게임 실시간 플레이타임
    private float currMinigameTime;

    public bool isMinigaming = false;
    private void Awake()
    {
        currMinigameMaxTime = minigameTimeStart;
    }
    private void Update()
    {
        if (isMinigaming == true)
        {
            currMinigameTime--;
        }
        else
        {
            currMinigameTime = currMinigameMaxTime;
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
        if (currMinigameMaxTime > minigameTimeLimit)
        {
            currMinigameMaxTime -= 0.1f;
            isMinigaming = false;
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
