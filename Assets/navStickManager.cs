using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class navStickManager : MonoBehaviour
{
    public Material mat1, mat2;

    public MeshRenderer meshRenderer;

    public float forceMultiplier = 10f;
    public Text debugText;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateDebugText("Ready...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter triggered");  // ここでログを出力

        if (collision.gameObject.CompareTag("tenzi"))
        {
            Debug.Log("Collision with tenzi detected");

            meshRenderer.material = mat2;
            UpdateDebugText("Hit detected with tenzi object.");

            float boundsPower = 1.0f;
            Vector3 hitPos = collision.contacts[0].point;

            Vector3 boundVec = this.transform.position - hitPos;
            Debug.Log($"this.transform.position: {this.transform.position}");
            Debug.Log($"tyuushin Vec: {boundVec}");

            Vector3 forceDir = boundsPower * Vector3.Scale(boundVec, new Vector3(-1, 1, -1));
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(forceDir, ForceMode.Impulse);
                Debug.Log($"Applied Bounce Force: {forceDir}, Hit Position: {hitPos}");
                UpdateDebugText($"Applied Bounce Force: {forceDir}");
            }
        }
    }



    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit triggered");  // ここでログを出力
        if (collision.gameObject.CompareTag("tenzi"))
        {
            Debug.Log("Exit");
            meshRenderer.material = mat1;
            
            UpdateDebugText("Exit detected with tenzi object.");
        }
    }
    void UpdateDebugText(string message)
    {
        if (debugText != null)
        {
            debugText.text = message;
        }
    }
}
