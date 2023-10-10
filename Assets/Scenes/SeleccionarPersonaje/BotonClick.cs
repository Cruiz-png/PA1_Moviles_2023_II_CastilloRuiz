using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para trabajar con SceneManager

public class BotonClick : MonoBehaviour
{
    public CharacterData characterData; // Asigna el ScriptableObject en el Inspector

    public void OnButtonClick(int characterValue)
    {
        if (characterData != null)
        {
            characterData.selectedCharacterIndex = characterValue; // Asigna el valor seleccionado al ScriptableObject

            LoadGameScene();
        }
    }

    public void LoadGameScene()
    {
        // Carga la escena con nombre "Game"
        SceneManager.LoadScene("Game");
    }
}
