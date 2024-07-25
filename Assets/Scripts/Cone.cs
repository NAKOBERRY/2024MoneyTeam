using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Cone : MonoBehaviour
{

    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider;
    private int[] coneArry = new int[8];
    private int[] playerArry = new int[8];
    public TMP_Text coneNum;
    private bool isCone = false;
    private int numCount = 0;


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        ConePat();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0)) 
        {
            isCone = true;
        }
        if (isCone)
        {
            coneNum.gameObject.SetActive(true);
            for (int i = 0; i < coneArry.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    playerArry[i] = playerArry[0];
                    numCount++;
                    Debug.Log("1");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    playerArry[i] = playerArry[1];
                    numCount++;
                    Debug.Log("2");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    playerArry[i] = playerArry[2];
                    numCount++;
                    Debug.Log("3");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    playerArry[i] = playerArry[3];
                    numCount++;
                    Debug.Log("4");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    playerArry[i] = playerArry[4];
                    numCount++;
                    Debug.Log("5");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    playerArry[i] = playerArry[5];
                    numCount++;
                    Debug.Log("6");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    playerArry[i] = playerArry[6];
                    numCount++;
                    Debug.Log("7");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    playerArry[i] = playerArry[7];
                    numCount++;
                    Debug.Log("8");
                }
            }
        }   
        if(numCount >= 8)
        {
            if (AreArraysEqual(playerArry, coneArry))
            {
                Debug.Log("클리어");
                coneNum.gameObject.SetActive(false);
                float x = Random.Range(-20, 21);
                float y = Random.Range(5, 10);
                rigid.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
                boxCollider.isTrigger = true;
            }
        }     
    }

    public void ConePat()
    {      
        for (int i = 0; i < coneArry.Length; i++)
        {
            coneArry[i] = Random.Range(1, 9);
        }
        string numbersString = ArrayToString(coneArry);
        coneNum.text = numbersString;
    }

    string ArrayToString(int[] array)
    {
        return string.Join(", ", array);
    }

    private bool AreArraysEqual(int[] array1, int[] array2)
    {
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
            {
                Debug.Log("일치하지 않음");
                return false;
            }
        }
        Debug.Log("일치함");
        return true;
    }
}
