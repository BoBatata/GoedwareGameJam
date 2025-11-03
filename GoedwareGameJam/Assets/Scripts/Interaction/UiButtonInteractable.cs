using UnityEngine;
using UnityEngine.SceneManagement;

public class UiButtonInteractable : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
