using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    public TextMeshProUGUI points;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI time;

    private int scoreCount = 0;
    private float timeLimit = 20;
    private int coinCount = 0;
    private int pointCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLimit > 0)
        {
            timeLimit -= Time.deltaTime;
            time.text = "TIME\n" + (timeLimit.ToString()).Substring(0, 3);
        } else
        {
            time.text = "GAME OVER\n" + "0";
            //Debug.Log("Game Over!");
        }
    }

    public void updateCoin()
    {
        coinCount++;
        coins.text = "COINS X " + coinCount.ToString();
        pointCount += 100;
        points.text = pointCount.ToString();
    }

    public void updatePoint()
    {
        pointCount += 100;
        points.text = pointCount.ToString();
    }
}
