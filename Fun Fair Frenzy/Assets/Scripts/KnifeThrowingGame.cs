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
    }
}
