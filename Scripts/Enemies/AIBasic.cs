using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class AIBasic : MonoBehaviour 
{
    public Animator Animator;
    public SpriteRenderer spriteRenderer;

    public float speed = 0.5f;
    private float waitTime;

    public Transform[] moveSpots;

    public float startWaitTime = 2;
    private int i = 0;

    private Vector2 actualPos;

    private void Start()
    {
        waitTime = startWaitTime;
    }

    private void Update()
    {
        StartCoroutine(CheckEnemyMoving()); 
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitTime = startWaitTime;
            }
            else
            { 
                waitTime -= Time.deltaTime;
            }

        }
    }

    //Co-rutina, para rotar el enemigo cuando llegue al waypoint
    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;
        //Esperamos 
        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > actualPos.x)
        {
            spriteRenderer.flipX = true;
            Animator.SetBool("Idle", false);
        }
        else if (transform.position.x < actualPos.x)
        {
            spriteRenderer.flipX = false;
            Animator.SetBool("Idle", false);
        }
        else if(transform.position.x == actualPos.x)
        {
            Animator.SetBool("Idle", true);
        }



    }
}
