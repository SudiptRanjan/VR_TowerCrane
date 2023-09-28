using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class RedStartButton : MonoBehaviour
{
    #region PUBLIC_VARS
    public bool alert = false;
    public AudioSource audioSource;
    public Material rendererls;
    

    #endregion

    #region PRIVATE_VARS        
    //private Material material;

    [SerializeField] XRSimpleInteractable xrHands;

    float buttonposition = -0.1f;

    [SerializeField] IXRSelectInteractor currentInteractor;


    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        xrHands.selectEntered.AddListener(Grab);
        xrHands.selectExited.AddListener(UnGrab);
        //rendererls.sur = Color.red;
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
        //Debug.Log("Grab Entered red button");
        //jibMovement.isalerted = true;
        //jibMovement.isEngineStarted = true;
        //alert = true;

        if (alert == false)
        {
            alert = true;
            audioSource.Play();
            //rendererls.color = Color.blue;

            transform.localPosition = new Vector3(1f, buttonposition, 0f);
            rendererls.EnableKeyword("_EMISSION");
            
            //rendererls.SetFloat("_EmissionScaleUI", 10f);
        }
        else
        {
            alert = false;
            //rendererls.color = Color.red;
            audioSource.Stop();
            transform.localPosition = new Vector3(1f, 0f, 0f);
            rendererls.DisableKeyword("_EMISSION");
            //rendererls.SetFloat("_EmissionScaleUI", -10f);

        }

    }



    private void UnGrab(SelectExitEventArgs args0)
    {
        //Debug.Log("UnGrabbing red button");
        //ropeLengthValue = 0;
        currentInteractor = null;
        //isTriggered = false;
    }
    #endregion
}




