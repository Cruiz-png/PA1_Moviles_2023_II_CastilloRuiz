using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform firePoint; // El punto de origen de las balas
    public float saltoForce = 5f;
    private Rigidbody2D rb;

    public Puntuacion puntuacion;
    public float incremented = 1.0f;
    public Text scoreText;
    private float limiteYMax = 4f;
    private float limiteYMin = -4f;

    private void Start()
    {
        puntuacion.Awake();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Saltar();
            }
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {

            }
        }
        // Limitar la posición vertical del jugador
        Vector3 posicion = transform.position;
        posicion.y = Mathf.Clamp(posicion.y, limiteYMin, limiteYMax);
        transform.position = posicion;

        if(puntuacion != null )
        {
            puntuacion.score += incremented * Time.deltaTime;

            if(scoreText != null)
            {
                scoreText.text = "Puntaje " + Mathf.RoundToInt(puntuacion.score);
            }
        }
    }

    private void Saltar()
    {
        // Aplicar una fuerza hacia arriba para realizar un salto
        rb.velocity = new Vector2(rb.velocity.x, saltoForce);
    }


}
