using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StrongManBell : MonoBehaviour
{
    public int numberOfTries = 10;
    public int exhaustedTries = 0;
    public bool isGameOver = false;
    [SerializeField] GameObject ticketMachine;
    //[SerializeField] float GaugeInnerEndHeight;
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] GameObject GaugeInner;
    public UnityEvent OnBellHitUE;
    float GaugeInnerStartHeight;
    public float score = 0;
    float time = 1;
    bool gameActive = true;
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
        if (collision.gameObject.name == "Hammer_FFF" && gameActive)
        {
            score = collision.relativeVelocity.magnitude;//this stores the impact force
            ScoreText.text = Mathf.Round(score * 100).ToString();

            isGameOver = true;

            GameOver();

            //unity event çaðýr
            OnBellHitUE.Invoke();
            OnBellHit();

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
        ticketMachine.GetComponent<TicketMachineController>().GiveTicket(Mathf.RoundToInt( score));

    }
    public void OnBellHit()
    {
        GaugeInner.transform.position = new Vector3(GaugeInner.transform.position.x, GaugeInnerStartHeight, GaugeInner.transform.position.z);// reset the gauge first
        //GaugeInner.transform.position = new Vector3(GaugeInner.transform.position.x, GaugeInnerStartHeight + score/3 , GaugeInner.transform.position.z);//set the gauge position, needs a better calculation

        StartCoroutine(MoveInnerGauge(GaugeInnerStartHeight + score / 3, time));
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
    }
}
