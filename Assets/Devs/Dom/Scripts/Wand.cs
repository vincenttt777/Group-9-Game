using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wand : Weapon
{
    public float swingSpeed = 25f;
    private bool swing = false;

    private Vector3 _startPos;

    void Start()
    {
        _startPos = transform.localPosition;
    }
    public float coolDownTime = 0.5f;
    public void Update()
    {
        if (swing)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _startPos + Vector3.back * 0.2f, Time.deltaTime * swingSpeed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _startPos, Time.deltaTime * swingSpeed);
        }
    }

    public override void OnWeaponDown()
    {
        swing = !swing;
        Attack();
    }
    
    
    public override void OnWeaponRelease()
    {
        swing = !swing;
        Attack();
    }

    public GameObject spellProjectilePrefab;
    public int attackPower = 3;

    private GameManager _gameManager;

    private bool _wandReady = true;

    void OnEnable()
    {
        _gameManager = Game.GetGameManager();
    }
    
    
    void Attack()
    {
        if (!_wandReady) return;
        
        _wandReady = false;
        Instantiate(spellProjectilePrefab, transform.position + Game.GetPlayerTransform().forward, FindObjectOfType<PlayerController>().transform.rotation);
        StartCoroutine(ReloadArrow());
    }

    private IEnumerator ReloadArrow()
    {
        yield return new WaitForSecondsRealtime(coolDownTime);
        _wandReady = true;
    }
}
