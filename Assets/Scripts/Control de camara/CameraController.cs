using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;   // Velocidad de movimiento de la cámara
    [SerializeField] private Vector3 offsetBase = new Vector3(0, 2, -5); // Offset base para planetas pequeños

    private Transform objetivo; // El planeta seleccionado
    private Vector3 offsetActual; // Offset calculado dinámicamente

    void Update()
    {
        if (objetivo != null)
        {
            // Movimiento suave hacia el planeta con offset dinámico
            Vector3 posicionDeseada = objetivo.position + offsetActual;
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * velocidad);

            // La cámara siempre mira al planeta
            transform.LookAt(objetivo);
        }
    }

    // Método público para que el menú llame
    public void EnfocarPlaneta(Transform planeta)
    {
        objetivo = planeta;

        // Ajustar offset dinámicamente según el tamaño del planeta
        float tamaño = planeta.localScale.x; // asumimos que el planeta es uniforme en X, Y, Z

        // Calculamos un offset proporcional al tamaño
        offsetActual = new Vector3(0, tamaño * 0.5f, -Mathf.Max(offsetBase.z * tamaño, -5f));
    }
}
