using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {


    public static GameManager Instance { get; private set; }

    [SerializeField]
    private TextMeshPro _scoreText;

    [SerializeField]
    private int _score = 0;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void AddPoints(int amount)
    {
        _score += amount;
        _scoreText.text = _score.ToString();
    }

}
