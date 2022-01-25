using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ShootingSystem : MonoBehaviour
{
    //[SerializeField] GameObject bullet;

    [SerializeField] GameObject arCamera;

    private GameStatus gameStatus;
    private ARRaycastManager arRaycastManager;
    

    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }


    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                gameStatus.AddPointsToScore(hit.transform.gameObject.GetComponent<Enemy>().GetPointsForKilling());
                Destroy(hit.transform.gameObject);
            }
        }
    }



    /*
    void Update()
    {
        if (gameStatus.IsGameStarted())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var shootingSight = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
            var hits = new List<ARRaycastHit>();
            arRaycastManager.Raycast(shootingSight, hits, TrackableType.Planes);

            Instantiate(bullet, hits[0].pose.position, Quaternion.identity);
        }
    }
    */

}
