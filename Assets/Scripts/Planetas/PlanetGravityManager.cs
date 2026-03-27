using UnityEngine;
using System.Collections.Generic;

public class PlanetGravityManager : MonoBehaviour
{
    [Header("Nombre del planeta/luna (ej. Tierra, Marte, Luna)")]
    [SerializeField] private string planeta;

    [Header("Fuerza base de salto en Tierra")]
    [SerializeField] private float fuerzaBaseSalto = 6f;

    private PlayerControllerRB playerController;

    // Tabla de gravedades en m/s²
    private Dictionary<string, float> gravedades = new Dictionary<string, float>()
    {
        {"Tierra", -9.8f},
        {"Mercurio", -3.7f},
        {"Venus", -8.87f},
        {"Marte", -3.71f},
        {"Luna", -1.62f},
        {"Júpiter", -23.12f},
        {"Saturno", -8.96f},
        {"Urano", -8.69f},
        {"Neptuno", -11.0f},
        {"Plutón", -0.81f}
    };

    private void OnEnable()
    {
        if (gravedades.ContainsKey(planeta))
        {
            float gravedad = gravedades[planeta];

            // Ajusta la gravedad global
            Physics.gravity = new Vector3(0, gravedad, 0);

            // Ajusta el salto del Player
            playerController = FindObjectOfType<PlayerControllerRB>();
            if (playerController != null)
            {
                float gravedadTierra = 9.8f;
                float jumpForceEscalado = fuerzaBaseSalto * (gravedadTierra / Mathf.Abs(gravedad));

                // Limitar el salto para que no sea exagerado
                jumpForceEscalado = Mathf.Min(jumpForceEscalado, 12f);

                playerController.SetJumpForce(jumpForceEscalado);

            }

            Debug.Log($"Gravedad de {planeta}: {gravedad} m/s²");
        }
        else
        {
            Debug.LogWarning($"No se encontró gravedad para {planeta}. Usa valores manuales.");
        }
    }
}
