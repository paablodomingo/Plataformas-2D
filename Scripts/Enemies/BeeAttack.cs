using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    public Animator animator;

    public float distanceRaycast = 0.5f;

    private float cooldownAttack = 1;
    private float actualCooldownAttack;

    public GameObject beeBullet;

    private void Start()
    {
        actualCooldownAttack = 0;
    }

    private void Update()
    {
        actualCooldownAttack -= Time.deltaTime;
       //Debug.DrawRay(transform.position, Vector2.down, Color.red, distanceRaycast);

    }

    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distanceRaycast);

        if (hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Player"))
            {
                if (actualCooldownAttack < 0)
                {
                    Invoke("LaunchBullet", 0.5f);
                    animator.Play("Attack");
                    actualCooldownAttack = cooldownAttack;
                }
            }
        }
    }

    void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(beeBullet, transform.position, transform.rotation);
    }
}
