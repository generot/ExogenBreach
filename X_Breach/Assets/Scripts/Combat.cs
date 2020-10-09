using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public float attackRange;
    public LayerMask hostile;
    public int dmg;

    Animator animator;
    Transform point;

    void Start()
    {
        point = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("IsFighting", true);
            Melee();
        }

        if(Input.GetMouseButtonUp(1))
            animator.SetBool("IsFighting", false);
    }
    void Melee()
    {
        Collider2D[] entity_array = Physics2D.OverlapCircleAll(point.position, attackRange, hostile);
        foreach (Collider2D Enemy in entity_array)
        {
            Debug.Log("we hit " + Enemy);

            if(animator.GetBool("IsFighting"))
                Enemy.gameObject.GetComponent<Enemy>().b_entity.TakeDamage(dmg);

            Debug.Log(Enemy.gameObject.GetComponent<Enemy>().b_entity.health);

            if (Enemy.gameObject.GetComponent<Enemy>().b_entity.health <= 0)
            {
                Destroy(Enemy.gameObject, 0);
            }
        }
    }
}
