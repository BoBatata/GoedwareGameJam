using UnityEngine;
using UnityEngine.SceneManagement;

public class UiButtonInteractable : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("Gameplay");
        Cursor.visible = false;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        Cursor.visible = true;
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
