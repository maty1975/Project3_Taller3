using UnityEngine;

public class ScaleReducer : MonoBehaviour
{
    public float scaleSpeed = 1f; // Velocidad de reducci�n del tama�o

    void Update()
    {
        // Reducir el tama�o del objeto en los ejes X y Z de manera uniforme
        Vector3 newScale = transform.localScale;
        float reduction = scaleSpeed * Time.deltaTime;
        newScale.x = Mathf.Max(0, newScale.x - reduction);
        newScale.y = Mathf.Max(0, newScale.y - reduction);
        newScale.z = Mathf.Max(0, newScale.z - reduction);

        transform.localScale = newScale;

        // Destruir el objeto cuando su tama�o en X y Z sea cero
        if (newScale.x <= 0 && newScale.y <= 0 & newScale.z <= 0)
        {
            Destroy(gameObject);
        }
    }
}
