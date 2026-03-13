using UnityEngine;
using UnityEngine.UI;
using TMPro; // Necesario para TextMeshPro

public class MenuPlanetasDinamico : MonoBehaviour
{
    [SerializeField] private GameObject botonPrefab;
    [SerializeField] private Transform contenedor;
    [SerializeField] private CameraController camaraController;
    [SerializeField] private Transform[] planetas;

    void Start()
    {
        if (botonPrefab == null || contenedor == null || camaraController == null || planetas.Length == 0)
        {
            Debug.LogError("Faltan referencias en el Inspector");
            return;
        }

        foreach (Transform planeta in planetas)
        {
            GameObject nuevoBoton = Instantiate(botonPrefab, contenedor);

            // Usar TMP_Text en lugar de Text
            TMP_Text textoBoton = nuevoBoton.GetComponentInChildren<TMP_Text>();
            if (textoBoton != null)
                textoBoton.text = planeta.name;
            else
                Debug.LogError("El prefab del botón no tiene TMP_Text");

            nuevoBoton.GetComponent<Button>().onClick.AddListener(() =>
            {
                camaraController.EnfocarPlaneta(planeta);
            });
        }
    }
}
