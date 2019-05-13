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

    public void DestroyBridge()
    {
        bridge.SetActive(false);
        brokenBridge.SetActive(true);
    }
}
