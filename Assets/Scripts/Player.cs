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
    public float jumpPower = 20f;

    [SerializeField] public Vector3 bottomOffset;
    [SerializeField] public Vector2 overlabBoxSize;
    [SerializeField] public LayerMask groundLayer;
    public GameObject deathPanel;
    private void Awake()
    {
        rock = FindObjectOfType<Rock>();
        gameManager= FindObjectOfType<GameManager>();
    }
 
    private void Update()
    {                  
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }  

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + bottomOffset, overlabBoxSize);
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
            banana.BananaFalse();
            gameManager.isMinigaming = true;
        }
    }
}
