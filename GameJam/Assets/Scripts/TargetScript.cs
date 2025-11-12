using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float speed;
    public Time time;
    public GameObject spawnPoint2;

    void Start()
    {
        speed = Random.Range(2f, 5f);
    }

    void Update()
    {
        transform.position -= Vector3.right * speed * Time.deltaTime;

        //need to fix spawning on top of eachother
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x);
        pos.y = sin;
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
