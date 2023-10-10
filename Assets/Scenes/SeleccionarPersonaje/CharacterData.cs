using UnityEngine;
[CreateAssetMenu(fileName = "New Character Data", menuName = "Custom/Character Data")]
public class CharacterData : ScriptableObject
{
    public int selectedCharacterIndex = -1; // Valor inicial, -1 significa que no se ha seleccionado ningún personaje aún
    public Sprite[] characterSprites = new Sprite[3];

    public Sprite getSprite()
    {
        return characterSprites[selectedCharacterIndex];
    }
}

