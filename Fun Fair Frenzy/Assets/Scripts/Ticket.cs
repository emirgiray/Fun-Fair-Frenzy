using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    TicketController ticketController;
    // Start is called before the first frame update
    void Start()
    {
        ticketController = GameObject.Find("Ticket Controller").GetComponent<TicketController>();
    }
    void Awake()
    {
        ticketController = GameObject.Find("Ticket Controller").GetComponent<TicketController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void IncreaseTicket()
    //{
    //    ticketController.ticketCount++;
    //    Destroy(gameObject);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hands")
        {
            ticketController.IncreaseTicket();
            Destroy(gameObject);
        }
    }
}
