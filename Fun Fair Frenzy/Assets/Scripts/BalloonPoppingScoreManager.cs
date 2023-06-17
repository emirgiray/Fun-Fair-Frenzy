using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalloonPoppingScoreManager : MonoBehaviour
{
    [SerializeField] GameObject BallonsSpawnPoint;
    [SerializeField] GameObject BallonsSet;
    [SerializeField] GameObject SpawnedBallonsSet;
    [SerializeField] List<GameObject> spawnedBallons = new List<GameObject>();

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

        Destroy(SpawnedBallonsSet);

        SpawnedBallonsSet = Instantiate(BallonsSet, BallonsSpawnPoint.transform.position, Quaternion.identity);

        //for (int i = 0; i < spawnedBallons.Count; i++)//delete previous ballons
        //{
        //    Destroy(spawnedBallons[i]);
        //    spawnedBallons[i] = null;
        //}

        //for (int i = 0; i < spawnedBallons.Count; i++)//spawn new ballon set
        //{
        //    spawnedBallons.Add(null);

        //    spawnedBallons[i] = Instantiate(BallonsSet, BallonsSpawnPoint.transform.position, Quaternion.identity);

        //}
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
