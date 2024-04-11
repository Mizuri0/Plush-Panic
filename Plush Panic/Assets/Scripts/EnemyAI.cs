
using UnityEngine;
using UnityEngine.AI;

public class EnemyAItutorial : MonoBehaviour
{ 
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    
    //Attacking 
    public float timeBetweenAttacks;
    bool alreadyAttacked;
      
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake ()
    { 
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update() 
    { 
        //Check for sight and attack range 
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling(); 
        if (playerInSightRange && !playerInAttackRange) ChasePlayer(); 
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling() 
    { 
        if (!walkPointSet) SearchWalkPoint(); 
    } 
    private void SearchWalkPoint() 
    { 
        //Caclculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.y, transform.position.z + randomZ)

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
}