using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Public interface
    public static GameManager Instance { get; private set; }

    // Current instance management

    [SerializeField] private PlayerController _player;
    public PlayerController Player
    {
        get
        {
            if (_player == null)
            {
                _player = FindObjectOfType<PlayerController>();
            }
            return _player;
        }
    }

    [SerializeField] private GameCamera _gameCamera;
    public GameCamera GameCamera
    {
        get
        {
            if (_gameCamera == null)
            {
                _gameCamera = FindObjectOfType<GameCamera>();
            }
            return _gameCamera;
        }
    }
    
    [SerializeField] private int _keyCount = 0;
    public int KeyCount
    {
        get => _keyCount;
        set => _keyCount = Mathf.Clamp(value, 0, int.MaxValue);
    }
    
    [SerializeField] private int _coinCount = 0;
    public int CoinCount
    {
        get => _coinCount;
        set => _coinCount = Mathf.Clamp(value, 0, int.MaxValue);
    }

    private void Awake ()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one instance of GameManager exists. Removing...");
            Destroy(this);
            return;
        }

        Instance = this;
    }
}
