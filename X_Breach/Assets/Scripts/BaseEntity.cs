using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity
{
    public float distToCover, jumpForce, decFactor;
    public int maxHealth = 100, health, damage;

    //Jumping is handled externally
    public bool isGrounded;

    public BaseEntity(float ds = 0.1f, 
        float jmpForce = 6f, float dcFac = 0.3f, int hlth = 100, int dm = 20)
    {
        distToCover = ds;
        jumpForce = jmpForce;
        decFactor = dcFac;

        health = hlth;
        damage = dm;

        isGrounded = false;
    }

    public float Move(string dir, float origin)
    {
        if (dir == "Left")
        {
            if (isGrounded)
                origin -= distToCover;
            else
                origin -= distToCover * decFactor;
        } 
        else if (dir == "Right") 
        {
            if (isGrounded)
                origin += distToCover;
            else
                origin += distToCover * decFactor;
        }

        return origin;
    }

    public void Jump(Rigidbody2D _rb)
    {
        if (isGrounded)
            _rb.velocity = Vector2.up * jumpForce;
    }

    public void CauseDamage(BaseEntity other) { other.TakeDamage(damage); }

    public void TakeDamage(int dmg)
    {
        if (!IsDead())
            health -= dmg;
    }

    public bool IsDead() { return health == 0; }
}
