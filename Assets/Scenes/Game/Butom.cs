using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Butom : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a la que deseas ir

    private void Start()
    {
        // Agrega un listener al bot�n para que ejecute la funci�n LoadSceneOnClick cuando se presiona
        GetComponent<Button>().onClick.AddListener(LoadSceneOnClick);
    }

    private void LoadSceneOnClick()
    {
        // Carga la escena especificada por nombre
        SceneManager.LoadScene(sceneName);
    }
}
