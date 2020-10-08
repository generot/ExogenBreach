using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseEnemy", menuName = "New Enemy", order = 1)]
public class BaseEnemy : ScriptableObject
{
    public float speed, delay, shootingDistance;
    public int health, dmg;
}
