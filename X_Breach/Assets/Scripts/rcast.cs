using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcast : MonoBehaviour
{
    public float units;
    public int damage;
    public Transform sPoint;
    //public LayerMask Target;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(shoot(sPoint, Vector2.right));
        }
    }
    IEnumerator shoot(Transform transform, Vector2 Pos)
    { 
        RaycastHit2D enemyInf = Physics2D.Raycast(transform.position, Pos, units);
        if (enemyInf && enemyInf.collider.CompareTag("Enemy")) {
            Enemy hostile = enemyInf.transform.GetComponent<Enemy>();
            if (hostile != null)
            {
                hostile.b_entity.TakeDamage(damage);
                Debug.Log(hostile.b_entity.health);
                yield return 0; //for now because its a coroutine, but later because it will be an animation :)

                if (hostile.b_entity.health <= 0)
                {
                    yield return 0; //same as ^
                    Destroy(hostile.gameObject, 0);
                }
            }
        }
    }
}
