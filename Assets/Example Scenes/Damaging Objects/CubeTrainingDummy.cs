using UnityEngine;
using DG.Tweening;

/*
 * Script that allows a cube to shrink as its damaged, and then gets destroyed
 */

// Class must implement the interface 'Damageable' if it can be damaged.
// Will then require the void function OnDamaged(int damage)

public class CubeTrainingDummy : MonoBehaviour, Damageable
{
    
    public int health = 10;
    public GameObject[] deathEffects;
    
    private Color _origColor; // variable to store / restore the object's original color
    private Transform _playerTransform;
    private Renderer _renderer;
    
    // Called when game starts
    private void Start()
    {
        _playerTransform = Game.GetPlayerTransform();
        _renderer = GetComponent<Renderer>();
        _origColor = _renderer.material.color;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(_playerTransform);
    }
    
    public void OnDamaged(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
        else
        {
            transform.DOShakePosition(0.5f, Vector3.one * 0.1f, 20);
            _renderer.material.DOColor(_origColor, 0.25f).From(Color.red); 
        }
    }

    private void Die()
    {
        foreach (var obj in deathEffects)
        {
            Instantiate(obj, transform.position, Quaternion.LookRotation(Vector3.up), null);
        }
        gameObject.SetActive(false);
    }
}
