using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private bool faceRight = false;
    [SerializeField] private bool oneDirection = false;
    [SerializeField] private bool affectedByGravity = false;
    [SerializeField] private Transform floorChecker;
    private bool isGrounded;
    
    private float gravity = -9.81f;
    private Animator anim;
    private CharacterController controller;
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        controller = transform.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = controller.isGrounded;
        if (!oneDirection)
        {
            if (WillFall() || WillCollide())
            {
                FlipDirection();
            }
        }
        controller.Move(transform.forward * Time.deltaTime * speed);
        WillCollide();
        Debug.Log("Will collide: " + WillCollide());

    }

    void FlipDirection()
    {
        speed = -speed;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
    }

    private bool WillFall()
    {
        if (floorChecker == null)
            return false;

        Ray ray = new Ray(floorChecker.position, Vector3.down);
        float range = 1f;
        //Debug.DrawRay(floorChecker.position, Vector3.down,Color.red);
        return !Physics.Raycast(ray, range);
    }

    private bool WillCollide() {
        Ray ray = new Ray(transform.position + transform.forward * 0.1f, transform.forward);
        float range = 1f;
        Debug.DrawRay(transform.position + transform.forward * 0.1f, transform.forward, Color.blue);
        return Physics.Raycast(ray, range);
    }

}
