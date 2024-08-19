using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrowerController : MonoBehaviour
{
    public Transform RightHnadTfm;
    public Transform LeftHnadTfm;
    public GameObject yellowDraw;
    public GameObject redDraw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            Instantiate(yellowDraw, RightHnadTfm.position, Quaternion.identity);
        }
        
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            Instantiate(redDraw, LeftHnadTfm.position, Quaternion.identity);
        }
        
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Instantiate(redDraw, LeftHnadTfm.position, Quaternion.identity);
        }

    }
}
