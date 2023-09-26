using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultadosManager : MonoBehaviour
{
    public Puntuacion puntuacion;
    public Text finalScore;
    // Start is called before the first frame update
    void Start()
    {
        puntuacion.UpdateHighScore();
        finalScore.text = "PUNTAJE: " + Mathf.RoundToInt(puntuacion.highScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
