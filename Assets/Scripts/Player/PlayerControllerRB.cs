using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerRB : MonoBehaviour
{
    [Header("Componentes")]
    private Rigidbody rb;
    [SerializeField] private Transform playerFP;       // Cámara en primera persona
    [SerializeField] private Transform groundChecker;  // Punto bajo los pies

    [Header("Parámetros de movimiento")]
    [SerializeField] private float speedMove = 6f;
    [SerializeField] private float mouseSensibility = 150f;

    [Header("Parámetros de salto y gravedad")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundMask;

    private bool isGrounded;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // evita que el cuerpo se vuelque
    }

    void Update()
    {
        Movimiento();
        Rotacion();
        GroundCheck();
    }

    void Movimiento()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        rb.MovePosition(rb.position + move * speedMove * Time.deltaTime);

        // Salto directo con Rigidbody
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    public void SetJumpForce(float newForce)
    {
        jumpForce = newForce;
    }


    void Rotacion()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerFP.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, 0.4f, groundMask);
    }
}
