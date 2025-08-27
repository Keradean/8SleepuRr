using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Lets do it!");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Thank you for Playing my Game");
    }

}
