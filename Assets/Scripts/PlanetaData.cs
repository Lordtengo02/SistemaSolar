using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPlaneta", menuName = "SistemaSolar/Planeta")]
public class PlanetaData : ScriptableObject
{
    public string nombre;
    public string tamaño;
    public string distanciaAlSol;
    public string composicion;
    public Sprite icono;


    [TextArea(3, 5)]
    public string descripcionAmigable;
    [TextArea(3, 5)]
    public string curiosidadExtra;

    public float gravedad;
}
