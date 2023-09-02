using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;



    private float dirX = 0f;
    int contt = 0;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float walkForce = 30;

    private enum MovementState {idle, running, jumping, falling }
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource walkSoundEffect;
    [SerializeField] private AudioSource walkSoundEffect2;
    // private MovementState state = MovementState.idle;
    // int wholenumber     = 16;
    // float decimalNumber = 4.54f;
    // string text = "blabla";
    // bool boolean = true;
    // Start is called before the first frame update
    private void Start()
    {
        rb     = GetComponent<Rigidbody2D>();
        coll   = GetComponent<BoxCollider2D>();
        anim   = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        contt++;
        dirX  = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded() )
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            if (contt % walkForce == 0 && rb.velocity.y < .5f && rb.velocity.y > -.5f) { Invoke("Walking", 0f); }
            if (contt % walkForce == 3 && rb.velocity.y < .5f && rb.velocity.y > -.5f) { Invoke("Walking2", 0f); }
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            
            state = MovementState.running;
            if (contt % walkForce == 0 && rb.velocity.y < .5f && rb.velocity.y > -.5f) { Invoke("Walking", 0f); }
            if (contt % walkForce == 3 && rb.velocity.y < .5f && rb.velocity.y > -.5f) { Invoke("Walking2", 0f); }
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y >.1f)
        {
            state = MovementState.jumping;

        }
        else if (rb.velocity.y<-.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);

    }
    private void Walking()
    {
        walkSoundEffect.Play();
    }
    private void Walking2()
    {
        walkSoundEffect2.Play();
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
