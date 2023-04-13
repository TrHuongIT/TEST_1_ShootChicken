using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{

    public int bulletHitsToDestroy = 5;
    public static int score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            bulletHitsToDestroy--;
            if(bulletHitsToDestroy == 0)
            {
                Destroy(gameObject);
                score++;
            }
        }
    }
}
