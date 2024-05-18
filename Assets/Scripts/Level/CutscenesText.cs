using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Dialogue
{
    public string speaker;
    public string line;
}

[System.Serializable]
public class CutsceneDialogue
{
    public int cutsceneIndex;
    public List<Dialogue> dialogues;
}

[System.Serializable]
public class DialogueData
{
    public List<CutsceneDialogue> cutscenes;
}

public class CutscenesText : MonoBehaviour
{
    TMP_Text dialogueText;

    int currentLineIndex = 0;
    int currentCutscene = -1;


    public TextAsset dialogueFile;
    private List<CutsceneDialogue> cutscenes;
    private Coroutine typingCoroutine; 

    bool dialogueActive = false;
    float delay = 0.05f;


    string currentString = string.Empty;
    private void Start()
    {
        LoadDialogueData();
        dialogueText = gameObject.GetComponent<TMP_Text>();
    }

    void LoadDialogueData()
    {
        if (dialogueFile != null)
        {
            string jsonText = dialogueFile.text;
            cutscenes = JsonUtility.FromJson<DialogueData>("{\"cutscenes\":" + jsonText + "}").cutscenes;
        }
    }


    public void DisplayDialogue(int cutsceneIndex)
    {
        CutsceneDialogue cutscene = cutscenes.Find(c => c.cutsceneIndex == cutsceneIndex);
        if (cutscene != null)
        {
            if (currentLineIndex < cutscene.dialogues.Count)
            {
                currentString = cutscene.dialogues[currentLineIndex].line;
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                }
                typingCoroutine = StartCoroutine(ShowText(currentString));
                currentLineIndex++;
            }
            else
            {
                CutsceneState.instance.director.Play();
                dialogueText.text = "";
                dialogueActive = false;
            }
        }

    }

    public void StartDialogue()
    {
        CutsceneState.instance.director.Pause();
        currentCutscene++;
        currentLineIndex = 0;
        DisplayDialogue(currentCutscene);
        
    }

    IEnumerator ShowText(string fullText)
    {
        dialogueActive = true;
        dialogueText.text = "";

        for (int i = 0; i <= fullText.Length; i++)
        {
            dialogueText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        typingCoroutine = null;
    }

    private void Update()
    {
        if (dialogueActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                    typingCoroutine = null;
                    dialogueText.text = currentString;
                    print("typing on");

                    return;
                }
                print("typing off");

                DisplayDialogue(currentCutscene);
                
            }
        }
    }
}
