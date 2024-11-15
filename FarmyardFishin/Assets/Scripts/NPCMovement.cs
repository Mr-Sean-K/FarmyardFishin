using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    // This controls which way the NPC is moving (right or left)
    private bool isMovingRight = true;

    // How fast the NPC moves
    public float speed = 2f;

    // This method will be called from the SpawnManager to tell the NPC which way to go
    public void SetDirection(bool moveRight)
    {
        isMovingRight = moveRight;  // Set the movement direction based on the spawn position
    }

    void Update()
    {
        
        float direction = isMovingRight ? 1f : -1f;  // 1 means move right, -1 means move left

        // Move the fish in the correct direction, based on the speed
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }
}
