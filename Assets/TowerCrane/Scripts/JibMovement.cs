using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JibMovement : MonoBehaviour
{
    //private CraneInputActions m_inputaction;
    [SerializeField] float moveSpeed = 0.5f;
    float newRotation = 0;
    //public bool isalerted, isEngineStarted;
    [SerializeField] private float yMinValueRotation = 10f, yMaxValueRotation = 60f;
    // Start is called before the first frame update
    void Start()
    {
        //isalerted = false;
        //isEngineStarted = false;
    }

    private void OnEnable()
    {
        Events.onPlayerRotate += Rotates;
       
    }
    private void OnDisable()
    {
        Events.onPlayerRotate -= Rotates;

    }
   

    private void Rotates(float  rotate)
    {

      
        if (rotate > 0)
        {

            if (rotate < 15)
            {
                newRotation += Time.deltaTime * moveSpeed * 0.2f;
                //print("Gear 1 =" + newRotation);
            }
            else if (rotate < 30)
            {
                newRotation += Time.deltaTime * moveSpeed * 0.5f;
                //print("Gear 2 =" + newRotation);
            }
            else if (rotate <= 45)
            {
                newRotation += Time.deltaTime * moveSpeed;
                //print("Gear 3 =" + newRotation);
            }

        }

        else if (rotate < 0)
        {
            if (rotate > -15)
            {
                newRotation -= Time.deltaTime * moveSpeed * 0.2f;
                //print("ReverceGear 1");
            }
            else if (rotate > -30)
            {
                newRotation -= Time.deltaTime * moveSpeed * 0.5f;
                //print("ReverceGear 2");
            }
            else if (rotate >= -45)
            {
                newRotation -= Time.deltaTime * moveSpeed;
                //print("ReverceGear 3");
            }

        }

        newRotation = Mathf.Clamp(newRotation, yMinValueRotation, yMaxValueRotation);

        transform.localRotation = Quaternion.Euler(0, newRotation, 0);

    }
}
//transform.localRotation = Quaternion.Euler(new Vector3(0f, Mathf.Clamp(transform.localRotation.y, yMinValueRotation, yMaxValueRotation), 0f));
//transform.Rotate(Vector3.forward * rotate * Time.deltaTime * 80);