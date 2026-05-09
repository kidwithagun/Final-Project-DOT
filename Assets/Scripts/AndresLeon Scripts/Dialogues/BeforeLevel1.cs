using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDialogue : MonoBehaviour
{
    public List<string> dialogue = new List<string>();
    public List<Sprite> leftSprites = new List<Sprite>();
    public List<Sprite> rightSprites = new List<Sprite>();
    private bool canSpeak = false;
    private bool isSpeaking = false;
    private GameObject _talkPanel;
    public Image LeftShower;
    public Image RightShower;
    private TextMeshProUGUI _talkText;
    private int _talkIndex = 0;
    public string scene;

    private void Start()
    {
        _talkText = GameObject.Find(Structs.GameObjects.talkText).GetComponent<TextMeshProUGUI>();

        _talkPanel = GameObject.Find(Structs.GameObjects.talkPanel);
        _talkPanel.SetActive(true);
        isSpeaking = true;
        ResetDialogue();
    }

    private void ResetDialogue()
    {
        StopAllCoroutines();
        _talkText.text = dialogue[_talkIndex];
        LeftShower.sprite = leftSprites[_talkIndex];
        RightShower.sprite = rightSprites[_talkIndex];
        _talkText.maxVisibleCharacters = 0;
        StartCoroutine(IterateString());
    }

    // Update is called once per frame
    void Update()
    {
        //CharacterSwap();
        if (isSpeaking && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue.Count - 1 == _talkIndex) //Stop the dialogue once it ends
            {
                isSpeaking = false;
                _talkPanel.SetActive(false);
            }
            else
            {
                _talkIndex++;
                if (_talkIndex == 19)
                {
                    SceneManager.LoadScene(scene);
                }
                ResetDialogue();

            }
            
        }
        else if (canSpeak && Input.GetKeyDown(KeyCode.E))
        {
            isSpeaking = true;
            _talkPanel.SetActive(true);
            _talkIndex = 0;
            LeftShower.sprite = leftSprites[_talkIndex];
            RightShower.sprite = rightSprites[_talkIndex];
            _talkText.text = dialogue[_talkIndex];
        }
    }

    public float waitTime = 2f;
    IEnumerator IterateString()
    {
        for (int i = 0; i < _talkText.text.Length; i++)
        {
            _talkText.maxVisibleCharacters++;
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void SetCanSpeak(bool newCanSpeak)
    {
        canSpeak = newCanSpeak;
    }

    public bool IsSpeaking()
    {
        return isSpeaking;
    }

    public void CopyDialogue(List<string> newDialogue)
    {
        dialogue.Clear();
        dialogue.AddRange(newDialogue);
    }

    /*private void CharacterSwap()
    {
        if (_talkIndex == 3)
        {
            character.SetActive(true);
        }
    }
    */

}