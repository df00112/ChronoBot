using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    Transform player;
    float chaseRange = 7;
    float patrolSpeed = 1.5f;
    float minPatrolTime = 5f;
    float maxPatrolTime = 15f;

    Vector3 currentDestination;
    bool isPatrolling;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform t in go.transform)
            wayPoints.Add(t);

        SetRandomDestination();
        isPatrolling = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (isPatrolling)
        {
            animator.transform.LookAt(currentDestination);
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, currentDestination, patrolSpeed * Time.deltaTime);

            if (Vector3.Distance(animator.transform.position, currentDestination) < 0.1f)
            {
                SetRandomDestination();
            }

            float distance = Vector3.Distance(player.position, animator.transform.position);
            if (distance < chaseRange)
            {
                animator.SetBool("isChasing", true);
                isPatrolling = false;
            }
        }

        timer += Time.deltaTime;
        if (timer > Random.Range(minPatrolTime, maxPatrolTime))
        {
            animator.SetBool("IsPatrolling", false);
            isPatrolling = false;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
    }

    void SetRandomDestination()
    {
        currentDestination = wayPoints[Random.Range(0, wayPoints.Count)].position;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
