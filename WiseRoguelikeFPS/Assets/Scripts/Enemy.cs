using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Reference to the enemy object prefab
    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {

    }

    // This method destroys the current enemy object
    public void DestroyEnemy()
    {
        // If the enemy object exists, destroy it
        if (enemy != null)
        {
            Destroy(enemy);
        }
    }
}