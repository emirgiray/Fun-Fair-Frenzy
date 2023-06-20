using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TicketMachineController : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject ticket;
    [SerializeField] Animator animator;
    [SerializeField] UnityEvent Caching;
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
            animator.SetTrigger("GiveTicket");
            Caching.Invoke();
            //Debug.Log("works son");
        }
        //Debug.Log("TICKET");
    }
}
