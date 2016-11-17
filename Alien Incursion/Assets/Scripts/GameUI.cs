using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;




public class GameUI : MonoBehaviour
{
    const float COUNTDOWN_DEFAULT = 600f;

    public PlayerHealth playerHealth;
    public AvatarController player;

    public Text TxtTimer;
    public Text TxtAmmo;
    public Text TxtScore;
    public RectTransform LifeBar;
    public RectTransform ArmorBar;

    public Image LivesCounter;
    public Sprite Lives_0;
    public Sprite Lives_1;
    public Sprite Lives_2;
    public Sprite Lives_3;
    public Sprite Lives_4;
    public Sprite Lives_5;
    public CanvasGroup PauseScreen;
    public CanvasGroup InventoryBar;

    private float timeRemaining;
    private bool isPaused = false;

    private Vector2 middleScreen = new Vector2(0.0f, 0.0f);
    private Vector2 offScreen = new Vector2(-10000.0f, -10000.0f);



    // Use this for initialization
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        player = FindObjectOfType<AvatarController>();

        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            TogglePause();
            return;
        }

        if (playerHealth.playerAlive)
        {
            TimeSpan ts = TimeSpan.FromSeconds(timeRemaining);
            string formatTime = string.Format("{0:D2} : {1:D2}", ts.Minutes, ts.Seconds);
            TxtTimer.text = formatTime;
            TxtScore.text = String.Format("{0:n0}", player.score);
            TxtAmmo.text = "x " + player.ammo[0].ToString();

            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                playerHealth.KillPlayer();
            }



        }



    }

    private void Show(CanvasGroup cg)
    {
        cg.alpha = 1.0f;
        RectTransform tempRect = cg.GetComponent<RectTransform>();
        tempRect.anchoredPosition = middleScreen;
    }
    private void Hide(CanvasGroup cg)
    {
        cg.alpha = 0.0f;
        RectTransform tempRect = cg.GetComponent<RectTransform>();
        tempRect.anchoredPosition = offScreen;
    }

    private void StartLevel()
    {
        timeRemaining = 600f;

    }



    public void UpdateGameUI()
    {
        LifeBar.localScale = new Vector3(1, playerHealth.currentHealth / 100, 0);
        ArmorBar.localScale = new Vector3(1, playerHealth.currentArmour / 100, 0);

        switch (playerHealth.playerLives)
        {
            case 5:
                LivesCounter.sprite = Lives_5;
                break;
            case 4:
                LivesCounter.sprite = Lives_4;
                break;
            case 3:
                LivesCounter.sprite = Lives_3;
                break;
            case 2:
                LivesCounter.sprite = Lives_2;
                break;
            case 1:
                LivesCounter.sprite = Lives_1;
                break;
            case 0:
                LivesCounter.sprite = Lives_0;
                break;
        }

    }

    public void EndGame()
    {
        if (isPaused) TogglePause();
        ScoreSystem.LastScore = player.score;
        SceneManager.LoadScene("Gameover");

    }
    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            Hide(PauseScreen);
            isPaused = false;

        }
        else {
            Time.timeScale = 0;
            Show(PauseScreen);
            isPaused = true;
        }

    }

    public void ShowInventory()
    {

        InventoryBar.alpha = 1.0f;
        InventoryBar.interactable = true;
        InventoryBar.blocksRaycasts = true;
    }

    public void HideInventory()
    {
        InventoryBar.alpha = 0.0f;
        InventoryBar.interactable = false;
        InventoryBar.blocksRaycasts = false;
    }

}

