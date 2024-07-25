using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rock rock;
    Banana banana;
    GameManager gameManager;

    public float speed = 5f;
   

    
    private void Awake()
    {
        rock = FindObjectOfType<Rock>();
        gameManager= FindObjectOfType<GameManager>();
        banana = FindObjectOfType<Banana>();
    }
 
    private void Update()
    {                  
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }  
      
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            rock.DigRock();
            gameManager.isMinigaming = true;
        }
        if (collision.gameObject.CompareTag("Banana"))
        {
            banana.isBanana = false;
            gameManager.isMinigaming = true;
            Debug.Log("바나나랑 충돌");
        }
    }
}
