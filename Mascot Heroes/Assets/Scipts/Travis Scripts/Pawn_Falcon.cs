using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_Falcon : Pawn
{
    public override void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
    }
}
