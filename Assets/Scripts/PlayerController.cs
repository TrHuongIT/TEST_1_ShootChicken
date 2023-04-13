using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float shootInterval = 0.1f;
    public GameObject bulletPrefab;
    public float speed = 5f;

    private float shootTimer;
    private bool spawnRectangleCalled = false;

    void Update()
    {
        MovePlayer();
        //Shoot();
        // Kiểm tra xem SpawnRectangle() đã được gọi hay chưa
        if (spawnRectangleCalled)
        {
            Shoot();
        }
    }

    void MovePlayer()
    {
        // Di chuyển player theo chuột hoặc phím
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        // Tự động bắn đạn theo thời gian
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 bulletPos = transform.position + new Vector3(0, 1, 0);
                GameObject bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
                //bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
            shootTimer = 0;
        }
    }

    public void SetSpawnRectangleCalled(bool called)
    {
        spawnRectangleCalled = called;
    }
}
