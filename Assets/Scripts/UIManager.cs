using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text _startCounter;
    private GameManager _gameManager;
    void Start()
    {
        _startCounter = GameObject.Find("Canvas/StartCounter").GetComponent<Text>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        StartCoroutine(Wait3Sec());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Wait3Sec()
    {
        _startCounter.text = "3";
        yield return new WaitForSeconds(1);
        _startCounter.text = "2";
        yield return new WaitForSeconds(1);
        _startCounter.text = "1";
        yield return new WaitForSeconds(1);
        _startCounter.enabled = false;
        _gameManager.StartGame();
    }
}
