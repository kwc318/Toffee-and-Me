using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class StoryScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
    public Canvas mainStory;
    public GameObject textBoxContainer;
    public GameObject textBox;
    public GameObject bunnysprite;
    public Canvas choiceContainer;
    public float StoryFontSize;
    public TextMeshProUGUI textPrefab;
    public Button buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSON.text);
        //eraseUI();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && story.canContinue)
        {
            refreshUI();
            Debug.Log("Left Mouse button clicked");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Restart();
            Debug.Log("escape was pressed");
        }
    }

    public void Restart()
    {
        //This function restarts the scene from the beginning
        SceneManager.LoadScene(sceneName: "GameplayScene");
    }

    void eraseUI()
    {
        //This function remove all text items from screen
        for (int i = 0; i < mainStory.transform.childCount; i++)
        {
            Destroy(mainStory.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < textBoxContainer.transform.childCount; i++)
        {
            Destroy(textBoxContainer.transform.GetChild(i).gameObject);
        }
    }  

    void refreshUI()
    {
        //This function refreshes the screen and proceeds with the story

        eraseUI();

        //This instantiates the text gameobjects. Be sure that the TextMeshPro game object/prefab has been created and is correctly linked on unity editor
        TextMeshProUGUI storyText = Instantiate(textPrefab) as TextMeshProUGUI;

        //This sets the font size of the created text items
        storyText.fontSize = StoryFontSize;

        //These 3 lines of code load the text onto the canvas
        string text = loadStoryChunk();
        storyText.text = text;
        storyText.transform.SetParent(mainStory.transform, false);

        //Instantiates the text box
        GameObject mainTextBox = Instantiate(textBox);
        mainTextBox.transform.SetParent(textBoxContainer.transform, false);

        List<string> tags = story.currentTags;

        foreach (string choicetags in story.currentTags)
        {
            if (choicetags == "bunny")
            {
                Debug.Log("bunny was instantiated");
                //GameObject bunny = Instantiate(bunnysprite);
            }
        }

        foreach (Choice choice in story.currentChoices)
        {
            if (choice.index == 1)
            {
                Debug.Log("choice 1");
                GameObject bunny = Instantiate(bunnysprite);
                Button choiceButton = Instantiate(buttonPrefab) as Button;
                TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
                choiceText.text = choice.text;
                choiceButton.transform.SetParent(choiceContainer.transform, false);
                choiceButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(10f, 2f);
                choiceButton.onClick.AddListener(delegate
                {
                    chooseStoryChoice(choice);
                    Debug.Log("The index is " + choice.index + " and its text is '" + choice.text + "'");
                });
            }
            //Button choiceButton = Instantiate(buttonPrefab) as Button;
            //TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            //choiceText.text = choice.text;
            //choiceButton.transform.SetParent(choiceContainer.transform, false);
            //choiceButton.onClick.AddListener(delegate
            //{
            //    chooseStoryChoice(choice);
            //    Debug.Log("The index is " + choice.index + " and its text is '" + choice.text + "'");
            //});
        }
    }

    string loadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.Continue();
        }

        return text;
    }

    void chooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refreshUI();
    }
}
