using System.Collections.Generic;
using UnityEngine;

public class MonedaPool : MonoBehaviour
{
    public GameObject[] monedaPrefab; // Prefab del enemigo que deseas instanciar
    public int poolSize = 5; // Tamaño del pool inicial

    private static GameObject[] monedaPool; // Lista que almacena la basura en el pool

    private void Awake()
    {
        // Inicializa la lista del pool
        monedaPool = new GameObject[poolSize];

        // Llena el pool con objetos basura inactivos
        for (int i = 0; i < poolSize; i++)
        {
            // Instancia un basura a partir del prefab
            GameObject moneda = Instantiate(monedaPrefab[Random.Range(0, monedaPrefab.Length)]);
            // Desactiva el basura para que no sea visible ni interactivo
            moneda.SetActive(false);

            // Agrega la moneda al arreglo del pool
            monedaPool[i] = moneda;
        }
    }

    public static GameObject GetMoneda()
    {
        foreach (GameObject moneda in monedaPool)
        {
            if (!moneda.activeInHierarchy)
            {
                moneda.SetActive(true);
                return moneda;
            }
        }
        return null;
    }

    public static void ReturnMonedaToPool(GameObject moneda)
    {
        moneda.SetActive(false);
    }
}
