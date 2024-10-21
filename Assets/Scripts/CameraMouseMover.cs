using UnityEngine;

public class CameraMouseMover : MonoBehaviour
{
    public float moveAmount = 0.1f; // Cantidad de movimiento de la c�mara en funci�n del movimiento del mouse
    private Vector3 initialPosition;

    void Start()
    {
        // Guardar la posici�n inicial de la c�mara
        initialPosition = transform.position;
    }

    void Update()
    {
        // Obtener la posici�n del mouse
        float mouseX = Input.mousePosition.x / Screen.width - 0.5f;
        float mouseY = Input.mousePosition.y / Screen.height - 0.5f;

        // Calcular la nueva posici�n de la c�mara en funci�n del movimiento del mouse
        Vector3 newPosition = initialPosition + new Vector3(mouseX * moveAmount, mouseY * moveAmount, 0);

        // Mover la c�mara a la nueva posici�n
        transform.position = newPosition;
    }
}
