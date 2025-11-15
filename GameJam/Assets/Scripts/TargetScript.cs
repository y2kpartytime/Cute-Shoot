using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float speed;
    public Time time;
    public GameObject spawnPoint2;
    public float sinCenterY;
    public bool left;
    PlayerScript playerScript;

    void Start()
    {
        speed = UnityEngine.Random.Range(2f, 8f);
        sinCenterY = transform.position.y;
    }

    void Update()
    {
        if (!left)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x);
        
        pos.y = sinCenterY + sin;
        transform.position = pos;

        if (playerScript.gameTimer <= 0)
        {
            speed = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }
    }

    public void Despawn()
    {
        Destroy(this);
    }
}
