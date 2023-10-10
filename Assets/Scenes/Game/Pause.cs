using UnityEngine;
using UnityEngine.UI;

public class Pause:MonoBehaviour
{
    public GameObject objectToActivate; // El GameObject que deseas activar al presionar el botón
    private bool isPaused = false; // Variable para rastrear si el juego está en pausa

    private void Start()
    {
        // Asocia la función TogglePause al evento de clic del botón
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(TogglePause);
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused; // Invierte el estado de pausa

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa el tiempo del juego
            objectToActivate.SetActive(true); // Activa el GameObject
        }
        else
        {
            Time.timeScale = 1f; // Reanuda el tiempo del juego
            objectToActivate.SetActive(false); // Desactiva el GameObject
        }
    }
}
