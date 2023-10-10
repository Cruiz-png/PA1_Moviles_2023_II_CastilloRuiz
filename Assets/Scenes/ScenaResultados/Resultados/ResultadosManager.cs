using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultadosManager : MonoBehaviour
{
    public Puntuacion puntuacion;
    public Text highScoresText;

    // Start is called before the first frame update
    void Start()
    {
        puntuacion.UpdateHighScore();

        // Construir una cadena para mostrar los 10 mejores puntajes
        string highScoresString = "TOP 10 PUNTAJES:\n";

        for (int i = 0; i < 10; i++)
        {
            if (i < puntuacion.highScoresList.Count)
            {
                highScoresString += "Puntaje " + (i + 1) + ": " + Mathf.RoundToInt(puntuacion.highScoresList[i].score);
            }
            else
            {
                highScoresString += "Puntaje " + (i + 1) + ": " + "0" +"\n"; // Si no hay un puntaje en este lugar, muestra 0 y "Vacío"
            }
        }

        highScoresText.text = highScoresString;
    }
}
