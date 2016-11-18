using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;




public class GameUI : MonoBehaviour
{
    const float COUNTDOWN_DEFAULT = 240f;

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
    public CanvasGroup DialogBox;


    private float timeRemaining;
    private bool isPaused = false;
    private bool isShowingDialog = false;

    private Vector2 middleScreen = new Vector2(0.0f, 0.0f);
    private Vector2 offScreen = new Vector2(-10000.0f, -10000.0f);



    // Use this for initialization
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        player = FindObjectOfType<AvatarController>();
        DialogBox = GameObject.Find("DialogBox").GetComponent<CanvasGroup>();


        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameUI();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isShowingDialog)
                HideDialog();
            else
            {
                TogglePause();
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && isShowingDialog)
        {
            HideDialog();
        }


        if (playerHealth.playerAlive)
        {

            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                //timeout will be end of game
                playerHealth.playerLives = 0;
                //remove the above line to just reset time and respawn
                timeRemaining = COUNTDOWN_DEFAULT;

                playerHealth.KillPlayer();
            }

        }



    }

    private void Show(CanvasGroup cg)
    {
        cg.alpha = 1.0f;
        RectTransform tempRect = cg.GetComponent<RectTransform>();
        tempRect.anchoredPosition = middleScreen;
        cg.gameObject.SetActive(true);
    }
    private void Hide(CanvasGroup cg)
    {
        cg.alpha = 0.0f;
        RectTransform tempRect = cg.GetComponent<RectTransform>();
        tempRect.anchoredPosition = offScreen;
        cg.gameObject.SetActive(false);
    }

    private void StartLevel()
    {
        timeRemaining = COUNTDOWN_DEFAULT;

    }



    public void UpdateGameUI()
    {
        LifeBar.localScale = new Vector3(1, playerHealth.currentHealth / 100, 0);
        ArmorBar.localScale = new Vector3(1, playerHealth.currentArmour / 100, 0);

        TimeSpan ts = TimeSpan.FromSeconds(timeRemaining);
        string formatTime = string.Format("{0:D2} : {1:D2}", ts.Minutes, ts.Seconds);
        TxtTimer.text = formatTime;
        TxtScore.text = String.Format("{0:n0}", player.score);
        TxtAmmo.text = "x " + player.ammo[0].ToString();


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

        //unselect the invetory button
        GameObject.Find("ScreenOverlay").SetActive(true);
        GameObject es = GameObject.Find("EventSystem");
        es.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

    }
    public void ShowDialog(string dialogue)
    {
        isShowingDialog = true;
        Time.timeScale = 0;
        player.disableInput = true;
        Text txt = DialogBox.gameObject.GetComponentInChildren<Text>();
        txt.text = dialogue;
        Show(DialogBox);

    }
    public void HideDialog()
    {
        isShowingDialog = false;
        Time.timeScale = 1;
        player.disableInput = false;
        Hide(DialogBox);
    }

}



