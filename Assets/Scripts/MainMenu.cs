using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
}
