using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class SceneSwitcher : MonoBehaviour
{
    public void SwitchToMainMenu()
    {
        // Load the "MainMenu" scene by its name
        SceneManager.LoadScene("MainMenu");
    }
}
