using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;
    private Queue<string> sentences;
    private Queue<string> names;

    public bool speaking = false;
    public bool mid_sentence = false;

    public float waitseconds = 0.025f;

    public AudioSource typing;

    public void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
    }

    public void Update()
    {

        if (!speaking)
        {
            animator.SetBool("IsOpen", false);
        }
        else
        {
            if (Input.GetButtonDown("Dialogue"))
            {
                if (!mid_sentence)
                {
                    DisplayNextSentence();
                }
                else
                {
                    mid_sentence = false;
                }
            }
        }
    }

    public void StartDialogue(Lisa_d Dialogue)
    {
            animator.SetBool("IsOpen", true);

            sentences.Clear();
            names.Clear();

            foreach (string sentence in Dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            foreach (string name in Dialogue.names)
            {
                names.Enqueue(name);
            }

            DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        nameText.text = name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        mid_sentence = true;
        typing.Play();
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(waitseconds);
            yield return null;

            if (!mid_sentence)
            {
                break;
            }
        }
        dialogueText.text = sentence;
        mid_sentence = false;
        typing.Pause();

    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        speaking = false;
        FindObjectOfType<player_movement>().cutscene = false;
    }
}
