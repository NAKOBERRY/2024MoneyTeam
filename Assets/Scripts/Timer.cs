using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private float currTime;
    private float minute;
    private int second;
    /*private void Awake()
    {
        StartCoroutine(StartTimer());
    }
    private IEnumerator StartTimer()
    {
        currTime += Time.deltaTime;
        second = (int)currTime;
        pointSecond = (int)currTime % 10;
        text.text = second.ToString("00") + ":" + pointSecond.ToString("00");
        yield return null;
    }*/
    private void Update()
    {
        currTime += Time.deltaTime;
        second = (int)currTime%10;
        minute = (int)currTime / 10;
            text.text = currTime.ToString("f2");
    }
}
