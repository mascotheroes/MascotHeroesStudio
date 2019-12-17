using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float speed;
    public float jumpforce;

    [SerializeField] float groundCheckDistance;
    protected SpriteRenderer sr;

    protected Rigidbody2D rb;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }
    public virtual void Move(int dir)
    {
        if(dir > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        transform.position += Vector3.right * dir * speed * Time.deltaTime;
    }

    public virtual void Jump()
    {
        if (CheckGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
       
    }

    public virtual bool CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down ,groundCheckDistance);
        Debug.Log(hit.collider);
        if(hit.collider == null)
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }
}
