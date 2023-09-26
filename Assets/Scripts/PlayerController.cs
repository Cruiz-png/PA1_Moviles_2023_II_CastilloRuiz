using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform firePoint; // El punto de origen de las balas
    public float saltoForce = 5f;
    private Rigidbody2D rb;


    private float limiteYMax = 4f;
    private float limiteYMin = -4f;

    private void Start()
    {
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
    }

    private void Saltar()
    {
        // Aplicar una fuerza hacia arriba para realizar un salto
        rb.velocity = new Vector2(rb.velocity.x, saltoForce);
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
