using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Clone : MonoBehaviour
{
    private float speed = 5f;
    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
