using UnityEngine;

public class BeeBullet : MonoBehaviour
{
    public float speed = 1.5f;
    public float lifeTime = 2;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

}
