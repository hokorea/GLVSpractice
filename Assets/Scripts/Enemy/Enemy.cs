using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;

    public int hp;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed);
    }

    public void Hit(int Damage)
    {
        hp -= Damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
