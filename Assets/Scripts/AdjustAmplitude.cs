using Cinemachine;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CameraShaker : MonoBehaviour
{
    public List<CinemachineVirtualCamera> virtualCameras;
    public float shakeDuration = 0.3f; // Duraci�n de la vibraci�n en segundos
    public float defaultShakeAmplitude = 1.2f; // Amplitud de la vibraci�n predeterminada
    public float defaultShakeFrequency = 2.0f; // Frecuencia de la vibraci�n predeterminada
    public float strongerShakeAmplitude = 2.0f; // Amplitud de la vibraci�n m�s intensa
    public float strongerShakeFrequency = 3.0f; // Frecuencia de la vibraci�n m�s intensa

    private List<CinemachineBasicMultiChannelPerlin> noises = new List<CinemachineBasicMultiChannelPerlin>();

    void Start()
    {
        // Aseg�rate de tener al menos una virtual camera asignada
        if (virtualCameras == null || virtualCameras.Count == 0)
        {
            Debug.LogError("No Virtual Cameras assigned in CameraShaker.");
            return;
        }

        // Obtener los componentes de ruido de todas las c�maras
        foreach (var camera in virtualCameras)
        {
            var noise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            if (noise != null)
            {
                noises.Add(noise);
            }
        }
    }

    // Funci�n para iniciar la vibraci�n de las c�maras
    public void ShakeCameras()
    {
        Shake(defaultShakeAmplitude, defaultShakeFrequency);
    }

    // Funci�n para iniciar una vibraci�n m�s intensa de las c�maras
    public void ShakeCamerasStronger()
    {
        Shake(strongerShakeAmplitude, strongerShakeFrequency);
    }

    // Funci�n para iniciar la vibraci�n de las c�maras con una amplitud y frecuencia espec�ficas
    private void Shake(float amplitude, float frequency)
    {
        foreach (var noise in noises)
        {
            if (noise != null)
            {
                // Configurar el ruido para que dure la duraci�n especificada y tenga la amplitud y frecuencia dadas
                noise.m_AmplitudeGain = amplitude;
                noise.m_FrequencyGain = frequency;
            }
        }

        // Iniciar una corutina para detener la vibraci�n despu�s de la duraci�n especificada
        StartCoroutine(StopShaking());
    }

    // Corutina para detener la vibraci�n despu�s de la duraci�n especificada
    private IEnumerator StopShaking()
    {
        yield return new WaitForSeconds(shakeDuration);

        // Detener la vibraci�n
        foreach (var noise in noises)
        {
            if (noise != null)
            {
                noise.m_AmplitudeGain = 0f;
                noise.m_FrequencyGain = 0f;
            }
        }
    }
}
