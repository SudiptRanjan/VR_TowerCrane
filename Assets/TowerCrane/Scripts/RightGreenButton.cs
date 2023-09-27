using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class RightGreenButton : MonoBehaviour
{
    #region PUBLIC_VARS
    public bool isStartRightButton = false;

    //public Material rendererls;
    //public JibMovement jibMovement;

    #endregion

    #region PRIVATE_VARS        


    [SerializeField] XRSimpleInteractable xrHandsGreen;

    float buttonposition = -0.1f;

    [SerializeField] IXRSelectInteractor greenCurrentInteractor;


    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
       

        xrHandsGreen.selectEntered.AddListener(Grab);
        xrHandsGreen.selectExited.AddListener(UnGrab);


        //rendererls.color = Color.green;

        //alert = true;

    }

    private void OnDisable()
    {
       

        xrHandsGreen.selectEntered.RemoveListener(Grab);
        xrHandsGreen.selectExited.RemoveListener(UnGrab);

    }




    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS
    private void Grab(SelectEnterEventArgs args0)
    {
        greenCurrentInteractor = args0.interactorObject;
        Debug.Log("Grab Entered red button");
        //jibMovement.isalerted = true;
        //jibMovement.isEngineStarted = true;
        //alert = true;

        

        if (!isStartRightButton)
        {
            isStartRightButton = true;
            //rendererls.color = Color.blue;
            transform.localPosition = new Vector3(1f, buttonposition, 0f);
        }
        else
        {
            isStartRightButton = false;
            //rendererls.color = Color.green;
            transform.localPosition = new Vector3(1f, 0f, 0f);
        }

    }



    private void UnGrab(SelectExitEventArgs args0)
    {
        Debug.Log("UnGrabbing red button");
        //ropeLengthValue = 0;
        greenCurrentInteractor = null;

        //isTriggered = false;
    }
    #endregion
}






