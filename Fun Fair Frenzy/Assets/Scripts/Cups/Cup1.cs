using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup1 : MonoBehaviour
{
    [SerializeField] BoxCollider CupCollider;
    [SerializeField] TrophyStandScript trophyStand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cup1")
        {
            trophyStand.Cup1Activated = true;
            trophyStand.CheckState();
            
        }
        else if (other.gameObject.name == "Cup2")
        {
            trophyStand.Cup2Activated = true;
            trophyStand.CheckState();
            
        }
        else if (other.gameObject.name == "Cup3")
        {
            trophyStand.Cup3Activated = true;
            trophyStand.CheckState();

        }
    }
}
