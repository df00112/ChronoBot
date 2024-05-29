using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; // For restarting the game

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        // stops the game
        Application.Quit();
    }
}
