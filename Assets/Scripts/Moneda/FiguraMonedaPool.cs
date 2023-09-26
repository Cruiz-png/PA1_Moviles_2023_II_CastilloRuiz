using System.Collections.Generic;
using UnityEngine;

public class FiguraMonedaPool : MonoBehaviour
{
    public GameObject[] monedaPrefab; // Prefab del enemigo que deseas instanciar
    public int poolSize = 5; // Tamaño del pool inicial

    private static GameObject[] monedaPool; // Lista que almacena la basura en el pool

    private void Awake()
    {
       monedaPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            GameObject moneda = Instantiate(monedaPrefab[Random.Range(0, monedaPrefab.Length)]);
            moneda.SetActive(false);

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
