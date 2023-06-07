using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] BalloonPoppingScoreManager scoreManager;
    [SerializeField] GameObject balloonParticleSystem;
    void Start()
    {
        scoreManager = GameObject.Find("Balloon Popping Score Manger").GetComponent<BalloonPoppingScoreManager>();

    }
     void Awake()
    {
        scoreManager = GameObject.Find("Balloon Popping Score Manger").GetComponent<BalloonPoppingScoreManager>();
    }

    void Update()
    {
        
    }
    public void PopBalloon()
    {
        scoreManager.UpdateScore();
        Instantiate(balloonParticleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
