using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declaracion de variables
    public float mouseSensibility,//controlara la sensibilidad del mouse 
    speedMove,//controla la velocidad de movimiento
    jumpForce;//controla la fuerza del salto 

    public GameObject playerFP,//permite agregar el componente charater controller
    groundChecker;//verifica si el personaje toca el suelo 

    private float mouseX,// Toma valores del eje x el mouse 
    mouseY,// Toma valores del eje x el mouse 
    xRotation,//Toma valores de la rotacion del playerFP
    MoveX,// coonsidera el valro del x en movimiento
    MoveZ;// considera el valor de y en movimiento

    public bool isGrounded,//verifica si esta tocando el suelo 
    ModoVR;// cambiar el modo de ejecucion entre pc y vr

    new Transform camera;// extraer la camara 

    public LayerMask groundMask;// permite señalar que gameobjects son el suelo (grpund)

    private Vector3 gravityVelocity;// estable el control de la fuerza de gravedad 
    public float gravity;
    public void SetGravedad(float nuevaGravedad)
    {
        gravity = nuevaGravedad;
    }
    void Start()
    {
        playerFP = GameObject.Find("PlayerFP");
        groundChecker = this.transform.GetChild(1).gameObject;
        camera = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Update()
    {
        rotateView();
        movement();
        gravityManual();
    }


    void rotateView()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89, 89);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        this.transform.Rotate(Vector3.up * mouseX);


    }

    void movement()
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveZ = Input.GetAxis("Vertical");

        Vector3 move = this.transform.right * MoveX + this.transform.forward * MoveZ;
        this.GetComponent<CharacterController>().Move(move * speedMove * Time.deltaTime);

        // --- Lógica de salto ---
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            gravityVelocity.y = jumpForce; // aplica fuerza de salto
        }


        if (ModoVR == true)
        {
            if (MoveX != 0 || MoveZ != 0)
            {
                Vector3 forward = camera.forward;

                forward.y = 0;

                forward.Normalize();
                Vector3 right = camera.forward;
                right.y = 0;
                right.Normalize();

                Vector3 direction = forward * MoveZ + Vector3.right * MoveX;

                direction.Normalize();
                this.GetComponent<CharacterController>().Move(direction * speedMove * Time.deltaTime);


            }
        }
        else if (ModoVR == false)
        {
            Vector3 movimiento = this.transform.right * MoveX + this.transform.forward * MoveZ;
            this.GetComponent<CharacterController>().Move(movimiento * speedMove * Time.deltaTime);
        }

    }

    void gravityManual()
    {
        isGrounded = Physics.CheckSphere(groundChecker.transform.position, 1.1f, groundMask);

        if (isGrounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = -5f; // mantiene al jugador pegado al suelo
        }

        gravityVelocity.y += gravity * Time.deltaTime;
        this.GetComponent<CharacterController>().Move(gravityVelocity * Time.deltaTime);
    }

}