using UnityEngine;

public class SelectSprite : MonoBehaviour
{
    public CharacterData characterData; // Asigna el ScriptableObject en el Inspector
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No se encontró un componente SpriteRenderer en este GameObject.");
        }
    }

    private void Update()
    {
        if (characterData != null)
        {
            // Obtén el sprite del ScriptableObject usando la función GetSprite()
            Sprite newSprite = characterData.getSprite();

            // Asigna el nuevo sprite al SpriteRenderer
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
            }
        }
    }
}
