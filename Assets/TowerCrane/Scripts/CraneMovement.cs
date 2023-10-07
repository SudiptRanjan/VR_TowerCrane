using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraneMovement : MonoBehaviour
{
	float yMinValue = -35f, yManValue = -7f;
	float clampMovement = 0;
	public Rigidbody rb;
    
	[SerializeField] private float speed = 0.5f;

   
    private void OnEnable()
	{
		Events.onPlayerMoves += Move;
		
	}

	private void OnDisable()
	{
		Events.onPlayerMoves -= Move;
		

	}

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

		
		
	}


}

