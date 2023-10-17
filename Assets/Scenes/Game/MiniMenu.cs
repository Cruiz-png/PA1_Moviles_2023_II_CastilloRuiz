using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniMenu : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a la que deseas ir

    private void Start()
    {
        // Agrega un listener al botón para que ejecute la función LoadSceneOnClick cuando se presiona
        GetComponent<Button>().onClick.AddListener(ReturnToMainMenu);
    }
    // Llama a esta función para volver al menú principal
    public void ReturnToMainMenu()
    {
        SceneManager.UnloadSceneAsync("Game");
        //SceneManager.UnloadSceneAsync("Resultados");
        SceneManager.LoadScene(sceneName);
    }
}
