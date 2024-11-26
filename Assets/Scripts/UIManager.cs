using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; // reference to the UI manager

    public Image blackScreen; // reference to the black screen
    public float fadeSpeed = 2f; // the speed of the fade
    public bool fadeToBlack, fadeFromBlack;
    public Text healthText; 
    public Image healthImage;
    public Text coinText;
    public GameObject pauseScreen;
    public GameObject optionsScreen;
    public Slider musicVolSlider, sfxVolSlider;

    private void Awake()
    {
        instance = this; // set the instance to this UI manager
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack) // if the fade to black is true
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime)); // fade to black
            if (blackScreen.color.a == 1f) // if the black screen is black
            {
                fadeToBlack = false; // set the fade to black to false
            }
        }

        if (fadeFromBlack) // if the fade from black is true
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime)); // fade from black
            if (blackScreen.color.a == 0f) // if the black screen is not black
            {
                fadeFromBlack = false; // set the fade from black to false
            }
        }
    }

    public void Resume()
    {
        GameManager.instance.PauseUnpause(); // pause or unpause the game
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true); // activate the options screen
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false); // deactivate the options screen
    }

    public void LevelSelect()
    {
        Debug.Log("Level Select");
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu");
    }

    public void SetMusicLevel()
    {
        AudioManager.instance.SetMusicLevel(); 
    }

    public void SetSFXLevel()
    {
        AudioManager.instance.SetSFXLevel();
    }
}
