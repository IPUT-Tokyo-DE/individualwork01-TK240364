using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    int frameCount = 0;             // �t���[���J�E���g
    const int deleteFrame = 120;    // �폜�t���[��
    public float MoveSpeed = 20.0f;         // �ړ��l

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �ʒu�̍X�V
        transform.Translate(0,MoveSpeed * Time.deltaTime, 0);
        // ���t���[���ŏ���
        if (++frameCount > deleteFrame)
        {
            Destroy(gameObject);
        }

    }
}
