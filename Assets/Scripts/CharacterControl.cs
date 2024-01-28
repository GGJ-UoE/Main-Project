using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool groundedPlayer;
    public float gravityMultiplier = 2f;
    public Animator animator;
    public Transform body;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    private int remainingJumps = 2;
    private float direction=90;
    float dir=1;
    public static int attackType;
    private void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            remainingJumps = 2;
        }
        float x = Input.GetAxis("Horizontal");
        float x_raw = Input.GetAxisRaw("Horizontal");

        Vector3 move = new Vector3(x, 0, 0);
        controller.Move(move * Time.deltaTime * moveSpeed);
        if (x_raw != 0)
            dir=x_raw;

        body.rotation = Quaternion.Euler(0, direction * dir, 0);
        animator.SetInteger("run", (int)x_raw);
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && (groundedPlayer || remainingJumps > 0))
        {
            remainingJumps--;

            animator.SetTrigger("jump");
 
            playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravityValue);
            if (remainingJumps == 0)
            {
                if(playerVelocity.y< Mathf.Sqrt(jumpForce * -3.0f * gravityValue))
                {
                    playerVelocity.y = Mathf.Sqrt(jumpForce * -3.0f * gravityValue);
                }
            }
        }
        // jump attack //
        if (Input.GetKeyDown(KeyCode.Q) && !groundedPlayer && remainingJumps>0)
        {
            animator.SetTrigger("attack1");
            attackType = 1;
        }
        // slide attack //
        else if (x >= 0.8f || x <= -0.8f && groundedPlayer && remainingJumps==2)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.LogError("came");
                attackType = 2;
                animator.SetTrigger("slide");

            }
        }
        playerVelocity.y += gravityValue * Time.deltaTime * gravityMultiplier;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void KillImmediately()
    {
        Debug.LogError("player died");
    }
    public void die()
    {
        animator.SetTrigger("die");
        controller.enabled = false;
        Destroy(gameObject, 3f);
    }

}
