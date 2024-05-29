using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; // For restarting the game

public class RestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        // Restarts the game
        SceneManager.LoadScene("SampleScene");

    }
}
