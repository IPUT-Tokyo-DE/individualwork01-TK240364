using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject Start;
    public GameObject Player;
    public GameObject Score;
    public GameObject Time;
    public GameObject Enemy; // �Q�[���̖{�́i�v���C���[��G�Ȃǁj
    public GameObject EnemyObject;
    public Timer timer;

    public void StartGame()
    {

        Start.SetActive(false);     // �^�C�g����\��
        Player.SetActive(true);
        Score.SetActive(true);          // �Q�[��UI�\��
        Time.SetActive(true);
        Enemy.SetActive(true);     // �Q�[���{�̕\��
        EnemyObject.SetActive(true);
    }
}

