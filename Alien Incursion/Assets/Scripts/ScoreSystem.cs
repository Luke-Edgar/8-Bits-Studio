using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScoreSystem : MonoBehaviour
{

    const int MAX_SCORES = 5;


    public scoreentry[] scores = new scoreentry[5];
    public static int LastScore = 0;

    // Use this for initialization
    void Start()
    {
        //always keep this object loaded as it holds the high scores
        DontDestroyOnLoad(this);


        for (int i = 0; i < MAX_SCORES; ++i)
        {
            scores[i] = new scoreentry();
        }

        scores[0].AddScore("Fab", 4000);
        scores[1].AddScore("Luke", 3000);
        scores[2].AddScore("Dean", 1000);
        scores[3].AddScore("Subra", 500);
        scores[4].AddScore("Jake", 100);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string ScoreList()
    {
        string scoreList = "";
        for (int i = 0; i < MAX_SCORES; ++i)
        {
            scoreList += scores[i].name.PadRight(6) + "\t" + String.Format("{0:n0}", scores[i].score) + "\n";
        }
        return scoreList;
    }


    public void AddScore(string name, int score)
    {
        for (int i = 0; i < MAX_SCORES; ++i)
        {
            if (score > scores[i].score)
            {
                for (int j = MAX_SCORES - 1; j > i; --j)
                {
                    scores[j].score = scores[j - 1].score;
                    scores[j].name = scores[j - 1].name;
                }
                scores[i].score = score;
                scores[i].name = name;
                break;
            }
        }
    }

    public class scoreentry
    {
        public string name { get; set; }
        public int rank { get; set; }
        public int score { get; set; }

        public void AddScore(string name, int score)
        {
            this.name = name.Substring(0, (name.Length > 5) ? 5 : name.Length);
            this.score = score;
        }


    }

}

