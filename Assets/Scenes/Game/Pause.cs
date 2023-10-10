using UnityEngine;
using UnityEngine.UI;

public class Pause:MonoBehaviour
{
    public GameObject objectToActivate; // El GameObject que deseas activar al presionar el bot�n
    private bool isPaused = false; // Variable para rastrear si el juego est� en pausa

    private void Start()
    {
        // Asocia la funci�n TogglePause al evento de clic del bot�n
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
