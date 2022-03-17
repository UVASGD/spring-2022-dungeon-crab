using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the player movement script. It uses the player's character controller in order to move around in response to input.

// For right now this script is also handling changing the water level- this might change later
public class playermovement : MonoBehaviour
{

    public CharacterController controller;
    private Transform cam;
    private GameManager gm;

    public Animator anim;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    public float gravity = -10f;
    float turnSmoothVelocity;

    public float jumpHeight = 10f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float pushPower = 2.0F;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg+cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        //Temporary Things- set water/lava levels with numbers
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gm.waterLevel = 0;
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gm.waterLevel = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            gm.lavaLevel = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            gm.lavaLevel = 1;
        }
    }

    //handle interactions with rigidbodies (try to push them)
    //this is what lets us push boxes and things
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
            return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f)
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lava"){
            gm.RestartScene();
        }
    }
}
