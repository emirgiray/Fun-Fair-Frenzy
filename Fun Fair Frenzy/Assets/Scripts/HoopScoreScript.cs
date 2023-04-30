using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoopScoreScript : MonoBehaviour
{
    //MeshCollider HoopInnerCollider;
    //[SerializeField] GameObject ScoreTextGO;
    [SerializeField] TMP_Text ScoreText;
    int score = 0;
    void Start()
    {
        //TextMeshPro ScoreText = ScoreTextGO.GetComponent<TextMeshPro>();
        ScoreText = GameObject.Find("Hoop Score").GetComponent<TMP_Text>();
        //ScoreText.text = score.ToString();
        
    }
    private void Awake()
    {
        ScoreText = GameObject.Find("Hoop Score").GetComponent<TMP_Text>();
        //ScoreText.text = score.ToString();
       
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bottle")) 
        {
            score++;
            ScoreText.text = score.ToString();
        }
    }
}
