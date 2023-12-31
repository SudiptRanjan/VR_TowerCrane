using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraneMovement : MonoBehaviour
{
    #region PUBLIC_VARS
    public Rigidbody rb;
    #endregion

    #region PRIVATE_VARS 
    float yMinValue = -35f, yManValue = -7f;
	float clampMovement = 0;
    


    [SerializeField] private float speed = 0.5f;
    #endregion

    #region UNITY_CALLBACKS

    private void OnEnable()
	{
		Events.onPlayerMoves += Move;
		
	}

	private void OnDisable()
	{
		Events.onPlayerMoves -= Move;
		

	}
    #endregion
    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS

    private void Move( float yDirection)
	{
       
        if (yDirection > 0)
        {
           if (yDirection < 15)
           {
                clampMovement += Time.deltaTime * speed * 0.2f;
                //print("Gear 1");
           }
            else if (yDirection < 30)
            {
                clampMovement += Time.deltaTime * speed * 0.5f;
                //print("Gear 2");
            }
            else if (yDirection <= 45)
            {
                clampMovement += Time.deltaTime * speed;
                //print("Gear 3");
            }
        }
        else if (yDirection < 0)
        {

            if (yDirection > -15)
            {
                clampMovement -= Time.deltaTime * speed * 0.2f;
                //print("ReverceGear 1");
            }
            else if (yDirection > -30)
            {
                clampMovement -= Time.deltaTime * speed * 0.5f;
                //print("ReverceGear 2");
            }
            else if (yDirection >= -45)
            {
                clampMovement -= Time.deltaTime * speed;
                //  print("ReverceGear 3");
            }
        }

        clampMovement = Mathf.Clamp(clampMovement, yMinValue, yManValue);
		transform.localPosition = new Vector3(0, 2.4f, clampMovement);


        #endregion

    }


}

