using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hurdle : MonoBehaviour
{
    Player player;

    public float stunTime;
    private float currStunTime;
    private void Update()
    {
        currStunTime -= Time.deltaTime;
    }
    public void Stuns()
    {
        float playerSpeedTemp = player.speed;

        currStunTime = stunTime;
        if (currStunTime > 0)
        {
            player.speed = 0;
        }
        else if (currStunTime <= 0)
        {
            player.speed = playerSpeedTemp;
            return;
        }
    }   
}
