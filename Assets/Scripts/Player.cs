using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    public float fMoveSpeed = 7.0f;
    private float screenLeft, screenRight, screenTop, screenBottom;
    public GameObject BulletObj;
    Vector3 bulletPoint;  // 弾のゲームオブジェクト
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletPoint = transform.Find("BulletPoint").localPosition;
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // 画面の境界（カメラのワールド座標で計算）
            screenLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            screenRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
            screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown("space") )
        {
            // 弾の生成
            Instantiate(BulletObj, transform.position + bulletPoint, Quaternion.identity);
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x += horizontalInput * 0.2f;
     
        transform.position = pos;
        RestrictPlayerToScreen();
    }
    void RestrictPlayerToScreen()
    {
        float playerX = Mathf.Clamp(transform.position.x, screenLeft, screenRight);
        float playerY = Mathf.Clamp(transform.position.y, screenBottom, screenTop);

        transform.position = new Vector3(playerX, playerY, transform.position.z);
    }
}
