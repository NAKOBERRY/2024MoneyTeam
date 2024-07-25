using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Clone : MonoBehaviour
{
    Rigidbody2D rigid;
    Rigidbody2D p_rigid;
    Player player;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        p_rigid = player.GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 nextVec = rigid.position - p_rigid.position;
        Vector2 newPosition = rigid.position + nextVec;
        rigid.MovePosition(newPosition);
    }
}
