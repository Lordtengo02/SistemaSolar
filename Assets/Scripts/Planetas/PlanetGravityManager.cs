using UnityEngine;

public class PlanetGravityManager : MonoBehaviour
{
    [SerializeField] private float gravedad = -3.7f; // Gravedad de Marte (negativa para dirección hacia abajo)
    private PlayerController playerController;       // Player local dentro del planeta

    private void Start()
    {
        // Busca automáticamente el Player hijo del planeta
        playerController = GetComponentInChildren<PlayerController>();

        if (playerController == null)
        {
            Debug.LogWarning($"No se encontró Player dentro de {gameObject.name}");
        }
        else
        {
            // Ajusta la gravedad del Player al valor del planeta
            playerController.SetGravedad(gravedad);
            Debug.Log($"Gravedad de {gameObject.name} configurada en {gravedad} m/s²");
        }
    }
}
