using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Banana : MonoBehaviour
{
    private int[] bananaDir = new int[4];
    private int[] playerDir = new int[4];
    public bool isBanana = false;
    public GameObject bananaPanel;
    private Rigidbody2D rigid;
    public Sprite[] arrowImages;
    public Image[] images;
    public int bananaCount = 0;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();              
        for (int i = 0; i < 4; i++)
        {
            bananaDir[i] = Random.Range(0, 4);
        }
    }

    private void Update()
    {
        if (isBanana)
        {
            BananaPat();
        }
    }

 
    private void BananaPat()
    {      
        if (Input.GetKeyDown(KeyCode.UpArrow)) UpdatePlayerDir(0);
        else if (Input.GetKeyDown(KeyCode.DownArrow)) UpdatePlayerDir(1);
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) UpdatePlayerDir(2);
        else if (Input.GetKeyDown(KeyCode.RightArrow)) UpdatePlayerDir(3);

        if (bananaCount >= 4 && AreArraysEqual(playerDir, bananaDir))
        {           
            bananaPanel.SetActive(false);
            rigid.AddForce(new Vector2(Random.Range(-20, 21), Random.Range(5, 10)), ForceMode2D.Impulse);           
            GameManager.instance.ClearMinigame();
        }
    }

    

    private void SetImage()
    {
        for (int i = 0; i < 4; i++)
        {
            images[i].sprite = arrowImages[bananaDir[i]];
        }
        bananaPanel.SetActive(true);
    }

    private void UpdatePlayerDir(int direction)
    {
        for (int i = 0; i < playerDir.Length - 1; i++)
        {
            playerDir[i] = playerDir[i + 1];
        }
        playerDir[playerDir.Length - 1] = direction;
        bananaCount++;
    }

    private bool AreArraysEqual(int[] array1, int[] array2)
    {
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i]) return false;
        }
        return true;
    }
}
