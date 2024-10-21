using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Controller_camera : MonoBehaviour
{
    public GameObject camara;

    private CinemachineVirtualCamera vcam;

    void Start()
    {
        // Obtener el componente CinemachineVirtualCamera de la c�mara
        vcam = camara.GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Activar la c�mara y establecer su prioridad
           // camara.SetActive(true);
            vcam.Priority = 10; // Prioridad alta (cualquier n�mero mayor que otras c�maras activas)
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Desactivar la c�mara
            //camara.SetActive(false);
            vcam.Priority = 0; // Restablecer la prioridad a su valor predeterminado
        }
    }
}
