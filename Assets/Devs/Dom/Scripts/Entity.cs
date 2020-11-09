using System;
using UnityEngine;

/*
 * This base class can be placed on any GameObject that will have health and able be damaged.
 * It can be inherited from and overriden to perform more effects.
 */
public class Entity : MonoBehaviour, Damageable
{
    
    // The entity's current health
    [SerializeField] protected int _health = 6;
    public virtual int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, MaxHealth); // Clamp value between zero and max health
    }
    
    // The entity's current max health
    [SerializeField] private int _maxHealth = 6;
    public int MaxHealth
    {
        get => _maxHealth;
        set
        {
            _maxHealth = Mathf.Clamp(value, 1, int.MaxValue);
            Health = _health; // Re-clamp the current health to new max just in case.
        }
    }

    public virtual void SetMaxHealth(int newMax)
    {
        MaxHealth = newMax;
    }

    private void Awake()
    {
        MaxHealth = _maxHealth;
        Health = _health;
    }

    // Called whenever entity is damaged
    public virtual void OnDamaged(int damage)
    {
        Health -= damage;
    }
}
