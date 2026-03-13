using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float suavizado = 0.5f;       // Tiempo de suavizado del movimiento
    [SerializeField] private float margenExtra = 10f;      // Margen adicional para no entrar al planeta
    [SerializeField] private float distanciaMinima = 5f;   // Distancia mínima de seguridad
    [SerializeField] private float zoomBase = 60f;         // Campo de visión base (FOV)
    [SerializeField] private float zoomFactor = 2f;        // Factor de ajuste del zoom según tamaño

    private Transform objetivo;
    private Vector3 offsetActual;
    private Vector3 velocidadSuavizada = Vector3.zero;
    private Camera camara;

    void Awake()
    {
        camara = GetComponent<Camera>();
    }

    void Update()
    {
        if (objetivo != null)
        {
            Vector3 posicionDeseada = objetivo.position + offsetActual;
            transform.position = Vector3.SmoothDamp(transform.position, posicionDeseada, ref velocidadSuavizada, suavizado);
            transform.LookAt(objetivo);
        }
    }

    public void EnfocarPlaneta(Transform planeta)
    {
        objetivo = planeta;

        // Radio del planeta (su escala en X / 2)
        float radio = planeta.localScale.x * 0.5f;

        // Distancia segura: radio + margen extra, nunca menor que la mínima
        float distancia = Mathf.Max(radio + margenExtra, distanciaMinima);

        // Offset dinámico: detrás y un poco arriba
        offsetActual = new Vector3(0, radio * 0.5f, -distancia);

        // Ajustar zoom dinámico según tamaño del planeta
        float nuevoFOV = Mathf.Clamp(zoomBase - (radio / zoomFactor), 20f, zoomBase);
        camara.fieldOfView = nuevoFOV;
    }
}
