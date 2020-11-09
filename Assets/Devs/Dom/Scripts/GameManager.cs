using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Public interface
    public static GameManager Instance { get; private set; }

    public CanvasGroup titleScreen;
    public CanvasGroup gameOverScreen;
    public CanvasGroup screenFader;
    public CanvasGroup hurtRedFader;
    private int _sceneToLoad = 0;

    public TextMeshProUGUI keyCount;
    public TextMeshProUGUI coinCount;

    public void StartNewGame()
    {
        // Reset player status
        _player.GetComponent<Player>().MaxHealth = 3;
        _player.GetComponent<Player>().Health = 3;
        
        // Finish any special effects
        hurtRedFader.DOComplete();
        hurtRedFader.alpha = 0;
        
        // Load first scene
        LoadScene(1);
    }

    public void LoadScene(int index)
    {
        _sceneToLoad = index;
        
        titleScreen.DOKill();
        titleScreen.DOFade(0, 0).SetDelay(0.25f);
        titleScreen.blocksRaycasts = false;
        
        gameOverScreen.DOKill();
        gameOverScreen.DOFade(0, 0).SetDelay(0.25f);
        gameOverScreen.blocksRaycasts = false;
        
        _player.canControl = false;
        screenFader.DOFade(1f, 0.25f).OnComplete(DoSceneLoad);
    }

    private void DoSceneLoad()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(_sceneToLoad);
        screenFader.DOFade(0f, 0.25f);
        StartCoroutine(SetPlayerPosition());
    }

    IEnumerator SetPlayerPosition()
    {
        // Repeat 4x to ensure physics calls don't override new player position
        
        yield return new WaitForFixedUpdate();
        _player.SetPosition(FindObjectOfType<PlayerSpawnPoint>().transform.position);
        yield return new WaitForFixedUpdate();
        _player.SetPosition(FindObjectOfType<PlayerSpawnPoint>().transform.position);
        yield return new WaitForFixedUpdate();
        _player.SetPosition(FindObjectOfType<PlayerSpawnPoint>().transform.position);
        yield return new WaitForFixedUpdate();
        _player.SetPosition(FindObjectOfType<PlayerSpawnPoint>().transform.position);
        
        // Give player control back
        _player.canControl = true;
        _player.GetComponent<Player>().invulnerable = false;

    }
    

    public void OnPlayerDie()
    {
        _player.GetComponent<Player>().invulnerable = true;
        _player.canControl = false;
        
        gameOverScreen.DOFade(1f, 2f);
        gameOverScreen.blocksRaycasts = true;
    }
    
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
        set
        {
            _keyCount = Mathf.Clamp(value, 0, int.MaxValue);
            keyCount.text = _keyCount.ToString();
        }
    }
    
    [SerializeField] private int _coinCount = 0;
    public int CoinCount
    {
        get => _coinCount;
        set
        {
            _coinCount = Mathf.Clamp(value, 0, int.MaxValue);
            coinCount.text = _coinCount.ToString();
        }
    }

    private void Awake ()
    {
        if (Instance != null)
        {
            //Debug.LogError("More than one instance of GameManager exists. Removing...");
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        Instance = this;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            titleScreen.alpha = 1f;
            titleScreen.blocksRaycasts = true;
        }
        else
        {
            _player.canControl = true;
        }
    }
}
