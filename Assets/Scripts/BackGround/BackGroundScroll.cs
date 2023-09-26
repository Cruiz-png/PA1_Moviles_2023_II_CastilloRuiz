using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 1.0f; // Velocidad de desplazamiento del offset
    private Material material;
    private Vector2 initialOffset;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        initialOffset = material.mainTextureOffset;
    }

    private void Update()
    {
        float offset = Time.time * scrollSpeed;
        Vector2 newOffset = initialOffset + Vector2.right * offset;
        material.mainTextureOffset = newOffset; // Aplica el desplazamiento al offset de la textura
    }
}
