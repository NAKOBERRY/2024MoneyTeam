using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Banana : MonoBehaviour
{
    private int[] bananaDir = new int[4];
    private int[] playerDir = new int[4];
    private bool isBanana = true;
    public GameObject bananaPanel;
    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider;
    public Sprite[] arrowImages;
    public Image[] images;
    public int bananaCount = 0;

    private void Start()
    { 
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!isBanana)
        {
            BananaPat();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            isBanana = false;
        }
    }

    private void BananaPat()
    {
        for (int i = 0; i < 4; i++)
        {
            bananaDir[i] = Random.Range(0, 4);
        }
        for (int i = 0; i < 4; i++)
        {
            if (bananaDir[i] == 0)
            {
                images[i].sprite = arrowImages[0];
            }
            if (bananaDir[i] == 1)
            {
                images[i].sprite = arrowImages[1];
            }
            if (bananaDir[i] == 2)
            {
                images[i].sprite = arrowImages[2];
            }
            if (bananaDir[i] == 3)
            {
                images[i].sprite = arrowImages[3];
            }
        }
        bananaPanel.SetActive(true);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpdatePlayerDir(0);
            bananaCount++;
            Debug.Log("위");     
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            UpdatePlayerDir(1);
            bananaCount++;
            Debug.Log("아래");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            UpdatePlayerDir(2);
            bananaCount++;
            Debug.Log("왼쪽");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            UpdatePlayerDir(3);
            bananaCount++;
            Debug.Log("오른쪽");
        }
        if(bananaCount >= 4)
        {          
            if (AreArraysEqual(playerDir, bananaDir))
            {
                Debug.Log("일치함");
                bananaPanel.SetActive(false);
                float x = Random.Range(-20, 21);
                float y = Random.Range(5, 10);
                rigid.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
                boxCollider.isTrigger = true;
            }
        }     
    }

    private void UpdatePlayerDir(int direction)
    {
        
        for (int i = 0; i < playerDir.Length - 1; i++)
        {
            playerDir[i] = playerDir[i + 1];
        }
        playerDir[playerDir.Length - 1] = direction;
    }

    private bool AreArraysEqual(int[] array1, int[] array2)
    {
        for (int i = 0; i < array1.Length; i++)
        {          
            if (array1[i] != array2[i])
            {
                return false;
            }                                                
        }
        return true;
    }
}
