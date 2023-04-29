using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StrongManBell : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] GameObject GaugeInner;
    public UnityEvent OnBellHitUE;
    float GaugeInnerStartHeight;
    float score = 0;
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
        if (collision.gameObject.name == "SledgeHammer")
        {
            score = collision.relativeVelocity.magnitude;//this stores the impact force
            ScoreText.text = (score * 100).ToString();

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
    public void OnBellHit()
    {
        GaugeInner.transform.position = new Vector3(GaugeInner.transform.position.x, GaugeInnerStartHeight, GaugeInner.transform.position.z);// reset the gauge first
        GaugeInner.transform.position = new Vector3(GaugeInner.transform.position.x, GaugeInnerStartHeight + score/3 , GaugeInner.transform.position.z);//set the gauge position, needs a better calculation
    }
}
