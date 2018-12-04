using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        var currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Start Menu")
        {
            SceneManager.LoadScene("Core Game");
        }

        else if (currentScene == "Core Game")
        {
            SceneManager.LoadScene("Win Screen");
        }

        else if (currentScene == "Win Screen")
        {
            SceneManager.LoadScene("Start Menu");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextSceneAlternative()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            SceneManager.LoadScene("Core Game");
        }
        else if (currentSceneIndex == 1)
        {
            SceneManager.LoadScene("Win Screen");
        }
        else if (currentSceneIndex == 2)
        {
            SceneManager.LoadScene("Start Menu");
        }
    }
}
