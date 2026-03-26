using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelInfoPlaneta : MonoBehaviour
{
    [SerializeField] private TMP_Text nombreTexto;
    [SerializeField] private TMP_Text datosTexto;
    [SerializeField] private TMP_Text curiosidadTexto;
    [SerializeField] private Image iconoImagen;
    [SerializeField] private Button botonCuriosidad;

    private PlanetaData planetaActual;
    void Start()
    {
        gameObject.SetActive(false);
        iconoImagen.gameObject.SetActive(false);
    }

    public void MostrarInfo(PlanetaData datos)
    {
        gameObject.SetActive(true);
        planetaActual = datos;

        nombreTexto.text = datos.nombre;
        datosTexto.text = $"Tamaño: {datos.tamaño}\nDistancia al Sol: {datos.distanciaAlSol}\nComposición: {datos.composicion}";
        iconoImagen.sprite = datos.icono;
        iconoImagen.gameObject.SetActive(true);

        curiosidadTexto.text = "";
        botonCuriosidad.onClick.RemoveAllListeners();
        botonCuriosidad.onClick.AddListener(() => MostrarCuriosidad());

        Debug.Log("Mostrando info de: " + datos.nombre);
    }

    private void MostrarCuriosidad()
    {
        curiosidadTexto.text = planetaActual.curiosidadExtra;
    }
}
