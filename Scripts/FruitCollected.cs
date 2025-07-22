using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Audio;

public class FruitCollected : MonoBehaviour
{

    public AudioSource clip;
    //Cuando algo entra en contacto con el collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        { 
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            //Para ver si quedan frutas por recoger
            FindObjectOfType<FruitManager>().AllFruitsCollected();

            Destroy(gameObject, 0.5f);

            clip.Play();
        }
    }


}
