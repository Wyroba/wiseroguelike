using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // The target that the enemy will chase and attack
    [SerializeField] Transform target;

    // The range at which the enemy will start chasing the target
    [SerializeField] float chaseRange = 10f;

    NavMeshAgent navMeshAgent;

    // The distance between the enemy and the target
    float distanceTotarget = Mathf.Infinity;

    // Whether or not the enemy has been provoked (i.e. the player has attacked it)
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        // Find the target object by name
        target = GameObject.Find("Player").transform;
        // Get the NavMeshAgent component attached to this GameObject
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance to the target
        distanceTotarget = Vector3.Distance(target.position, transform.position);

        // If the enemy is provoked (i.e. the player has attacked it), engage the target
        if(isProvoked)
        {
            EngageTarget();
        }
        // If the target is within range, provoke the enemy (i.e. make it start chasing the target)
        else if (distanceTotarget <= chaseRange)
        {
            isProvoked = true;
        }

    }

    // Draw a red wire sphere around the enemy to indicate its chase range in the Scene view
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    // Engage the target by either chasing it or attacking it, depending on the distance to the target
    public void EngageTarget()
    {
        // If the enemy is not close enough to attack, chase the target
        if (distanceTotarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        // If the enemy is close enough to attack, attack the target
        if(distanceTotarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }

    }

    // Set the enemy's Animator component to move and set its destination to the target's position
    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    // Set the enemy's Animator component to attack
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }
}