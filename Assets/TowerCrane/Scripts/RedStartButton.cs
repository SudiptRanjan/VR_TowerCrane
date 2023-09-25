

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class RedStartButton : MonoBehaviour
{
    #region PUBLIC_VARS
    //public bool alert = false;
    public Material rendererls;
    public JibMovement jibMovement;

    #endregion

    #region PRIVATE_VARS        
    

    [SerializeField] XRSimpleInteractable xrHands;

  

    [SerializeField] IXRSelectInteractor currentInteractor;


    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        xrHands.selectEntered.AddListener(Grab);
        xrHands.selectExited.AddListener(UnGrab);
        rendererls.color = Color.red;

        //alert = true;

    }

    private void OnDisable()
    {
        xrHands.selectEntered.RemoveListener(Grab);
        xrHands.selectExited.RemoveListener(UnGrab);

    }

    private void Update()
    {


        //if (currentInteractorRope != null)
        //{

        //}
        //Events.onClickRedButton(grabed);

        

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Player Got Hit");
    //}
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS
    private void Grab(SelectEnterEventArgs args0)
    {
        currentInteractor = args0.interactorObject;

        //Debug.Log(jibMovement.isalerted!);
        Debug.Log("Grab Entered red button");
        //if (jibMovement.isalerted! && jibMovement.isEngineStarted!)
        //{
        //    //Debug.Log(jibMovement.isalerted!);
        //    jibMovement.isalerted = false;
        //    jibMovement.isEngineStarted = false;


        //    rendererls.color = Color.blue;

        //}
        //else
        //{
        //    jibMovement.isalerted = true;
        //    jibMovement.isEngineStarted = true;


        //    rendererls.color = Color.red;

        //}




    }



    private void UnGrab(SelectExitEventArgs args0)
    {
        Debug.Log("UnGrabbing red button");
        //ropeLengthValue = 0;
        currentInteractor = null;
        //isTriggered = false;
    }
    #endregion
}



