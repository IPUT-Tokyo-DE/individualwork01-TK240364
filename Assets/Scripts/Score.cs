using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;  // Textを使うために必要な名前空間をインポート

public class Score : MonoBehaviour
{
    private int Score1; //得点の変数
    public Text ScoreText; //得点の文字の変数
    public Text bigScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Score1 = 0; //得点を0にする
        UpdateScoreText();
    }

    // Update is called once per frame
    public void AddScore(int amount)
    {
        Score1 += amount;
        UpdateScoreText();
    }

    // スコア表示更新
    void UpdateScoreText()
    {
        ScoreText.text = "Score: " + Score1;
    }

}
