using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalloonPoppingScoreManager : MonoBehaviour
{
    public int numberOfTries = 10;
    public int exhaustedTries = 0;
    public bool isGameOver = false;
    [SerializeField] GameObject ticketMachine;
    [SerializeField] GameObject GOSpawner;
    [SerializeField] TMP_Text ScoreText;
    public int score = 0;

    void Start()
    {
        numberOfTries = GOSpawner.GetComponent<HoopSpawner>().spawnLimit + 1;
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
        score = 0;
        ScoreText.text = score.ToString();

        exhaustedTries = 0;
    }
    public void ExhaustTries()
    {
        exhaustedTries += 1;
        if (exhaustedTries == numberOfTries)
        {
            isGameOver = true;

            GameOver();
        }
    }
    public void GameOver()
    {
        ticketMachine.GetComponent<TicketMachineController>().GiveTicket(score);

    }

}
