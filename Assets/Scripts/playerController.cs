using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    
    public Animator animator;
    public Rigidbody2D rb;
    public float jumpForce;
    public float playerSpeed;
    public Vector2 jumpHeight;
    private bool isOnGround;
    public float positionRadius;
    public LayerMask ground;
    public Transform playerPosition;

    public ParticleSystem dust;


    [SerializeField] private HealthBar healthBar;

    public Button jumpButton;

    // For Android Controll
    public Joystick joystick;

    void Start()
    {
        if(GameObject.FindGameObjectWithTag("CanvasAndroid") != null)
        {
            joystick = GameObject.FindGameObjectWithTag("fixedJoystick").GetComponent<Joystick>();
            jumpButton = GameObject.FindGameObjectWithTag("jumpButton").GetComponent<Button>();
        }
            

        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        
        for (int i = 0; i < colliders.Length; i++)
        {
            for(int j = i + 1; j < colliders.Length; j++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // shoot
        //if(Input.GetMouseButtonDown(0))
        //{
        //   Instantiate(bullet, transform.position, Quaternion.identity);
        //}

        // For Android Controll
        if(joystick != null)
        {
            if (joystick.Horizontal > 0.0f)
            {
                animator.Play("player-walk");
                rb.AddForce(Vector2.right * playerSpeed );
                if (isOnGround) CreateDust();
            }
            else if (joystick.Horizontal < 0.0f)
            {
                animator.Play("player-walk-back");
                rb.AddForce(Vector2.left * playerSpeed );
                if (isOnGround) CreateDust();
            }
        }
        

        // for Computer Controll
        if (Input.GetAxisRaw("Horizontal") != 0)
        { 
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                animator.Play("player-walk");
                rb.AddForce(Vector2.right * playerSpeed  );
                if (isOnGround) CreateDust();
            }
            else
            {
                   
                animator.Play("player-walk-back");
                rb.AddForce(Vector2.left * playerSpeed );
                if(isOnGround) CreateDust();
            }
        }
        else
        {
            animator.Play("player-idle");
        }

        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();   
        }

    }
   
    public bool checkOnGround()
    {
        return Physics2D.OverlapCircle(playerPosition.position, positionRadius, ground);
    }
    public void jump()
    {
        if(checkOnGround())
        {
            CreateDust();
            rb.AddForce(Vector2.up * jumpForce);
        }
        
    }
    void CreateDust()
    {
        dust.Play();
    }
 

}
