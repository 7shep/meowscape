using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public PlayerMovementAdvanced playerMovement; // Reference to the PlayerMovementAdvanced script

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor at the beginning
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("resumed");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false;
        playerMovement.enabled = true; // Enable the PlayerMovementAdvanced script
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerMovement.enabled = false; // Disable the PlayerMovementAdvanced script
    }
}
