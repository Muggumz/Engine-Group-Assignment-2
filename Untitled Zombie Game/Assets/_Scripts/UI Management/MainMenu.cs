using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{
    //initialize button
    [SerializeField] private Button startButton;

    [SerializeField] private Button settingsButton;

    public override void Initialize()
    {
        //attach button command
        settingsButton.onClick.AddListener(() => MenuManager.Show<SettingsMenu>());

        startButton.onClick.AddListener(() => SceneManager.LoadScene(1));
    }


}

