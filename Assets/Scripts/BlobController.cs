using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlobController : MonoBehaviour
{
    public float moveSpeed;

    public float minJumpForce;
    public float maxJumpForce;
    public float jumpTime;


    private float currentJumpTime;
    private float jumpForce;
    private bool isJumping = false;

    public Vector2 feetSize;
    public float feetDistX;
    public float feetDistY;
    public LayerMask ground;

    public Vector2 respawn;

    public GameObject cam;

    private SpriteRenderer sprite;
    public Sprite leftSprite;
    private Sprite rightSprite;

    private bool facingRight = true;

    private bool isDashing = false;
    public float dashDist;
    public float dashSpeed;
    private float dashEndX;



    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rightSprite = sprite.sprite;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        respawn = transform.position;
        //Remove when level finish:
        transform.position = new Vector2(35f, 1.5f);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (isDashing == false)
            {
                //Decides whether sprite faces left or right
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    sprite.sprite = leftSprite;
                    facingRight = false;
                }
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    sprite.sprite = rightSprite;
                    facingRight = true;
                }
                
                //Walks left to right
                float horizontal = Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

                Jump();
            }

            if (SceneManager.GetActiveScene().buildIndex >= 2)
            {
                Dash();
            }
        }
    }
    void Jump()
    {
        if (Grounded() && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            currentJumpTime = jumpTime;
            jumpForce = minJumpForce;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            jumpForce *= 2;
            if (jumpForce > maxJumpForce)
            {
                jumpForce = maxJumpForce;
            }

            if (currentJumpTime > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                currentJumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    void Dash()
    {
        if (isDashing)
        {
            if (facingRight)
            {
                rb.velocity = new Vector2(dashSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-dashSpeed, rb.velocity.y);
            }

            if ((facingRight && transform.position.x > dashEndX) || (!facingRight && dashEndX > transform.position.x))
            {
                isDashing = false;
                rb.gravityScale = 2.5f;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                isDashing = true;
                isJumping = false;
                rb.velocity = new Vector2(0, 0);
                rb.gravityScale = 0;
                if (facingRight)
                {
                    dashEndX = transform.position.x + dashDist;
                }
                else
                {
                    dashEndX = transform.position.x - dashDist;
                }
            }
        }
    }

    public void Die()
    {
        isDashing = false;
        rb.gravityScale = 2.5f;
        transform.position = respawn;
    }

    public bool Grounded()
    {
        if (Physics2D.BoxCast(transform.position, feetSize, 0, -transform.up, feetDistY, ground)) {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damage"))
        {
            Invoke("Die", 0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Grounded() && isDashing)
        {
            Debug.Log("Wall");
            isDashing = false;
            rb.gravityScale = 2.5f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * feetDistY, feetSize);
    }

}
