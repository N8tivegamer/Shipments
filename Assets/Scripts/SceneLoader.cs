using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public static void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("shipments"); // Make sure this matches your scene name
    }

    public static void ToSettings()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Settings");
    }
  

}
