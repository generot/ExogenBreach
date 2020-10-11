using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public LayerMask mask;

    float attackRange = 1f;
    int dmg = 8;

    rcast rc;
    Animator animator;

    void Start()
    {
        rc = new rcast(mask, dmg, attackRange);

        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1) && !animator.GetBool("IsFighting"))
        {
            animator.SetBool("IsFighting", true);
            rc.Hit(transform.position, transform.localScale, Vector2.right);
        }

        if(Input.GetMouseButtonUp(1))
            animator.SetBool("IsFighting", false);
    }
}
