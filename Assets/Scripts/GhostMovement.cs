using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private Animator animator;

    // Array of state integers representing the transition cycle
    private int[] stateCycle = { 1, 2, 3, 4, 5, 6, 7 }; // Down, Left, Up, Right, Scared, Recovering, Dead

    private void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();

        // Start the coroutine to cycle through states
        StartCoroutine(CycleThroughStates());
    }

    private IEnumerator CycleThroughStates()
    {
        int transitionIndex = 0;

        while (true) // Infinite loop to keep cycling
        {
            // Set the current state based on the transition index
            animator.SetInteger("GhostState", stateCycle[transitionIndex]);

            // Wait for 3 seconds before transitioning to the next state
            yield return new WaitForSeconds(3f);

            // Update the transition index, looping back if necessary
            transitionIndex = (transitionIndex + 1) % stateCycle.Length;
        }
    }
}
