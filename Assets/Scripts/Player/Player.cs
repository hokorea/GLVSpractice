using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public int speed;

    public float shootDelay;
    public float shootSpeed;

    [SerializeField] GameObject bulletPrefab;

    bool canShoot = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, y, 0);

        transform.position += dir.normalized * speed * Time.deltaTime;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x > 1) pos.x = 1;
        else if (pos.x < 0) pos.x = 0;
        if (pos.y > 1) pos.y = 1;
        else if (pos.y < 0) pos.y = 0;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void Shoot()
    {
        Vector3 shootPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)); shootPoint.z = 0;
        Vector3 dir = (shootPoint - transform.position).normalized;
        //if (!Input.GetMouseButton(0)) return;
        if (!canShoot) return;

        canShoot = false;
        StartCoroutine(ShootDelay());

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(dir * shootSpeed, ForceMode2D.Impulse);
        Debug.Log(dir);
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
