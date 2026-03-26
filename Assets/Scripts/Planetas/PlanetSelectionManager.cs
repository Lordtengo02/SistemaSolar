using UnityEngine;

public class PlanetSelectionManager : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;       // Gestor de cámaras
    [SerializeField] private CameraController cameraController; // Controlador de cámara
    [SerializeField] private PanelInfoPlaneta panelInfo;        // Panel de información

    // Método llamado desde los botones dinámicos al seleccionar un planeta
    public void SeleccionarPlaneta(Planeta planeta)
    {
        // Enfoca la cámara en el planeta
        if (cameraController != null)
            cameraController.EnfocarPlaneta(planeta.transform);

        // Muestra la información del planeta
        if (panelInfo != null)
            panelInfo.MostrarInfo(planeta.datos);

        // Activa el interior del planeta (Player + GravityManager)
        if (planeta.Interior != null)
            planeta.Interior.SetActive(true);

        Debug.Log($"Entrando a {planeta.datos.nombre} con gravedad {planeta.datos.gravedad} m/s²");
    }

    // Método para salir del planeta y volver a la vista general
    public void SalirDelPlaneta(Planeta planeta)
    {
        if (cameraManager != null)
            cameraManager.ActivarSolarSystemView();

        // Desactiva el interior del planeta
        if (planeta.Interior != null)
            planeta.Interior.SetActive(false);

        Debug.Log($"Saliendo de {planeta.datos.nombre}");
    }
}
