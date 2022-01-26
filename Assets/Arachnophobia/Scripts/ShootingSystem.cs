using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] GameObject arCamera;
    [SerializeField] AudioClip pistolSound;

    private GameStatus gameStatus;
    private AudioSource audioSource;
    

    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        audioSource = GetComponent<AudioSource>();
    }


    public void Shoot()
    {
        audioSource.PlayOneShot(pistolSound);

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

}
