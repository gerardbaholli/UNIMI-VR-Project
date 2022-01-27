using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShootingSystem : MonoBehaviour
{

    public int gunDamage = 1;                                            // Set the number of hitpoints that this gun will take away from shot objects with a health script
    public float fireRate = 4f;                                        // Number in seconds which controls how often the player can fire
    public float weaponRange = 150f;                                        // Distance in Unity units over which the player can fire
    public float hitForce = 100f;                                        // Amount of force which will be added to objects with a rigidbody shot by the player
    public Transform gunEnd;                                            // Holds a reference to the gun end object, marking the muzzle location of the gun

    private WaitForSeconds shotDuration = new WaitForSeconds(2f);    // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
    private float nextFire;                                                // Float to store the time the player will be allowed to fire again, after firing



    void Update()
    {
        // Check if the player has pressed the fire button and if enough time has elapsed since they last fired
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;

            // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine(ShotEffect());

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Check if our raycast has hit anything
            if (Physics.Raycast(ray, out hit, weaponRange))
            {
                // Get a reference to a health script attached to the collider we hit
                TestEnemy health = hit.collider.GetComponent<TestEnemy>();

                // If there was a health script attached
                if (health != null)
                {
                    // Call the damage function of that script, passing in our gunDamage variable
                    health.Damage(gunDamage);
                }

                // Check if the object we hit has a rigidbody attached
                if (hit.rigidbody != null)
                {
                    // Add force to the rigidbody we hit, in the direction from which it was hit
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }

        }
    }


    private IEnumerator ShotEffect()
    {
        //Wait for .07 seconds
        yield return shotDuration;
    }


}
