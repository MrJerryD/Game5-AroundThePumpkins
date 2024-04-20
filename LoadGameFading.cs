using UnityEngine;

public class LoadGameFading : MonoBehaviour
{
    // затемняем экран при переходе на другую сцену
    public Texture2D fading;

    private float fadeSpeed = 0.4f; // скорость затемнения
    private int drawDepth = -1000; // рисует точку поверх всех элементов типо Order in Layer
    private float alpha = 1f; // прозрачность
    private float fadeDirection = -1f; // делаем экран светлым, если 1, то наоборот

    private void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fading); // зарисовуем весь экран
    }

    public float Fade(float dir)
    {
        fadeDirection = dir;
        return fadeSpeed;
    }
}
