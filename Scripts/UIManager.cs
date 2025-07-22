using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class UIManager : MonoBehaviour
{
    public AudioSource clip;

    public GameObject optionsPanel;

    public GameObject volumePanel;


    public void OptionsPanel() 
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
        volumePanel.SetActive(false);
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void AnotherOptions() 
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(false);
        volumePanel.SetActive(true);
    }

    public void GoMenuMenu()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                player.GetComponent<PlayerRespawn>().ClearCheckpoint();
            }
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void ExitMainMenu()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            player.GetComponent<PlayerRespawn>().ClearCheckpoint();
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void PlaySoundButton()
    {
        clip.Play();   
    }
}
