using UnityEngine;
using UnityEngine.UI; // UIのTextを使用するため
using UnityEngine.SceneManagement; // シーンを再読み込みするため

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f; // 制限時間（秒）
    private float currentTime;

    public Text timerText; // UIで表示するためのText
    public GameObject RestartButton; // RestartボタンのUIオブジェクト
    public GameObject startButton; // StartボタンのUIオブジェクト
    public GameObject Player;
    public GameObject Score;
    public GameObject Time2;
    public GameObject Enemy; // ゲームの本体（プレイヤーや敵など）
    public GameObject EnemyObject; // EnemyObject を参照
    public GameObject EnemyGenerator;
    private bool timerIsRunning = false;


    public float CurrentTime
    {
        get { return currentTime; }
        set { currentTime = value; }
    }

    void Start()
    {
        currentTime = timeLimit;
        RestartButton.SetActive(false); // ゲーム開始時はボタンを非表示にする
        startButton.SetActive(true); // ゲーム開始前はStartボタンを表示
        timerText.text = "Time: " + timeLimit.ToString("F1"); // タイマーの初期状態

        Player.SetActive(false);     // プレイヤーを隠す
        Score.SetActive(false);
        Time2.SetActive(false);
        Enemy.SetActive(false);     // ゲーム本体を非表示
        EnemyObject.SetActive(false); // 敵オブジェクトも非表示にする
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // タイマーを減らす
            currentTime = Mathf.Max(currentTime, 0); // 現在の時間が0未満にならないようにする

            // タイマーの値をUIに表示
            timerText.text = "Time: " + currentTime.ToString("F1");
        }
        if (currentTime <= 0)
        {
            EndGame(); // ← まとめた関数を呼ぶだけ
        }
    }
    void EndGame()
    {

        ShowRestartButton();
        HidePlayer();
        HideEnemy();
    }

    // Restartボタンを表示するための関数
    void ShowRestartButton()
    {
        startButton.SetActive(true); // ボタンを表示
    }

    void HidePlayer()
    {
        Player.SetActive(false); // プレイヤーを非表示にする
    }

    void HideEnemy()
    {
        Enemy.SetActive(false);         // 敵本体も非表示
        EnemyObject.SetActive(false);   // 敵オブジェクトも非表示
        
        EnemyGenerator.SetActive(false); // ★ EnemyGeneratorも止める！！
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

    }

    // Startボタンが押された時にタイマーを開始する関数

    public void StartGame()
    {
        startButton.SetActive(false); // Startボタンを非表示にする
        RestartButton.SetActive(false); // Restartボタンを非表示にする
        currentTime = timeLimit; // タイマーをリセット

        Player.SetActive(true);      // プレイヤー出現
        Score.SetActive(true);      // スコアやUI出現
        Time2.SetActive(true);
        Enemy.SetActive(true);     // ゲーム本体表示
        EnemyObject.SetActive(true); // 敵オブジェクトを表示
    }

    // Restartボタンが押されたときに呼び出される関数
    public void RestartGame()
    {
        Debug.Log("Restart押されたよ！");
        SceneManager.LoadScene("GameSCENE");
    }
}
