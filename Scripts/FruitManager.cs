using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    public GameObject transition;

    public Text totalFruits;
    public Text fruitsCollected;
    public TextMeshProUGUI totalFruits2;
    public TextMeshProUGUI fruitsCollected2;
    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }

    //Pregunta cada frame cuantas frutas tiene, solucion a posible error de coger 
    //varias frutas en menos de 0,5 seg (por el script de fruit collected)

    private void Update()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        totalFruits2.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = transform.childCount.ToString();
        fruitsCollected2.text = transform.childCount.ToString();
    }
    public void AllFruitsCollected()
    {
        if(transform.childCount == 0)
        {
            Debug.Log("No quedan frutas, ganaste wey");
            levelCleared.gameObject.SetActive(true);
            transition.SetActive(true);
            Invoke("ChangeScene", 3);
            
        }
    }

    void ChangeScene()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            player.GetComponent<PlayerRespawn>().ClearCheckpoint();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
