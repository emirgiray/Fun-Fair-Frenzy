using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoopScoreScript : MonoBehaviour
{
    [SerializeField] HoopScoreManager scoreManager;
    public bool isMovingHoopGame;
    bool doOnce = false;
    //MeshCollider HoopInnerCollider;
    //[SerializeField] GameObject ScoreTextGO;
    //[SerializeField] TMP_Text ScoreText;
    //int score = 0;
    void Start()
    {
        if (isMovingHoopGame)
        {
            scoreManager = GameObject.Find("Hoop Moving Score Manager").GetComponent<HoopScoreManager>();
        }
        else
        {
            scoreManager = GameObject.Find("Hoop Score Manager").GetComponent<HoopScoreManager>();
        }
        //TextMeshPro ScoreText = ScoreTextGO.GetComponent<TextMeshPro>();
        //ScoreText = GameObject.Find("Hoop Score").GetComponent<TMP_Text>();
        //ScoreText.text = score.ToString();
        
    }
    private void Awake()
    {
        //ScoreText = GameObject.Find("Hoop Score").GetComponent<TMP_Text>();
        //ScoreText.text = score.ToString();
        if (isMovingHoopGame)
        {
            scoreManager = GameObject.Find("Hoop Moving Score").GetComponent<HoopScoreManager>();
        }
        else
        {
            scoreManager = GameObject.Find("Hoop Score").GetComponent<HoopScoreManager>();
        }
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bottle")) 
        {
            
            if (doOnce == false)
            {
                scoreManager.UpdateScore();
                doOnce = true;
            }
            
            //score++;
            //ScoreText.text = score.ToString();
            //this.GetComponent<HoopScoreScript>().enabled = false;
        }
    }
}
