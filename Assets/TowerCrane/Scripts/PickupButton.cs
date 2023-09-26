using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class PickupButton : MonoBehaviour
{
    #region PUBLIC_VARS
    public bool attached= false;
     public Material rendererl;

    #endregion

    #region PRIVATE_VARS        
   
    [SerializeField] XRSimpleInteractable xrHandsRopes;
    [SerializeField] Vector2 buttonPressed = new Vector2(1, 0);

    bool grabed;
    [SerializeField] IXRSelectInteractor currentInteractorRope;
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        xrHandsRopes.selectEntered.AddListener(Grab);
        xrHandsRopes.selectExited.AddListener(UnGrab);
        rendererl.color = Color.green;
        //transform.position 
        attached = true;

    }

    private void OnDisable()
    {
        xrHandsRopes.selectEntered.RemoveListener(Grab);
        xrHandsRopes.selectExited.RemoveListener(UnGrab);

    }

    private void Update()
    {


        //if (currentInteractorRope != null)
        //{

        //}

        Events.onHookAttachToObject(grabed);

    }

    
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS
    private void Grab(SelectEnterEventArgs args0)
    {
        grabed = attached;
        if(attached)
        {
            attached = false;
         
            rendererl.color = Color.red;
           
        }
        else
        {
            attached = true;

           
            rendererl.color = Color.green;
          
        }


        Debug.Log("Grab Entered");
        currentInteractorRope = args0.interactorObject;
        
    }



    private void UnGrab(SelectExitEventArgs args0)
    {
        Debug.Log("UnGrabbing");
        currentInteractorRope = null;
    }
    #endregion
}



