using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField] private int speed;
    private Vector2 inputVec;



    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");

        MovePlayer();
    }

    public void MovePlayer()
    {
        var newInputVec = inputVec * speed * Time.deltaTime;

        Vector2 newPosition = rigid.position + newInputVec;

        rigid.MovePosition(newPosition);
    }

}
