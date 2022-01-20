using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARTapToPlaceObject : MonoBehaviour
{
    [SerializeField] GameObject objectToPlace;
    [SerializeField] GameObject placementIndicator;

    private UIManager uiManager;

    private ARRaycastManager arRaycastManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    private bool isObjectPlaced = false;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.HideStartUI();
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    private void Update()
    {
        if (!isObjectPlaced)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
            CheckUserTouchToPlaceObject();
        }
    }

    private void CheckUserTouchToPlaceObject()
    {
        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            isObjectPlaced = true;
            Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
            uiManager.ShowStartUI();
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }   
    }

}
