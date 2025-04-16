using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    public float feetDist;
    public LayerMask ground;

    public Vector2 respawn;

    public GameObject cam;

    bool facingRight = true;

    private SpriteRenderer sprite;
    public Sprite leftSprite;
    private Sprite rightSprite;

    public float dashTime;
    private float dashForce;


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rightSprite = sprite.sprite;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        respawn = transform.position;
        //Remove when level finish:
        //transform.position = new Vector2(82f, 6.9f);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (facingRight)
        {
            sprite.sprite = rightSprite;
        }
        else
        {
            sprite.sprite = leftSprite;
        }
            float horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                facingRight = false;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                facingRight = true;
            }
            Jump();
            if (dashForce != 0)
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (facingRight)
            {
                Debug.Log("Should be dashing right");
                rb.velocity = new Vector2(dashForce, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-dashForce, rb.velocity.y);
            }
        }
    }

    public void Die()
    {
        transform.position = respawn;
    }

    public bool Grounded()
    {
        if (Physics2D.BoxCast(transform.position, feetSize, 0, -transform.up, feetDist, ground)) {
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * feetDist, feetSize);
    }

}
