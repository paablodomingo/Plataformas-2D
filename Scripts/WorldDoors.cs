using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WorldDoors : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string worldName;
    private bool inDoor = false;

    private float doorTime = 3;
    private float startTime = 3;

    private bool isTransitioning = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (!isTransitioning && text != null)
        {
            text.gameObject.SetActive(false);
        }
        inDoor = false;
        doorTime = startTime;
    }


    private void Update()
    {
        if (inDoor)
        {
            doorTime -= Time.deltaTime;
        }

        if (doorTime <= 0)
        {
            isTransitioning = true;

            if (text != null)
            {
                text.gameObject.SetActive(false);
            }

            SceneManager.LoadScene(worldName);
        }


        if (inDoor && Input.GetKey("e") && !isTransitioning)
        {
            isTransitioning = true;

            if (text != null) 
            {
                text.gameObject.SetActive(false);
            }

            SceneManager.LoadScene(worldName);
        }
    }
}
