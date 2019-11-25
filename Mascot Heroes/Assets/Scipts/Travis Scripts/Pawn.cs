using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public float speed;

    public float jumpforce;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    public void Move(int dir)
    {
        transform.position += Vector3.right * dir * speed * Time.deltaTime;
    }

    public void Jump()
    {
        rb.velocity = new Vector2(0, jumpforce);
    }
}
