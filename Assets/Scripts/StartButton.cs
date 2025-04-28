using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject Start;
    public GameObject Player;
    public GameObject Score;
    public GameObject Time;
    public GameObject Enemy; // ゲームの本体（プレイヤーや敵など）
    public GameObject EnemyObject;
    public Timer timer;

    public void StartGame()
    {

        Start.SetActive(false);     // タイトル非表示
        Player.SetActive(true);
        Score.SetActive(true);          // ゲームUI表示
        Time.SetActive(true);
        Enemy.SetActive(true);     // ゲーム本体表示
        EnemyObject.SetActive(true);
    }
}

