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

    private bool gameIsPaused = false;

    private void Start()
    {
        playerObject = player.GetComponent<PlayerObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (!gameIsPaused)
            {
                Time.timeScale = 0;
                gameIsPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                gameIsPaused = false;
            }
        }
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

    public void BossWasKilled()
    {
        Invoke("ChangeToWinScene", 2f);
    }

    private void ChangeToWinScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
