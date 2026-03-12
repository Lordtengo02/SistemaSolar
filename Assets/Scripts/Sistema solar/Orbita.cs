using UnityEngine;

public class Orbita : MonoBehaviour
{
    public float velocidadOrbita = 10f;

    void Update()
    {
        transform.Rotate(Vector3.up, velocidadOrbita * Time.deltaTime);
    }
}
