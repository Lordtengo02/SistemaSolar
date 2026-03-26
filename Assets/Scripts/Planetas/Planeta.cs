using UnityEngine;
using UnityEngine.EventSystems;

public class Planeta : MonoBehaviour, IPointerClickHandler
{
    public PlanetaData datos;
    [SerializeField] private GameObject interior; // Referencia al objeto Interior del planeta

    // Propiedad pública para acceder desde PlanetSelectionManager
    public GameObject Interior => interior;
    public void OnPointerClick(PointerEventData eventData)
    {
        // Solo se ejecuta si el clic no fue sobre un botón UI
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Object.FindFirstObjectByType<PlanetSelectionManager>().SeleccionarPlaneta(this);
        }
    }
}
