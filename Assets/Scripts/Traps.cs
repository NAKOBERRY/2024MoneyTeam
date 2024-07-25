using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hurdle : MonoBehaviour
{
    Player player; // �÷��̾� ��ü�� �����ϱ� ���� ����

    public float stunTime; // ���� �ð��� ����� ����
    private Coroutine stunCoroutine; // ���� ���� ���� ���� �ڷ�ƾ�� �����ϱ� ���� ����


    
    private void Update()
    {
        // �����̽��ٰ� ������ �� stunTime�� 0.1�� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stunTime = Mathf.Max(0, stunTime - 0.1f); // ���� �ð��� 0 ���Ϸ� �������� �ʵ��� ó��
        }
    }

    public void Stuns()
    {
        if (stunCoroutine != null)
        {
            StopCoroutine(stunCoroutine); // �̹� ���� ���� ���� �ڷ�ƾ�� ������ ����
        }
        stunCoroutine = StartCoroutine(StunCoroutine()); // ���ο� ���� �ڷ�ƾ ����
    }

    private IEnumerator StunCoroutine()
    {
        float playerSpeedTemp = player.speed; // ���� �÷��̾� �ӵ��� ����
        player.speed = 0; // �÷��̾� �ӵ��� 0���� ����

        yield return new WaitForSeconds(stunTime); // stunTime ���� ���

        player.speed = playerSpeedTemp; // �÷��̾� �ӵ��� ���� �ӵ��� ����
        stunCoroutine = null; // �ڷ�ƾ�� �Ϸ�Ǿ����Ƿ� stunCoroutine ���� �ʱ�ȭ
    }
}
