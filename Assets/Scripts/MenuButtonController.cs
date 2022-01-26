using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public static bool gamePaused = true;
    public GameObject pauseMenu;
    public Camera mainCamera;

    /// 
    /// Called When Play Button Is Pressed
    /// 
    public void PlayGame()
    {
        // Lead next scene in build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// 
    ///  Called When Quit Button Is Pressed
    /// 
    public void QuitGame()
    {
        // Close the application
        Application.Quit();
    }

    /// 
    ///  Called When Quit Button Is Pressed
    /// 
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        gamePaused = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePlay();
        }
    }

    /// 
    ///  Called When Quit Button Is Pressed
    /// 
    public void PausePlay()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        gamePaused = !gamePaused;
        Cursor.visible = !Cursor.visible;
        if (gamePaused == true)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

