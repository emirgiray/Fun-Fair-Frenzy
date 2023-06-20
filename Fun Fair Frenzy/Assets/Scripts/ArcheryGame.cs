using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArcheryGame : MonoBehaviour
{
    public int numberOfTries = 10;
    public int exhaustedTries = 0;
    public bool isGameOver = false;
    //[SerializeField] GameObject Bow;
    [SerializeField] GameObject SpawnedBow;
    [SerializeField] GameObject BowSpawnLocation;
    [SerializeField] GameObject ticketMachine;
    [SerializeField] GameObject GOSpawner;
    [SerializeField] TMP_Text ScoreText;
    public int score = 0;
    [SerializeField] int maxTicket = 1;
    int givenTicket = 0;
    void Start()
    {
        //ScoreText = GameObject.Find("Archery Game Score").GetComponent<TMP_Text>();

        numberOfTries = GOSpawner.GetComponent<HoopSpawner>().spawnLimit + 1;
    }

    void Update()
    {

    }
    public void InnerColliderHit()
    {
        Debug.Log("Inner Hit");
        score += 20;
        ScoreText.text = score.ToString();
    }
    public void MiddleColliderHit()
    {
        Debug.Log("Middle Hit");
        score += 10;
        ScoreText.text = score.ToString();
    }
    public void OuterColliderHit()
    {
        Debug.Log("Outer Hit");
        score += 5;
        ScoreText.text = score.ToString();
    }
    public void ReseteGame()
    {


        score = 0;
        ScoreText.text = score.ToString();

        //spawn knifes again
        exhaustedTries = 0;

        //Destroy(SpawnedBow);
        //SpawnedBow = null;
        //SpawnedBow = Instantiate(Bow, BowSpawnLocation.transform.position, Bow.transform.rotation);
    }
    public void ExhaustTries1()
    {
        //Debug.Log("EXHAUST");
        exhaustedTries += 1;
        if (exhaustedTries == numberOfTries)
        {
            isGameOver = true;

            //GameOver();
            StartCoroutine(WaitSeconds(1));
        }
    }
    public void GameOver()
    {
        ticketMachine.GetComponent<TicketMachineController>().GiveTicket(Mathf.RoundToInt(score / 10));
        //givenTicket += Mathf.RoundToInt(score / 10);
        //if (givenTicket >= maxTicket)
        //{
        //    Destroy(SpawnedBow);
        //    GOSpawner.GetComponent<HoopSpawner>().gameActive = false;
        //}

    }
    IEnumerator WaitSeconds(float time)
    {      

        yield return new WaitForSeconds(time);
        GameOver();      
    }
}
