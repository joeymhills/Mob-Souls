using Unity.VisualScripting;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    
    Animator animator;

    public float speed = 3f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Hashing to increase performance

    }
    void Update() {


        //Running animations

        bool isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
        bool movePressed = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        //if player is pressing a move key, sets walking to true




        // Camera Settings
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) { 
            
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (animator.GetBool("attack1") == true)
        {

            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);

        }
        if (!isWalking && (movePressed && !runPressed))
        {

            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
            speed = 3f;

            print("isRunning");
            print(isRunning);
            print("isWalking");
            print(isWalking);



        }
        //if player is not pressing move key, sets walking to false
        if (isWalking && !movePressed)
        {

            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);


            print("isRunning");
            print(isRunning);
            print("isWalking");
            print(isWalking);

        }
        //if player is walking and presses left shift
        if (!isRunning && (movePressed && runPressed))
        {

            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);
            speed = 6f;

            print("isRunning");
            print(isRunning);
            print("isWalking");
            print(isWalking);

        }
        //if player is running and stops running or stops walking
        if (isRunning && (!movePressed || !runPressed))
        {

            animator.SetBool("isRunning", false);

            print("isRunning");
            print(isRunning);
            print("isWalking");
            print(isWalking);

        }
    } 
}
