using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class PickupButton : MonoBehaviour
{
    #region PUBLIC_VARS
    public bool attached= false;
     //public Material rendererl;

    #endregion

    #region PRIVATE_VARS        
   
    [SerializeField] XRSimpleInteractable xrHandsRopes;
     float buttonposition = -0.1f;

    bool grabed;
    [SerializeField] IXRSelectInteractor currentInteractorRope;
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        xrHandsRopes.selectEntered.AddListener(Grab);
        xrHandsRopes.selectExited.AddListener(UnGrab);
        //rendererl.color = Color.green;
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
         
            //rendererl.color = Color.red;
            transform.localPosition = new Vector3(1f, buttonposition, 0f);
           
        }
        else
        {
            attached = true;

           
            //rendererl.color = Color.green;
            transform.localPosition = new Vector3(1f, 0f, 0f);

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



