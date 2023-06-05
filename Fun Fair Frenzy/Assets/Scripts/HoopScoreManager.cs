using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoopScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        //ScoreText = GameObject.Find("Hoop Score").GetComponent<TMP_Text>();
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
}
