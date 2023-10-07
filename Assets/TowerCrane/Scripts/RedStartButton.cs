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
    public MeshRenderer meshRenderer;
    public Material emissiveColor;
    public Material normalColor;
    public GreenAlertButton greenAlertButton;


    #endregion

    #region PRIVATE_VARS        

    [SerializeField] XRSimpleInteractable xrHands;

    float buttonposition = -0.1f;

    [SerializeField] IXRSelectInteractor currentInteractor;


    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        xrHands.selectEntered.AddListener(Grab);
        xrHands.selectExited.AddListener(UnGrab);
        meshRenderer.material = normalColor;

    }

    private void OnDisable()
    {
        xrHands.selectEntered.RemoveListener(Grab);
        xrHands.selectExited.RemoveListener(UnGrab);

    }




    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS



    private void Grab(SelectEnterEventArgs args0)
    {
        currentInteractor = args0.interactorObject;


        if (alert == false)
        {
            alert = true;
            audioSource.Play();

            meshRenderer.material = emissiveColor;

            transform.localPosition = new Vector3(1f, buttonposition, 0f);


        }
        else
        {
            alert = false;
            meshRenderer.material = normalColor;
            audioSource.Stop();
            transform.localPosition = new Vector3(1f, 0f, 0f);
            greenAlertButton.setOffGreenButton();
        }

    }


    private void UnGrab(SelectExitEventArgs args0)
    {

        currentInteractor = null;

    }
    #endregion
}



