using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;        // The first-person camera that will be used for raycasting
    [SerializeField] float range = 100f;    // The maximum range of the raycast
    [SerializeField] float damage = 50f;    // The amount of damage the weapon will deal
    [SerializeField] ParticleSystem muzzleFlash;  // The particle effect to play when firing
    [SerializeField] GameObject hitEffect;  // The gameobject to instantiate at the hit location

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))   // If the player presses the fire button
        {
            Shoot();    // Call the Shoot function
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();  // Play the muzzle flash particle effect
        ProcessRaycast();   // Process the raycast to check for hits
    }

    // Process the raycast to check for hits
    public void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);   // Create the hit effect at the point of impact
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();  // Get the EnemyHealth component of the hit object
            if (target == null) return;   // If there is no EnemyHealth component, return
            target.TakeDamage(damage);    // Otherwise, call the TakeDamage function on the EnemyHealth component to deal damage
        }
        else
        {
            return;     // If the raycast does not hit anything, return
        }
    }

    // Instantiate the hit effect at the point of impact
    public void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy (impact, .1F);  // Destroy the hit effect after a short delay
    }

    // Play the muzzle flash particle effect
    public void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}
