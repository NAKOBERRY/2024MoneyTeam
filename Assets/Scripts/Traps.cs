using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hurdle : MonoBehaviour
{
    Player player; // 플레이어 객체를 참조하기 위한 변수

    public float stunTime; // 스턴 시간이 저장될 변수
    private Coroutine stunCoroutine; // 현재 실행 중인 스턴 코루틴을 참조하기 위한 변수


    
    private void Update()
    {
        // 스페이스바가 눌렸을 때 stunTime을 0.1초 줄임
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stunTime = Mathf.Max(0, stunTime - 0.1f); // 스턴 시간이 0 이하로 내려가지 않도록 처리
        }
    }

    public void Stuns()
    {
        if (stunCoroutine != null)
        {
            StopCoroutine(stunCoroutine); // 이미 실행 중인 스턴 코루틴이 있으면 중지
        }
        stunCoroutine = StartCoroutine(StunCoroutine()); // 새로운 스턴 코루틴 시작
    }

    private IEnumerator StunCoroutine()
    {
        float playerSpeedTemp = player.speed; // 현재 플레이어 속도를 저장
        player.speed = 0; // 플레이어 속도를 0으로 설정

        yield return new WaitForSeconds(stunTime); // stunTime 동안 대기

        player.speed = playerSpeedTemp; // 플레이어 속도를 원래 속도로 복원
        stunCoroutine = null; // 코루틴이 완료되었으므로 stunCoroutine 변수 초기화
    }
}
