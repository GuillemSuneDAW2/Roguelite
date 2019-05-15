using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameState { Idle, Playing};
    public GameState gameState = GameState.Idle;

    public GameObject player;
    private PlayerObject playerObject;
    public LilRagnarosController ragnaros;
    
    public GameObject bridge;
    public GameObject brokenBridge;

    private void Start()
    {
        playerObject = player.GetComponent<PlayerObject>();
        TriggerBossFight();
    }

    public void TriggerBossFight()
    {
        ragnaros.StartShooting();
    }

    public void DestroyBridge()
    {
        bridge.SetActive(false);
        brokenBridge.SetActive(true);
    }

    public void ShareExperience(int experience)
    {
        playerObject.GainExperience(experience);
        Debug.Log(experience + " experience sent to the player");
    }
}
