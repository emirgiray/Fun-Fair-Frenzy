using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHandsOnSelect : MonoBehaviour
{
    public List<GameObject> fingers = new List<GameObject>();
    public List<CapsuleCollider> fingerColliders = new List<CapsuleCollider>();
    

  
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < fingers.Count; i++)
        {
            fingerColliders[i] = fingers[i].GetComponent<CapsuleCollider>();
        }
    }
    public IEnumerator ActivateDeactivateColliders()
    {
        for (int i = 0; i < fingerColliders.Count; i++)
        {
            fingerColliders[i].enabled = false;
        }

       yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < fingerColliders.Count; i++)
        {
            fingerColliders[i].enabled = true;
        }
    }
    public void StartActivDeactive()
    {
        StartCoroutine(ActivateDeactivateColliders());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
