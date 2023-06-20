using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TicketController : MonoBehaviour
{
    [SerializeField] TMP_Text TicketText;
    public int ticketCount = 0;
    void Start()
    {
        TicketText = GameObject.Find("TicketText").GetComponent<TMP_Text>();
        TicketText.text = ticketCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseTicket()
    {
        ticketCount++;
        TicketText.text = ticketCount.ToString();
    }
}
