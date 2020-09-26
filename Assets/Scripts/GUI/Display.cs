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
    private float timeLimit = 999;
    private int coinCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;
        time.text = "TIME\n" + (timeLimit.ToString()).Substring(0, 3);
    }

    public void updateCoin()
    {
        coinCount++;
        coins.text = "COINS X " + coinCount.ToString();
    }
}
