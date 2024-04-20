using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButton : MonoBehaviour
{
    //LoadGameFading loadGameFading;

    //void Start()
    //{
    //    loadGameFading = GetComponent<LoadGameFading>();
    //}

    public void PlayGame() // игра зпапускается когда экран станет прозрачным, для этого тут куратина
    {
        SceneManager.LoadScene("Game");
    }

    public void PlayExit()
    {
        Application.Quit();
    }

    public void PlayMenu()
    {
        //loadScene("Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        // Сбрасываем Time.timeScale обратно в 1, чтобы возобновить игру
        Time.timeScale = 1f;

        // Загружаем сцену заново
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //IEnumerator loadScene(string name)
    //{
    //    float fadeTime = loadGameFading.Fade(1f);
    //    yield return new WaitForSeconds(fadeTime);
    //    SceneManager.LoadScene(name);
    //}
}
