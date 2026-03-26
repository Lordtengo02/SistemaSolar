using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuPlanetasDinamico : MonoBehaviour
{
    [SerializeField] private GameObject botonPrefab;
    [SerializeField] private Transform contenedor;
    [SerializeField] private CameraController camaraController;
    [SerializeField] private Transform[] planetas;
    [SerializeField] private PlanetaData[] datosPlanetas;
    [SerializeField] private PanelInfoPlaneta panelInfo;
    [SerializeField] private PlanetSelectionManager planetSelectionManager;


    void Start()
    {
        if (botonPrefab == null || contenedor == null || camaraController == null || planetas.Length == 0)
        {
            Debug.LogError("Faltan referencias en el Inspector");
            return;
        }

        for (int i = 0; i < planetas.Length; i++)
        {
            Transform planetaTransform = planetas[i];
            Planeta planetaScript = planetaTransform.GetComponent<Planeta>();
            PlanetaData datos = planetaScript.datos;

            GameObject nuevoBoton = Instantiate(botonPrefab, contenedor);

            TMP_Text textoBoton = nuevoBoton.GetComponentInChildren<TMP_Text>();
            if (textoBoton != null)
                textoBoton.text = datos.nombre;

            nuevoBoton.GetComponent<Button>().onClick.AddListener(() =>
            {
                camaraController.EnfocarPlaneta(planetaScript.transform);
                panelInfo.MostrarInfo(planetaScript.datos);
            });




        }

    }
}
