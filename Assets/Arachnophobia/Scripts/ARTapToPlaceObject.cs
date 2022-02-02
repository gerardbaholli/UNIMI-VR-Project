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


/*
public class ARTapToPlaceObject : MonoBehaviour
{
    [SerializeField] Camera arCamera;
    [SerializeField] ARRaycastManager arRaycastManager;
    [SerializeField] GameObject spawnablePrefab;

    private UIManager uiManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject spawnedObject;

    private Pose placementPose;
    private bool placementPoseIsValid = false;
    private bool isObjectPlaced = false;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        spawnedObject = null;
    }

    private void Update()
    {
        if (Input.touchCount == 0)
            return;

        RaycastHit hit;
        Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);

        // se la posizione che tocchi non ? null
        if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits))
        {
            // se il tocco ? avvenuto appena appoggiato il dito allo schermo
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!isObjectPlaced)
                {
                    // se il raycast non ? null
                    if (Physics.Raycast(ray, out hit))
                    {
                        SpawnPrefab(hits[0].pose.position);
                    }
                }
                else
                {
                    // se il raycast non ? null
                    if (Physics.Raycast(ray, out hit))
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    
                }
            }
            // se il tocco ? nella fase di movimento e l'oggetto spawnato non ? null
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                // sposta l'oggetto spawnato nella posizione in cui hai colpito per ultimo
                spawnedObject.transform.position = hits[0].pose.position;
            }

        }
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        isObjectPlaced = true;
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
        uiManager.ShowStartUI();
    }

}
*/
