using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bow : Weapon
{
    public float drawTime = 0.5f;
    public SpriteRenderer arrowSpriteRenderer;
    public Vector3 arrowDrawnOffset = new Vector3(0, -0.2f, 0);
    public GameObject arrowPrefab;

    private Animator _animator;
    private bool _drawn = false;
    private float _drawnAmount = 0;
    private Vector3 _arrowOffset;

    private Vector3 _baseOffset;
    public Vector3 recoil = Vector3.zero;

    private bool _bowReady = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _arrowOffset = arrowSpriteRenderer.transform.localPosition;
        _baseOffset = transform.localPosition;
    }

    private void Update()
    {
        if (_drawn)
        {
            _drawnAmount += Time.deltaTime / drawTime;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, _baseOffset, Time.deltaTime * 25f); // Return from recoil

        arrowSpriteRenderer.transform.localPosition = Vector3.Lerp(_arrowOffset, _arrowOffset + arrowDrawnOffset, _drawnAmount);
        
        _animator.SetFloat("drawnAmount", _drawnAmount);
    }

    public override void OnWeaponDown()
    {
        if (!_bowReady) return;
        
        StopCoroutine(ReloadArrow());
        _drawn = true;
        arrowSpriteRenderer.enabled = true;
        _animator.ResetTrigger("released");
    }
    public override void OnWeaponRelease()
    {
        if (!_bowReady) return;
        
        _drawn = false;
        _bowReady = false;
        _drawnAmount = 0;
        arrowSpriteRenderer.enabled = false;
        _animator.SetTrigger("released");
        Instantiate(arrowPrefab, transform.position, GameObject.FindObjectOfType<PlayerController>().transform.rotation);
        StartCoroutine(ReloadArrow());
        transform.localPosition = _baseOffset + recoil; // Recoil;
    }

    private IEnumerator ReloadArrow()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        arrowSpriteRenderer.enabled = true;
        _bowReady = true;
    }
}
