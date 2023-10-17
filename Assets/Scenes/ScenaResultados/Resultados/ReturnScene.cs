using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScene : MonoBehaviour
{
    public void ReturnToScene()
    {
        SceneManager.UnloadSceneAsync("Game");
        SceneManager.UnloadSceneAsync("Resultados");
        SceneManager.LoadScene("menu");
    }
}
