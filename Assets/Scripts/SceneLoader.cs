using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene(Collision collision)
    {
        var currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Scenes/Start Menu" )
        {
            SceneManager.LoadScene("Scenes/Level 1");
        }

        else if (currentScene == "Scenes/Level 1" && collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Scenes/Level 2");
            
        }

        else if (currentScene == "Scenes/Level 2" && collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Scenes/Sandbox");
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
