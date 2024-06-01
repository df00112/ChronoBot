using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // write in console that the game is paused
            Debug.Log("Game is paused");
            SceneManager.LoadScene("Menu"); // Replace "MenuScene" with your actual scene name
        }
    }
}
