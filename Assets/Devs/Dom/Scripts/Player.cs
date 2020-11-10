using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
public class Player : Entity
{
    public PlayerHealthDisplay healthDisplay;

    public bool invulnerable = false;

    public void SetInvulnerable(float duration)
    {
        StartCoroutine(DoInvulnerable(duration));
    }

    IEnumerator DoInvulnerable(float duration)
    {
        invulnerable = true;
        yield return new WaitForSeconds(duration);
        invulnerable = false;
    }
    
    public override int Health
    {
        get => _health;
        set
        {
            if (invulnerable && value < _health) return;
            
            _health = Mathf.Clamp(value, 0, MaxHealth); // Clamp value between zero and max health
            healthDisplay.SetDisplay(Health, MaxHealth);
            
            
            if (Health <= 0)
            {
                Game.GetGameManager().OnPlayerDie();
            }
            else if (Health <= 1)
            {
                Game.GetGameManager().hurtRedFader.DOFade(0f, 0.5f).SetLoops(-1, LoopType.Yoyo);
            }
            else
            {
                Game.GetGameManager().hurtRedFader.DOKill();
                Game.GetGameManager().hurtRedFader.DOFade(0f, 0.5f);
            }
        }
    }
    public void Start()
    {
        healthDisplay.SetDisplay(Health, MaxHealth);
    }

    public override void SetMaxHealth(int newMax)
    {
        base.SetMaxHealth(newMax);
        healthDisplay.SetDisplay(Health, MaxHealth);
    }

    public override void OnDamaged(int damage)
    {
        if (invulnerable) return;
        
        Debug.Log("player damaged");
        
        base.OnDamaged(damage);
        healthDisplay.SetDisplay(Health, MaxHealth);
        Game.GetGameManager().hurtRedFader.alpha = 1f;

        if (Health <= 0)
        {
            Game.GetGameManager().OnPlayerDie();
            Game.GetMainCamera()?.DOShakeRotation(1f, Vector3.one * 5f);
        }
        else if (Health <= 1)
        {
            Game.GetGameManager().hurtRedFader.DOFade(0f, 0.5f).SetLoops(-1, LoopType.Yoyo);
            Game.GetMainCamera()?.DOShakeRotation(0.5f, Vector3.one);
        }
        else
        {
            Game.GetGameManager().hurtRedFader.DOKill();
            Game.GetGameManager().hurtRedFader.DOFade(0f, 0.5f);
            Game.GetMainCamera()?.DOShakeRotation(0.5f, Vector3.one);
        }
    }
}
