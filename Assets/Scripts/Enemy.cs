using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float rotSpeed;
    public Score scoreManager; // Score�X�N���v�g�ւ̎Q��
    public int pointValue = 100;
    public float fallSpeed = 2f;  // ���O�����������



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
        // ���������̂��v���C���[�̒e
        if (other.gameObject.CompareTag("player_bullet"))
        {
            if (scoreManager != null)
            {
                scoreManager.AddScore(pointValue);
            }

            // ���g������
            Destroy(gameObject);

            // �e������
            Destroy(other.gameObject);
 
        }
    }
}