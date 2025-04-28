using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Score scoreManager;


    void Start()
    {
        InvokeRepeating("GenRock", 1/2,1 );
    }

    void GenRock()
    {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(-5f + 10 * Random.value, 6, 0), Quaternion.identity);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemy.tag = "Enemy";
        if (enemyScript != null)
        {
            enemyScript.scoreManager = scoreManager;
        }
    }
}

