using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameState { Idle, Playing};
    public GameState gameState = GameState.Idle;

    public GameObject player;

    public GameObject bridge;
    public GameObject brokenBridge;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Idle)
        {

        }
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void DestroyBridge()
    {
        bridge.SetActive(false);
        brokenBridge.SetActive(true);
    }
}
