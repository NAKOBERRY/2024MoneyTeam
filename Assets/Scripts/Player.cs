using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rock rock;
    Banana banana;

    public float speed = 5f;
      
    private void Awake()
    {
        rock = FindObjectOfType<Rock>();       
        banana = FindObjectOfType<Banana>();
    }
 
    private void Update()
    {                  
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
