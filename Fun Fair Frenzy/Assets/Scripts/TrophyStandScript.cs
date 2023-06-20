using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrophyStandScript : MonoBehaviour
{
    [SerializeField] GameObject bear;
    [SerializeField] GameObject bearSpawnLoc;
    public bool Cup1Activated = false;
    public bool Cup2Activated = false;
    public bool Cup3Activated = false;
    public bool doOnce = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckState()
    {
        if (Cup1Activated && Cup2Activated && Cup3Activated)
        {
            if (doOnce)
            {
                Debug.Log("Surprise!");
                Instantiate(bear, bearSpawnLoc.transform.position, bearSpawnLoc.transform.rotation);
                doOnce = false;
            }
            
        }
    }
    
}
