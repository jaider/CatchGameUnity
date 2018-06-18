using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject ball;
    public GameObject badBall;
    public float timeLeft;
    public Text timerText;
    public GameObject gameOverText;
    public GameObject restartBtn;
    public GameObject spashScreenImage;
    public GameObject startBtn;
    public HatController hatController;

    private float maxWidth;
    private bool playing;

    // Use this for initialization
    void Start()
    {
        if (cam == null)
            cam = Camera.main;

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        UpdateText();
    }

    public void StartGame()
    {
        spashScreenImage.SetActive(false);
        startBtn.SetActive(false);
        StartCoroutine(Spawn());
        hatController.ToggleControl(true);
        playing = true;
    }

    private void FixedUpdate()
    {
        if (!playing)
            return;

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
            timeLeft = 0;
        UpdateText();
    }

    private IEnumerator Spawn()
    {
        //yield return new WaitForSeconds(2f);
        while (timeLeft > 0)
        {
            var width = Random.Range(-maxWidth, maxWidth);
            var spawnPosition = new Vector3(width, transform.position.y, 0f);
            var mod = Mathf.RoundToInt(width) % 2;
            Instantiate(mod == 0 ? ball : badBall, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
        yield return new WaitForSeconds(1f);
        gameOverText.SetActive(true);
        restartBtn.SetActive(true);
    }

    private void UpdateText()
    {
        timerText.text = "Time Left: " + System.Environment.NewLine + Mathf.RoundToInt(timeLeft);
    }
}
