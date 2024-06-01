using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; // For restarting the game

public class ResumeButton : MonoBehaviour
{
    public void ResumeGame()
    {
        // on click goes to the "SampleScene" 
        SceneManager.LoadScene("SampleScene");
        

    }
}
