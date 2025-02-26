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


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        Jump();
    }

    void Jump()
    {
        if (grounded() && Input.GetButtonDown("Jump"))
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

    public bool grounded()
    {
        if (Physics2D.BoxCast(transform.position, feetSize, 0, -transform.up, feetDist, ground)) {
            Debug.Log("AAAAAAAA");
            return true;
        }
        else
        {
            Debug.Log("BBBBBBBBBBBBBB");
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * feetDist, feetSize);
    }

}
