using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class StrongmanHammerHit : MonoBehaviour
{
    [SerializeField] UnityEvent HammerHit;
    [SerializeField] float hitMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Collider>() != null)
        {
            if (collision.relativeVelocity.magnitude > hitMagnitude)
            {
                HammerHit.Invoke();
                Debug.Log(collision.relativeVelocity.magnitude);
            }
           
        }
    }
}
