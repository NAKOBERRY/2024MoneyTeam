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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            rock.isDig = true;
            GameManager.instance.isMinigaming = true;
        }
        if (collision.gameObject.CompareTag("Banana"))
        {
            banana.isBanana = true;
            GameManager.instance.isMinigaming = true;
        }
    }
}
