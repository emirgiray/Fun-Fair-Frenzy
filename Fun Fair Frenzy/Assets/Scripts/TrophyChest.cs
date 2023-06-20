using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TrophyChest : MonoBehaviour
{
    [SerializeField] UnityEvent Denied;
    [SerializeField] UnityEvent Granted;
    [SerializeField]TicketController ticketController;
    [SerializeField]int trophyCost;
    [SerializeField]Animator windowAnimator;
    [SerializeField] TMP_Text TicketCostText;
    [SerializeField] BoxCollider collider;
    bool doOnce = true;
    void Start()
    {
        TicketCostText.text = trophyCost.ToString();
    }

    
    void Update()
    {
        
    }
    public void Buy()
    {
        if (ticketController.ticketCount >= trophyCost && doOnce)
        {
            collider.enabled = false;
            ticketController.DecreaseTicket(trophyCost);
            windowAnimator.SetTrigger("BuyTrophy");
            Granted.Invoke();
            doOnce = false;
        }
        else
        {
            Denied.Invoke();
        }
    }
}
