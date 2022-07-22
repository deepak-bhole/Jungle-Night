using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] float chaseTrigger = 10f;
    [SerializeField] float chaseRange = 25f;
    [SerializeField]  float turnSpeed = 5f;
    [SerializeField] float WalkSpeed = 1f;

    [SerializeField] float wanderRadius = 10;


    EnemyHealth health;
    CapsuleCollider capsuleCollider;
    Transform Target;
    NavMeshAgent navMeshAgent;

    bool isprovoked = false;
    bool isRunning = false;

    private float timerWander;
    private  Vector3 wanderPoint;
    float DistanceToTarget = Mathf.Infinity;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        wanderPoint = RandomWanderPoint();
        health = GetComponent<EnemyHealth>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        Target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        if(health.Isdead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
            capsuleCollider.enabled = false;
        }

        DistanceToTarget = Vector3.Distance(Target.position, transform.position);
   
        if(isprovoked && DistanceToTarget < chaseRange) EngageTarget();

        else if(DistanceToTarget <= chaseTrigger) isprovoked = true;

        else Wander();

        RunningOrWandering(isRunning);
    }

    private void EngageTarget()
    {  
        FaceTarget();
        if (DistanceToTarget > navMeshAgent.stoppingDistance)           chaseTarget();
        else if (DistanceToTarget <= navMeshAgent.stoppingDistance)     attackTarget();
    }

    private void FaceTarget()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * turnSpeed);
    }

    private void chaseTarget()
    {
        isRunning = true;
        if (navMeshAgent.enabled && isRunning) navMeshAgent.SetDestination(Target.position);
    }

    private void attackTarget()
    {
        isRunning = false;
        GetComponent<Animator>().SetBool("Attack", true);
       
    }

    public void OnDamageTaken()
    {
        StartCoroutine(DamageRun());
    }

    IEnumerator DamageRun()
    {
        isRunning = true;
        yield return new WaitForSeconds(10);
        isRunning = false;
    }
    void Wander()
    {
       
        isRunning = false;
        timerWander += Time.deltaTime;
        if (Vector3.Distance(transform.position, wanderPoint) < 3f || timerWander > 5)
        {
            wanderPoint = RandomWanderPoint();
            timerWander = timerWander - 5;
        }
        else if (navMeshAgent.enabled)   navMeshAgent.SetDestination(wanderPoint);
    }

    public Vector3 RandomWanderPoint()
    {
        RunningOrWandering(isRunning);
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }

    private void RunningOrWandering(bool isrunning)
    {
        if(isRunning)
        {
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Animator>().SetBool("Move", true);
            navMeshAgent.speed = 3.5f;
            navMeshAgent.acceleration = 8;
            navMeshAgent.angularSpeed = 120;
        }
        else
        {
            GetComponent<Animator>().SetBool("Move", false);
            navMeshAgent.speed = 0.3f * WalkSpeed;
            navMeshAgent.acceleration = 0.5f;
            navMeshAgent.angularSpeed = 50;
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseTrigger);
    }
}

    