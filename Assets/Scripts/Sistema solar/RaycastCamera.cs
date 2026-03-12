using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SeleccionPlaneta : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) // Nuevo Input System
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Busca el componente VisitarPlaneta en el objeto clicado
                VisitarPlaneta visitar = hit.collider.GetComponent<VisitarPlaneta>();
                if (visitar != null && !string.IsNullOrEmpty(visitar.nombreEscena))
                {
                    Debug.Log("Planeta clicado: " + hit.collider.name);
                    SceneManager.LoadScene(visitar.nombreEscena);
                }
            }
        }
    }
}
