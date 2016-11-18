using UnityEngine;
using System.Collections;

public class DialoguePause : MonoBehaviour
{

    public AvatarController avatar;
    public GameUI game;
    public CanvasGroup DialogBox;
    public int dialogueChoice = 0;

    public string[] dialogues = { "The invading aliens mothership is directly above us inflitrate the mothership and capture or destroy it",
                                    "These basic melee enemies are the runts of the enemy species they will charge you and try to harm you at close range",
                                    "These shielded enemies are much like the basic melee enemies except can only be shot from behind",
                                    "The much larger \"Boss\" enemies are much stronger and fire high damage but slow moving plasma projectiles" };
    string dialogue;

    // Use this for initialization
    void Awake()
    {
        avatar = FindObjectOfType<AvatarController>();
        game = FindObjectOfType<GameUI>();
        DialogBox = GameObject.Find("DialogBox").GetComponent<CanvasGroup>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Submit"))
        {
            //avatar.disableInput = false;
            game.HideDialog();
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            dialogue = dialogues[dialogueChoice];
            Debug.Log(dialogue);
            game.ShowDialog(dialogue);
            Destroy(this.gameObject);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
