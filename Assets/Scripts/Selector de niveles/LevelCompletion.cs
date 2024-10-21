using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    private LevelManager levelManager;
    public int currentLevelIndex;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void OnLevelCompleted()
    {
        // Desbloquear el siguiente nivel
        levelManager.UnlockLevel(currentLevelIndex + 1);

        // Aqu� puedes a�adir l�gica adicional como cargar una pantalla de victoria
    }
}
