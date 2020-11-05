
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject player;

    public int health = 100;
    public int Maxhealth = 100;
    public int coins = 0;
    public int keys;

    public float moveSpeed = 1f;
    public float LookRange = 40f;
    public float lookSphereCastRadius = 1f;

    public float attackRange = 1f;
    public float attackRate = 1f;
    public float attackForce = 15f;
    public float attackDemage = 50f;

}