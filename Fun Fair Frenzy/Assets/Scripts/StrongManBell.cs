using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StrongManBell : MonoBehaviour
{
    [SerializeField] UnityEvent scoreIncreaseStart;
    [SerializeField] UnityEvent scoreIncreaseStop;
    public int numberOfTries = 10;
    public int exhaustedTries = 0;
    public bool isGameOver = false;
    [SerializeField] GameObject ticketMachine;
    //[SerializeField] float GaugeInnerEndHeight;
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] GameObject GaugeInner;
    [SerializeField] GameObject Hammer;
    public UnityEvent OnBellHitUE;
    float GaugeInnerStartHeight;
    public float score = 0;
    float time = 1;
    bool gameActive = true;
    [SerializeField] int maxTicket = 1;
    int givenTicket = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = score.ToString();
        GaugeInnerStartHeight = GaugeInner.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (  gameActive)
        {
            if (collision.gameObject.tag == "Hammer" || collision.gameObject.tag == "Trophy")
            {
                score = collision.relativeVelocity.magnitude;//this stores the impact force
                ScoreText.text = Mathf.Round(score * 10).ToString();

                isGameOver = true;

                GameOver();

                //unity event çaðýr
                OnBellHitUE.Invoke();
                OnBellHit();
            }
            

        }
    }
    public void Reset()
    {
        score = 0;
        ScoreText.text = score.ToString();

        GaugeInner.transform.position = new Vector3(GaugeInner.transform.position.x, GaugeInnerStartHeight, GaugeInner.transform.position.z);
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
        if (Mathf.RoundToInt(score) >= 5)
        {
            ticketMachine.GetComponent<TicketMachineController>().GiveTicket(Mathf.RoundToInt(score/5));
            //givenTicket += Mathf.RoundToInt(score / 5);
            //if (givenTicket >= maxTicket)
            //{
            //    Destroy(Hammer);
            //    gameActive = false;

            //}
        }
        

    }
    public void OnBellHit()
    {
        GaugeInner.transform.position = new Vector3(GaugeInner.transform.position.x, GaugeInnerStartHeight, GaugeInner.transform.position.z);// reset the gauge first
        //GaugeInner.transform.position = new Vector3(GaugeInner.transform.position.x, GaugeInnerStartHeight + score/3 , GaugeInner.transform.position.z);//set the gauge position, needs a better calculation
        if (gameActive )
        {
            scoreIncreaseStart.Invoke();
        }
        
        StartCoroutine(MoveInnerGauge(GaugeInnerStartHeight + score / 5, time));
    }
    IEnumerator MoveInnerGauge(float targetHeight, float time)
    {
        gameActive = false;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            GaugeInner.transform.position = Vector3.Lerp(new Vector3(GaugeInner.transform.position.x, GaugeInnerStartHeight, GaugeInner.transform.position.z), new Vector3(GaugeInner.transform.position.x, targetHeight, GaugeInner.transform.position.z), (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        GaugeInner.transform.position = new Vector3(GaugeInner.transform.position.x, targetHeight, GaugeInner.transform.position.z);

        gameActive = true;
        scoreIncreaseStop.Invoke();
    }
}
