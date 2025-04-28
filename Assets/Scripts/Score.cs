using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;  // Text���g�����߂ɕK�v�Ȗ��O��Ԃ��C���|�[�g

public class Score : MonoBehaviour
{
    private int Score1; //���_�̕ϐ�
    public Text ScoreText; //���_�̕����̕ϐ�
    public Text bigScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Score1 = 0; //���_��0�ɂ���
        UpdateScoreText();
    }

    // Update is called once per frame
    public void AddScore(int amount)
    {
        Score1 += amount;
        UpdateScoreText();
    }

    // �X�R�A�\���X�V
    void UpdateScoreText()
    {
        ScoreText.text = "Score: " + Score1;
    }

}
