using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public CanvasGroup cgPressStartButton;
    public CanvasGroup cgMenu;
    public CanvasGroup cgOptions;
    public CanvasGroup cgHighscores;

    public Text TxtScoreList;


    private Vector2 middleScreen = new Vector2(0.0f, 0.0f);
    private Vector2 offScreen = new Vector2(-10000.0f, -10000.0f);


    void Start()
    {
        //Show(cgPressStartButton);
    }


    public void ShowMainMenu()
    {
        Hide(cgPressStartButton);
        Hide(cgOptions);
        Hide(cgHighscores);
        Show(cgMenu);

    }

    public void ShowOptionsMenu()
    {
        Hide(cgPressStartButton);
        Show(cgOptions);
        Hide(cgHighscores);
        Hide(cgMenu);
    }

    public void ShowHighscore()
    {

        GameObject ss = GameObject.Find("ScoreSystem");
        if (ss != null)
        {
            ScoreSystem scoreSys = (ScoreSystem)ss.GetComponent(typeof(ScoreSystem));
            TxtScoreList.text = scoreSys.ScoreList();
        }

        Hide(cgPressStartButton);
        Hide(cgOptions);
        Show(cgHighscores);
        Hide(cgMenu);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main Level");
    }

    public void QuitGame()
    {
        Application.Quit();
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

}

