using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Hurdle : MonoBehaviour
{
    Player player; // 플레이어 객체를 참조하기 위한 변수
    Rigidbody2D rigid;

    public string TrapName;
    public int xKnockBack;
    public int yKnockBack;
    public float slowTime;
    public float slowness;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        rigid = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }
    public void switchCase()
    {
        switch (TrapName)
        {
            case "Hurdle":
                KnockBack();
                break;
            case "Corn":
                StartCoroutine(Slow());
                break;
        }
    }

    private void KnockBack()
    {
        rigid.AddForce(new Vector2(-xKnockBack, yKnockBack), ForceMode2D.Impulse);
    }
    private IEnumerator Slow()
    {
        player.speed /= slowness;
        yield return new WaitForSeconds(slowTime);
        player.speed*=slowness;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switchCase();
        }
    }
}
