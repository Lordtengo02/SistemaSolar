using UnityEngine;

public class RotacionPlaneta : MonoBehaviour
{
    public float velocidadRotacion = 30f;

    void Update()
    {
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}
