using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementAround : MonoBehaviour
{
    public Transform center;  // Ссылка на центр (круг)
    public float rotationSpeed = 45.0f;
    private bool clockwiseRotation = true;

    private AudioSource clickAudio;
    private AudioSource findCandy;
    private AudioSource endGame;

    private Animation myAnim;
    public Canvas canvas;
    public Canvas canvasSecond;

    public Text textScore;
    private int candy = 0;

    public int currentScore = 0;
    public int recordScore = 0;
    public Text recordText;
    public Text currentScoreText;

    private void Start()
    {
        clickAudio = transform.Find("Click").GetComponent<AudioSource>();
        findCandy = transform.Find("FindCandy").GetComponent<AudioSource>();
        endGame = transform.Find("EndGame").GetComponent<AudioSource>();
        canvas.enabled = false;
        canvasSecond.enabled = true;
        recordScore = PlayerPrefs.GetInt("RecordScore", 0);
    }

    private void Update()
    {
        float step = rotationSpeed * Time.deltaTime;

        if (!clockwiseRotation)
        {
            step = -step;
        }

        transform.RotateAround(center.position, Vector3.forward, step);

        if (Input.GetMouseButtonDown(0))
        {
            clockwiseRotation = !clockwiseRotation;
            clickAudio.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("PumpkinsEnemy");
            canvas.enabled = true;
            canvasSecond.enabled = false;
            endGame.Play();

            Time.timeScale = 0f;

            if (candy > recordScore)
            {
                recordScore = candy;
                PlayerPrefs.SetInt("RecordScore", recordScore);
                PlayerPrefs.Save();
            }

            recordText = canvas.GetComponentInChildren<Text>();
            recordText.text = "Record: " + recordScore;

            currentScore = candy;
            currentScoreText.text = "You score: " + currentScore;

        }

        if (collision.CompareTag("candy"))
        {
            Debug.Log("candy");
            candy++;
            UpdateCountText();
            findCandy.Play();
            Destroy(collision.gameObject);
        }
    }

    void UpdateCountText()
    {
        textScore.text = "" + candy;
    }
}
