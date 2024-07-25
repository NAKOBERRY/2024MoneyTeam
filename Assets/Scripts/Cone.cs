using UnityEngine;
using TMPro;

public class Cone : MonoBehaviour
{
    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider;
    private int[] coneArray = new int[8];
    private int[] playerArray = new int[8];
    public TMP_Text coneNum;
    private bool isCone = false;
    private int numCount = 0;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        GenerateConePattern();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            isCone = true;
            coneNum.gameObject.SetActive(true);
        }

        if (isCone)
        {
            for (int i = 0; i < coneArray.Length; i++)
            {
                if (Input.anyKeyDown)
                {
                    int keyNumber = GetKeyNumber();
                    if (keyNumber != -1)
                    {
                        playerArray[i] = keyNumber;
                        numCount++;
                    }
                }
            }
        }

        if (numCount >= 8 && AreArraysEqual(playerArray, coneArray))
        {
            coneNum.gameObject.SetActive(false);
            ApplyRandomForce();
            boxCollider.isTrigger = true;
        }
    }

    private void GenerateConePattern()
    {
        for (int i = 0; i < coneArray.Length; i++)
        {
            coneArray[i] = Random.Range(1, 9);
        }
        coneNum.text = string.Join(", ", coneArray);
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

    private int GetKeyNumber()
    {
        for (int i = 1; i <= 8; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + (i - 1)))
            {
                return i;
            }
        }
        return -1;
    }

    private void ApplyRandomForce()
    {
        float x = Random.Range(-20, 21);
        float y = Random.Range(5, 10);
        rigid.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }
}
