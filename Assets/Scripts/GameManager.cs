using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _player;

    void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        Debug.Log(_player.name);
    }

    public void StartGame()
    {
        _player.AddComponent<PlayerKontrol>();
    }
}