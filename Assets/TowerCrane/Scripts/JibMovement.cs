using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JibMovement : MonoBehaviour
{
    #region PUBLIC_VARS
    #endregion

    #region PRIVATE_VARS
    [SerializeField] float moveSpeed = 0.5f;
    float newRotation = 0;
    [SerializeField] private float yMinValueRotation = 10f, yMaxValueRotation = 60f;

    #endregion


    #region UNITY_CALLBACKS
    private void OnEnable()
    {
        Events.onPlayerRotate += Rotates;
       
    }
    private void OnDisable()
    {
        Events.onPlayerRotate -= Rotates;

    }
    #endregion


    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS
    private void Rotates(float rotate)
    {


        if (rotate > 0)
        {

            if (rotate < 15)
            {
                newRotation += Time.deltaTime * moveSpeed * 0.2f;
            }
            else if (rotate < 30)
            {
                newRotation += Time.deltaTime * moveSpeed * 0.5f;
            }
            else if (rotate <= 45)
            {
                newRotation += Time.deltaTime * moveSpeed;
            }

        }

        else if (rotate < 0)
        {
            if (rotate > -15)
            {
                newRotation -= Time.deltaTime * moveSpeed * 0.2f;
            }
            else if (rotate > -30)
            {
                newRotation -= Time.deltaTime * moveSpeed * 0.5f;
            }
            else if (rotate >= -45)
            {
                newRotation -= Time.deltaTime * moveSpeed;
            }

        }

        newRotation = Mathf.Clamp(newRotation, yMinValueRotation, yMaxValueRotation);

        transform.localRotation = Quaternion.Euler(0, newRotation, 0);

    }

    #endregion

}
