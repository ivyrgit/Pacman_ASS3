using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    // four corners that PS moves towards
    private Vector3 topLeft = new Vector3(-9, 3, 0);
    private Vector3 topRight = new Vector3(-4, 3, 0);
    private Vector3 bottomRight = new Vector3(-4, -1, 0);
    private Vector3 bottomLeft = new Vector3(-9, -1, 0);

    private Vector3[] corners;
    private int currentCornerIndex = 0;

    public float speed = 2f; 

    private Animator animator; 

    void Start()
    {
      
        corners = new Vector3[] { topLeft, topRight, bottomRight, bottomLeft };

        transform.position = corners[currentCornerIndex];

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = corners[currentCornerIndex];

        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(currentPosition, targetPosition) < 0.1f)
        {
            currentCornerIndex = (currentCornerIndex + 1) % corners.Length;
        }

        Vector3 movement = targetPosition - currentPosition;

        movement.Normalize();

        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            if (movement.x > 0) // if moving right
            {
                animator.SetInteger("direction_num", 1); // set param to right
            }
            else // if moving left
            {
                animator.SetInteger("direction_num", 3); // set param to left
            }
        }
        else 
        {
            if (movement.y > 0) // if moving up
            {
                animator.SetInteger("direction_num", 4); // set param to up
            }
            else // if moving down
            {
                animator.SetInteger("direction_num", 2); // set param to down
            }
        }

    }


}

