using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    int frameCount = 0;             // フレームカウント
    const int deleteFrame = 120;    // 削除フレーム
    public float MoveSpeed = 20.0f;         // 移動値

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 位置の更新
        transform.Translate(0,MoveSpeed * Time.deltaTime, 0);
        // 一定フレームで消す
        if (++frameCount > deleteFrame)
        {
            Destroy(gameObject);
        }

    }
}
