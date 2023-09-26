using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform firePoint; // El punto de origen de las balas
    public float velocidadMovimiento = 5f; // Ajusta la velocidad de movimiento según tus necesidades.
    public float tiempoEntreDisparos = 0.5f; // Tiempo entre cada disparo
    private Vector3 objetivo; // La posición objetivo hacia la que se moverá la nave
    private bool movimientoActivo = false;
    private float tiempoUltimoDisparo;

    private void Update()
    {
        // Verificar si se ha tocado la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Obtener el primer toque (puedes ajustar esto según tus necesidades)

            if (touch.phase == TouchPhase.Began)
            {
                // Obtener la posición del toque
                Vector3 posicionTocada = Camera.main.ScreenToWorldPoint(touch.position);
                objetivo = new Vector3(transform.position.x, posicionTocada.y, transform.position.z);

                // Activar el movimiento
                movimientoActivo = true;
            }

            // Disparar mientras se mantiene presionada la pantalla (Hold)
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // Verificar si ha pasado suficiente tiempo desde el último disparo
                if (Time.time - tiempoUltimoDisparo >= tiempoEntreDisparos)
                {
                    //Disparar();
                    tiempoUltimoDisparo = Time.time;
                }
            }
        }

        // Si el movimiento está activo, mover la nave hacia la posición objetivo en el eje Y
        if (movimientoActivo)
        {
            float paso = velocidadMovimiento * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, objetivo, paso);

            // Verificar si la nave ha llegado a la posición objetivo en el eje Y
            if (Mathf.Approximately(transform.position.y, objetivo.y))
            {
                // Desactivar el movimiento
                movimientoActivo = false;
            }
        }
    }

    // Método para disparar
    //public void Disparar()
    //{
    //    // Encuentra el objeto BulletPool en la escena
    //    BulletPool bulletPool = FindObjectOfType<BulletPool>();

    //    if (bulletPool != null)
    //    {
    //        GameObject newBullet = bulletPool.GetBullet();
    //        if (newBullet != null)
    //        {
    //            newBullet.transform.position = firePoint.position;
    //            newBullet.transform.rotation = firePoint.rotation;
    //            newBullet.transform.Rotate(Vector3.forward, -90.0f);
    //            newBullet.SetActive(true);
    //        }
    //        else
    //        {
    //            Debug.LogError("No se pudo obtener una bala del pool.");
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("No se encontró un objeto BulletPool en la escena.");
    //    }
    //}


}
