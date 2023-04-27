using HurricaneVR.Framework.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    [SerializeField] HVRGrabbable hVRGrabbable;
    MeshCollider meshCollider;
    // Start is called before the first frame update
    void Start()
    {
        hVRGrabbable = GetComponent<HVRGrabbable>();
        meshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hVRGrabbable.IsHandGrabbed)
        {
            hVRGrabbable.enabled = false;
            meshCollider.enabled = false;
        }
    }
}
