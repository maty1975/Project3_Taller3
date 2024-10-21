using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproductorSFX : MonoBehaviour
{
    public Libreria_audio libreriaAudio;
    private AudioSource audioSource;

    void Start()
    {
        // Obt�n el componente AudioSource adjunto a este GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirAudioAleatorio()
    {
        if (libreriaAudio != null && libreriaAudio.audioclips.Length > 0)
        {
            // Selecciona un �ndice aleatorio
            int indiceAleatorio = Random.Range(0, libreriaAudio.audioclips.Length);
            // Asigna el AudioClip al AudioSource y lo reproduce
            audioSource.clip = libreriaAudio.audioclips[indiceAleatorio];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("La librer�a de audio est� vac�a o no ha sido asignada.");
        }
    }
}
