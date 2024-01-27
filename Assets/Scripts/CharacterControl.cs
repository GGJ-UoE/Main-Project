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
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    private int remainingJumps = 2;
    private float direction=90;
    float dir=1;
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

        animator.transform.rotation = Quaternion.Euler(0, direction * dir, 0);
        animator.SetInteger("run", (int)x_raw);
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && (groundedPlayer || remainingJumps > 0))
        {
            remainingJumps--;

            animator.SetTrigger("jump");
            playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravityValue);

        }
        
        playerVelocity.y += gravityValue * Time.deltaTime * gravityMultiplier;
        controller.Move(playerVelocity * Time.deltaTime);
    }

}
