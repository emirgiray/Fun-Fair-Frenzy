using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KnifeThrowingGame : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    int score = 0;
    void Start()
    {
        ScoreText = GameObject.Find("Knife Throwing Score").GetComponent<TMP_Text>();
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

        //spawn knifes again
    }
}
