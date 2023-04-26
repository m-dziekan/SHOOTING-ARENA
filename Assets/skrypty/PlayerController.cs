using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    private float moveVelocity;

    private Rigidbody2D myrigidbody2D;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Animator anim;

    public GameObject bullet;
    public Transform shootingPoint;
    public GameObject muzzleFlash;
    public Transform flashPoint;

    public KeyCode right;
    public KeyCode left;
    public KeyCode jump;
    public KeyCode shot;

    public AudioSource sound;

    // Use this for initialization
    void Start ()
    {
       
        myrigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (Input.GetKey(jump) && grounded)
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, jumpHeight * Time.deltaTime);

        }

        moveVelocity = 0f;

        if (Input.GetKey(right))
        {
            moveVelocity = moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(left))
        {
            moveVelocity = -moveSpeed * Time.deltaTime;
        }

        myrigidbody2D.velocity = new Vector2(moveVelocity, myrigidbody2D.velocity.y);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); //czy dotyka ziemi

        

        if(myrigidbody2D.velocity.x <0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (myrigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed",Mathf.Abs(myrigidbody2D.velocity.x));
        anim.SetBool("Grounded", grounded);
    }

    private void Update()
    {
        if (Input.GetKeyDown(shot))
        {
            GameObject bullet_clone = (GameObject)Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
            GameObject muzzle_Flash = (GameObject)Instantiate(muzzleFlash, flashPoint.position, flashPoint.rotation);
            sound.Play();
        }
    }
}
