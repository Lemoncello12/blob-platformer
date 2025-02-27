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

    private Vector2 respawn;

    public GameObject cam;

    private SpriteRenderer sprite;
    public Sprite leftSprite;
    private Sprite rightSprite;


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rightSprite = sprite.sprite;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        respawn = transform.position;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sprite.sprite = leftSprite;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            sprite.sprite = rightSprite;
        }
        Jump();
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
            Die();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * feetDist, feetSize);
    }

}
