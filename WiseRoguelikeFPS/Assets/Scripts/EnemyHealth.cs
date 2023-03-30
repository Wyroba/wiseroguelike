using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;

    public void TakeDamage(float damage)
    {
        hitpoints -= damage;
        if (hitpoints <= 0)
        {
            GetComponent<Animator>().SetTrigger("hit");
            Invoke("DestroyEnemy", 2.1F);
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
