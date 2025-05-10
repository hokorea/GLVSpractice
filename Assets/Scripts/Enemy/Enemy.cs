using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed);
    }
}
