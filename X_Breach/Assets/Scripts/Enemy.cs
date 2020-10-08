using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public BaseEnemy b_enemy;
    public BaseEntity b_entity;

    public Transform player;

    Rigidbody2D rb;
    Animator anim;
    Vector2 scl;

    void Start()
    {
        b_entity = new BaseEntity(b_enemy.speed, 0f, 0.3f, b_enemy.health, b_enemy.dmg);

        rb = GetComponent<Rigidbody2D>();
        scl = GetComponent<Transform>().localScale;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player)
        {
            Vector2 distVec = player.position - transform.position;
            float distSq = distVec.x * distVec.x + distVec.y * distVec.y;

            if (distSq > 16f)
            {
                rb.velocity = WalkTo(transform.position, player.position);
                anim.SetBool("IsRunning", true);
            }
            else anim.SetBool("IsRunning", false);

            if (Vector2.Dot(Vector2.left, distVec) < 0)
                transform.localScale = new Vector2(-scl.x, scl.y);
            else
                transform.localScale = new Vector2(scl.x, scl.y);
        }
    }

    public Vector2 WalkTo(Vector2 pos, Vector2 toWalkTo)
    {
        return Vector2.ClampMagnitude(toWalkTo - pos, 1f) * b_entity.distToCover;
    }
}
