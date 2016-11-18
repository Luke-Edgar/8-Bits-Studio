using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class Gameover : MonoBehaviour
{

    public Text TxtScore;
    public InputField nameEntry;

    // Use this for initialization
    void Start()
    {
        TxtScore.text = String.Format("{0:n0}", ScoreSystem.LastScore);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MainMenu()
    {
        GameObject ss = GameObject.Find("ScoreSystem");
        if (ss != null)
        {
            ScoreSystem scoreSys = (ScoreSystem)ss.GetComponent(typeof(ScoreSystem));
            scoreSys.AddScore(nameEntry.text, ScoreSystem.LastScore);
        }

        SceneManager.LoadScene("Menu");

    }
}
