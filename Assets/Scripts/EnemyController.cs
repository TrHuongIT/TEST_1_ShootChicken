using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;

    //Square
    public GameObject[,] enemies = new GameObject[4, 4];
    //public float speed = 2f;


    // Start is called before the first frame update
    private void Start()
    {
        //SpawnSquare();
        //SpawnRhombus();
        //SpawnTriangle();
        //SpawnRectangle();
        StartCoroutine(StartSpawnSequence());

    }

    IEnumerator StartSpawnSequence()
    {
        SpawnSquare();

        yield return new WaitForSeconds(5f);
        DestroyAllEnemies();
        SpawnRhombus();

        yield return new WaitForSeconds(5f);
        DestroyAllEnemies();
        SpawnTriangle();

        yield return new WaitForSeconds(5f);
        DestroyAllEnemies();
        SpawnRectangle();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().SetSpawnRectangleCalled(true);
    }

    private void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    private void SpawnSquare()
    {
        // Spawn enemies Square
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                //GameObject enemy = Instantiate(enemyPrefab, new Vector3(j - 1.5f, i + 1, 0), Quaternion.identity);
                //enemies[i, j] = enemy;

                Vector3 spawnPos = new Vector3(j - 1.5f, i + 1.5f, 0);
                GameObject enemy = Instantiate(enemyPrefab, new Vector3(spawnPos.x, 7, 0), Quaternion.identity);
                StartCoroutine(MoveEnemy(enemy, spawnPos));
            }
        }
    }

    private void SpawnRhombus()
    {
        Vector3[] positions = new Vector3[] {
        new Vector3(0f,     4f,     0f),
        new Vector3(-1f,    3.5f,   0f),
        new Vector3(-0.5f,  3.5f,   0f),
        new Vector3(0.5f,   3.5f,   0f),
        new Vector3(1f,     3.5f,   0f),
        new Vector3(-1.5f,  2.75f,  0f),
        new Vector3(-1f,    2.75f,  0f),
        new Vector3(-0.5f,  2.75f,  0f),
        new Vector3(0.5f,   2.75f,  0f),
        new Vector3(1f,     2.75f,  0f),
        new Vector3(1.5f,   2.75f,  0f),
        new Vector3(-1f,    2f,     0f),
        new Vector3(-0.5f,  2f,     0f),
        new Vector3(0.5f,   2f,     0f),
        new Vector3(1f,     2f,     0f),
        new Vector3(0f,     1.5f,   0f)
        };

        for (int i = 0; i < positions.Length; i++)
        {
            //GameObject obj = Instantiate(enemyPrefab, positions[i], Quaternion.identity);

            GameObject enemy = Instantiate(enemyPrefab, new Vector3(positions[i].x, 7, 0), Quaternion.identity);
            StartCoroutine(MoveEnemy(enemy, positions[i]));
        }
    }

    

    private void SpawnTriangle()
    {
        Vector3[] positions = new Vector3[] {
        new Vector3(0f,     4f,     0f),

        new Vector3(-0.5f,  3.5f,   0f),
        new Vector3(0.5f,  3.5f,   0f),

        new Vector3(-1f,    3f,     0f),
        new Vector3(1f,     3f,     0f),

        new Vector3(-1.5f,  2.5f,   0f),
        new Vector3(1.5f,   2.5f,   0f),

        new Vector3(-2f,  2f, 0f),
        new Vector3(-1.5f,   2f, 0f),
        new Vector3(-1f,     2f, 0f),
        new Vector3(-0.5f,   2f, 0f),
        new Vector3(0f,    2f, 0f),
        new Vector3(0.5f,  2f, 0f),
        new Vector3(1f,   2f, 0f),
        new Vector3(1.5f,     2f, 0f),
        new Vector3(2f,     2f, 0f)
        };

        for (int i = 0; i < positions.Length; i++)
        {
            //GameObject obj = Instantiate(enemyPrefab, positions[i], Quaternion.identity);

            GameObject enemy = Instantiate(enemyPrefab, new Vector3(positions[i].x, 7, 0), Quaternion.identity);
            StartCoroutine(MoveEnemy(enemy, positions[i]));
        }
    }

    private void SpawnRectangle()
    {
        Vector3[] positions = new Vector3[] {
        new Vector3(0f,     4f,     0f),

        new Vector3(-0.5f,  4f,   0f),
        new Vector3(0.5f,  4f,   0f),
        new Vector3(-1f,    4f,     0f),
        new Vector3(1f,     4f,     0f),
        new Vector3(-1.5f,  4f,   0f),
        new Vector3(1.5f,   4f,   0f),

        new Vector3(1.5f,  3.5f, 0f),
        new Vector3(-1.5f,   3.5f, 0f),

        new Vector3(0f,     3f, 0f),

        new Vector3(-0.5f,   3f, 0f),
        new Vector3(0.5f,    3f, 0f),
        new Vector3(-1f,    3f, 0f),
        new Vector3(1f,     3f, 0f),
        new Vector3(-1.5f,    3f, 0f),
        new Vector3(1.5f,     3f, 0f)
        };

        for (int i = 0; i < positions.Length; i++)
        {
            //GameObject obj = Instantiate(enemyPrefab, positions[i], Quaternion.identity);

            GameObject enemy = Instantiate(enemyPrefab, new Vector3(positions[i].x, 7, 0), Quaternion.identity);
            StartCoroutine(MoveEnemy(enemy, positions[i]));
        }
    }

    private IEnumerator MoveEnemy(GameObject enemy, Vector3 targetPos)
    {
        float speed = 2f;
        float distance = Mathf.Abs(enemy.transform.position.y - targetPos.y);
        while (enemy.transform.position.y > targetPos.y)
        {
            float step = speed * Time.deltaTime;
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPos, step);
            yield return null;
        }
    }
}
