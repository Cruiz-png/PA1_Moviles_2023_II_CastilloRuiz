using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniMenu : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a la que deseas ir

    private void Start()
    {
        // Agrega un listener al bot�n para que ejecute la funci�n LoadSceneOnClick cuando se presiona
        GetComponent<Button>().onClick.AddListener(ReturnToMainMenu);
    }
    // Llama a esta funci�n para volver al men� principal
    public void ReturnToMainMenu()
    {

        // Carga la escena del men� principal (ajusta el nombre de la escena seg�n corresponda)
        SceneManager.LoadScene(sceneName);
    }
}
