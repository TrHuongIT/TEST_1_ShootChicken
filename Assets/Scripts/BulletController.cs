using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f; // Tốc độ bay của đạn

    // Update is called once per frame
    void Update()
    {
        // Di chuyển viên đạn lên trên màn hình
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Hủy đối tượng viên đạn khi nó ra khỏi màn hình
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
