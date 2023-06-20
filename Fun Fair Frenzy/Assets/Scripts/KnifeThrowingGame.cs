using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.Sockets;

public class KnifeThrowingGame : MonoBehaviour
{
    public int numberOfTries = 10;
    public int exhaustedTries = 0;
    public bool isGameOver = false;
    [SerializeField] GameObject ticketMachine;
    [SerializeField] GameObject GOSpawner;
    [SerializeField] TMP_Text ScoreText;
    public int score = 0;

    [SerializeField] int maxTicket = 1;
    int givenTicket = 0;
    void Start()
    {
        ScoreText = GameObject.Find("Knife Throwing Score").GetComponent<TMP_Text>();
        //ticketController = GameObject.Find("Ticket Controller").GetComponent<TicketController>();
        numberOfTries = GOSpawner.GetComponent<HoopSpawner>().spawnLimit + 1;
    }

    void Update()
    {
        
    }
    public void KnifeHit()
    {      
        score += 1;
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

            StartCoroutine(WaitSeconds(1));
        }
    }
    public void GameOver()
    {
        ticketMachine.GetComponent<TicketMachineController>().GiveTicket(score);
        //givenTicket += Mathf.RoundToInt(score / 10);
        //if (givenTicket >= maxTicket)
        //{
        //    //Destroy(SpawnedBow);
        //    GOSpawner.GetComponent<HoopSpawner>().gameActive = false;
        //}

    }
    IEnumerator WaitSeconds(float time)
    {

        yield return new WaitForSeconds(time);
        GameOver();
    }
}
