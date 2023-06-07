using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalloonPoppingScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    int score = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }
    public void StartGame()
    {

    }
    public void ReseteGame()
    {
        //gameActive = false;
        //for (int i = 0; i < spawned; i++)
        //{
        //    Destroy(spawnedHoops[i]);
        //    spawnedHoops[i] = null;
        //}
        //spawnIndex = 0;
        //spawned = 0;
        //ScoreText.text = ("0");
        //spawnedHoops.Clear();

    }
   
}
