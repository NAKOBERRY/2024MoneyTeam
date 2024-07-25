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


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isCone)
        {
            for (int i = 0; i < coneArry.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    playerArry[i] = playerArry[1];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    playerArry[i] = playerArry[2];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    playerArry[i] = playerArry[3];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    playerArry[i] = playerArry[4];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    playerArry[i] = playerArry[5];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    playerArry[i] = playerArry[6];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    playerArry[i] = playerArry[7];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    playerArry[i] = playerArry[8];
                }
            }
        }   
        else if (true)
        {

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
}
