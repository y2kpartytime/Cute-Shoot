using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float speed;
    public Time time;
    public GameObject spawnPoint2;
    public float sinCenterY;

    void Start()
    {
        speed = UnityEngine.Random.Range(2f, 5f);
        sinCenterY = transform.position.y;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x);
        
        pos.y = sinCenterY + sin;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }
    }
}
