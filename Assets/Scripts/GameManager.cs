using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�̴ϰ��� Ŭ���� Ƚ��
    public int clearMinigameCount = 0;
    //0�� Ŭ������������ �̴ϰ��� �ð�
    public float minigameTimeStart = 4;
    //�̴ϰ��� �ð��� �Ѱ�ġ
    public float minigameTimeLimit = 1;
    //���� �̴ϰ��� �ð�
    private float currMinigameMaxTime;
    //0.1�� ���ҵǴ� �̴ϰ��� �ǽð� �÷���Ÿ��
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
        //����
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
