using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 5f;

    Animator animator;
    int wayPointIndex = 0;
    public bool canMove = true;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = waypoints[wayPointIndex].position;      
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (canMove)
        {
            if (waypoints != null) 
            {
                if (wayPointIndex < waypoints.Count)
                {
                    animator.SetTrigger("isRunning");
                    animator.ResetTrigger("canAttack");
                    Vector3 targetPos = waypoints[wayPointIndex].position;
                    transform.position = Vector3.MoveTowards(transform.position,
                        targetPos,
                        moveSpeed * Time.deltaTime);


                    if (transform.position == targetPos)
                    {

                        TurnRight();
                        wayPointIndex++;
                    }
                }
                else
                {
                    wayPointIndex = 0;
                }
            }
        }
    }

    void TurnRight()
    {
        transform.Rotate(0, 90, 0);
    }
}
