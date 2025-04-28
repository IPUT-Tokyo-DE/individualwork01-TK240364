using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float rotSpeed;
    public Score scoreManager; // Scoreスクリプトへの参照
    public int pointValue = 100;
    public float fallSpeed = 2f;  // ←外から代入される



    void Start()
    {

    }

    void Update()
    {
        transform.Translate(0, -fallSpeed, 0, Space.World);

        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 当たったのがプレイヤーの弾
        if (other.gameObject.CompareTag("player_bullet"))
        {
            if (scoreManager != null)
            {
                scoreManager.AddScore(pointValue);
            }

            // 自身を消す
            Destroy(gameObject);

            // 弾も消す
            Destroy(other.gameObject);
 
        }
    }
}