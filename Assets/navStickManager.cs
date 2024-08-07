using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navStickManager : MonoBehaviour
{
    public Material mat1, mat2;

    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tenzi"))
        {
            Debug.Log("Hit");
            meshRenderer.material = mat2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("tenzi"))
        {
            Debug.Log("Hit");
            meshRenderer.material = mat1;
        }
    }
}
