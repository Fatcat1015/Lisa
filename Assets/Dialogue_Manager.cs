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
                DisplayNextSentence();
            }
        }

    }

    public void StartDialogue(Lisa_d Dialogue)
    {
            Debug.Log("start");
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
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        speaking = false;
    }
}
