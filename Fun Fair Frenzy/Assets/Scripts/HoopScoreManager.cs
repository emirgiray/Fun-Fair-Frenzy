using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HoopScoreManager : MonoBehaviour
{
    public int numberOfTries = 10;
    public int exhaustedTries = 0;
    public bool isGameOver = false;
    [SerializeField] GameObject ticketMachine;
    [SerializeField] GameObject GOSpawner;
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] bool isMovingHoopGame;
    [SerializeField] GameObject objectToMove;
    [SerializeField] float rotationSpeed = 0.1f;
    public int score = 0;


    void Start()
    {
        numberOfTries = GOSpawner.GetComponent<HoopSpawner>().spawnLimit + 1;
    }

    
    void Update()
    {
        if (isMovingHoopGame) 
        {
            objectToMove.transform.Rotate(0, rotationSpeed, 0 * Time.deltaTime);
        }
    }
    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();
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

