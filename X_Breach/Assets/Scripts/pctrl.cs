using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState
{
    Idle,
    Running
};

public class pctrl : MonoBehaviour
{
    public BaseEntity b_entity;

    Rigidbody2D rb;
    Animator anim;

    PlayerState pState;
    Vector3 scl;

    void Start()
    {
        b_entity = new BaseEntity();
        scl = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //healthBar.value = (float)b_entity.health / b_entity.maxHealth;
        //health.text = ((int)((float)b_entity.health * b_entity.maxHealth / 100)).ToString() + "%";

        DieIfDead();
    }

    void FixedUpdate()
    {
        GetComponent<Transform>().position = HandleMovement(transform);
        HandleJump(rb);

        if (pState == PlayerState.Idle)
            anim.SetBool("IsRunning", false);
        else
            anim.SetBool("IsRunning", true);

        pState = PlayerState.Idle;
    }

    public Vector2 HandleMovement(Transform pos)
    {
        Vector2 _pos = pos.position;

        if (Input.GetKey(KeyCode.A))
        {
            _pos.x = b_entity.Move("Left", pos.position.x);
            transform.localScale = new Vector3(-scl.x, scl.y, scl.z);

            pState = PlayerState.Running;
        }

        if (Input.GetKey(KeyCode.D)) {
            _pos.x = b_entity.Move("Right", pos.position.x);
            transform.localScale = new Vector3(scl.x, scl.y, scl.z);

            pState = PlayerState.Running;
        }
        
        return _pos;

    }

    public void HandleJump(Rigidbody2D _rb)
    {
        if (Input.GetKey(KeyCode.Space))
            b_entity.Jump(_rb);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            b_entity.isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            b_entity.isGrounded = false;
    }

    void DieIfDead()
    {
        if (b_entity.IsDead())
            Destroy(gameObject);
    }
}
