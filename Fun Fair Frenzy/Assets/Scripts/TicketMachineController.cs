using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketMachineController : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject ticket;
    void Start()
    {
        //for (int i = 0; i < 3; i++)
        //{
        //    Instantiate(ticket, spawnPoint.transform.position, Quaternion.identity);
            
        //}
    }

    
    void Update()
    {
        
    }
    public void GiveTicket(int ticketsToGive)
    {
        for (int i = 0; i < ticketsToGive; i++)
        {
            Instantiate(ticket, spawnPoint.transform.position, Quaternion.identity);
            Debug.Log("works son");
        }
        Debug.Log("TICKET");
    }
}
