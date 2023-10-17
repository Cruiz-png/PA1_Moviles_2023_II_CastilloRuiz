using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void GoToScene()
    {
        SceneManager.LoadScene("Seleccionar");
    }
}
