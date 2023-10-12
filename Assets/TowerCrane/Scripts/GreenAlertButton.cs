using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class GreenAlertButton : MonoBehaviour
{
    #region PUBLIC_VARS
    public bool engineStartButton = false;
    public MeshRenderer greenMeshRenderer;
    public Material greenEmissiveColor;
    public Material greenNormalColor;
    public RedStartButton redStartButton;

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
        greenMeshRenderer.material = greenNormalColor;

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
    public void setOffGreenButton()
    {
        engineStartButton = false;
        greenMeshRenderer.material = greenNormalColor;
        //rendererls.color = Color.green;
        transform.localPosition = new Vector3(1f, 0f, 0f);
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    private void Grab(SelectEnterEventArgs args0)
    {
        currentInteractor = args0.interactorObject;
        Debug.Log("Grab Entered red button");


        if(redStartButton.alert)
        {
            if (engineStartButton == false)
            {
                engineStartButton = true;
                //rendererls.color = Color.blue;
                greenMeshRenderer.material = greenEmissiveColor;
                transform.localPosition = new Vector3(1f, buttonposition, 0f);

            }
        }
       
        //else
        //{
        //    //engineStartButton = false;
        //    //greenMeshRenderer.material = greenNormalColor;
        //    ////rendererls.color = Color.green;
        //    //transform.localPosition = new Vector3(1f, 0f, 0f);

        //}

    }


   
    private void UnGrab(SelectExitEventArgs args0)
    {
        Debug.Log("UnGrabbing red button");
        currentInteractor = null;
    }
    #endregion
    


}




