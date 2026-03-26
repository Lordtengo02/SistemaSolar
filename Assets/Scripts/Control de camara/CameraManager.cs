using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera solarSystemCamera;

    void Start()
    {
        ActivarSolarSystemView();
    }

    public void ActivarSolarSystemView()
    {
        solarSystemCamera.gameObject.SetActive(true);
        solarSystemCamera.GetComponent<AudioListener>().enabled = true;
    }
}
