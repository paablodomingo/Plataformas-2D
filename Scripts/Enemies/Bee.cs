using UnityEngine;

public class Bee : MonoBehaviour
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
}
