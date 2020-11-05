using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "pluggableAI/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float moveSpeed = 1f;
    public float LookRange = 40f;
    public float lookSphereCastRadius = 1f;
  
    public float attackRange = 1f;
    public float attackRate = 1f;
    public float attackForce = 15f;
    public float attackDemage = 50f;

    public float searchDuration = 4f;
    public float searchingTurnSpeed = 120f;
}
