using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour
{
    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);        
    }
}