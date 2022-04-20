using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMiniGame : MonoBehaviour
{
    /// <summary>
    /// Een scirpt die in elke minigame toegepast kan worden
    /// Met een mainmenu button en restart button
    /// </summary>
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
