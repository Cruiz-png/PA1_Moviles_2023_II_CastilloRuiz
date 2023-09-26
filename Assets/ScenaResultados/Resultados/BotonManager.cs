using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonManager : MonoBehaviour
{
    public void CambiarScena(string text)
    {
        SceneManager.LoadScene(text);
    }
}
