using UnityEngine;
using UnityEngine.UI; // UI��Text���g�p���邽��
using UnityEngine.SceneManagement; // �V�[�����ēǂݍ��݂��邽��

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f; // �������ԁi�b�j
    private float currentTime;

    public Text timerText; // UI�ŕ\�����邽�߂�Text
    public GameObject RestartButton; // Restart�{�^����UI�I�u�W�F�N�g
    public GameObject startButton; // Start�{�^����UI�I�u�W�F�N�g
    public GameObject Player;
    public GameObject Score;
    public GameObject Time2;
    public GameObject Enemy; // �Q�[���̖{�́i�v���C���[��G�Ȃǁj
    public GameObject EnemyObject; // EnemyObject ���Q��
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
        RestartButton.SetActive(false); // �Q�[���J�n���̓{�^�����\���ɂ���
        startButton.SetActive(true); // �Q�[���J�n�O��Start�{�^����\��
        timerText.text = "Time: " + timeLimit.ToString("F1"); // �^�C�}�[�̏������

        Player.SetActive(false);     // �v���C���[���B��
        Score.SetActive(false);
        Time2.SetActive(false);
        Enemy.SetActive(false);     // �Q�[���{�̂��\��
        EnemyObject.SetActive(false); // �G�I�u�W�F�N�g����\���ɂ���
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // �^�C�}�[�����炷
            currentTime = Mathf.Max(currentTime, 0); // ���݂̎��Ԃ�0�����ɂȂ�Ȃ��悤�ɂ���

            // �^�C�}�[�̒l��UI�ɕ\��
            timerText.text = "Time: " + currentTime.ToString("F1");
        }
        if (currentTime <= 0)
        {
            EndGame(); // �� �܂Ƃ߂��֐����ĂԂ���
        }
    }
    void EndGame()
    {

        ShowRestartButton();
        HidePlayer();
        HideEnemy();
    }

    // Restart�{�^����\�����邽�߂̊֐�
    void ShowRestartButton()
    {
        startButton.SetActive(true); // �{�^����\��
    }

    void HidePlayer()
    {
        Player.SetActive(false); // �v���C���[���\���ɂ���
    }

    void HideEnemy()
    {
        Enemy.SetActive(false);         // �G�{�̂���\��
        EnemyObject.SetActive(false);   // �G�I�u�W�F�N�g����\��
        
        EnemyGenerator.SetActive(false); // �� EnemyGenerator���~�߂�I�I
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

    }

    // Start�{�^���������ꂽ���Ƀ^�C�}�[���J�n����֐�

    public void StartGame()
    {
        startButton.SetActive(false); // Start�{�^�����\���ɂ���
        RestartButton.SetActive(false); // Restart�{�^�����\���ɂ���
        currentTime = timeLimit; // �^�C�}�[�����Z�b�g

        Player.SetActive(true);      // �v���C���[�o��
        Score.SetActive(true);      // �X�R�A��UI�o��
        Time2.SetActive(true);
        Enemy.SetActive(true);     // �Q�[���{�̕\��
        EnemyObject.SetActive(true); // �G�I�u�W�F�N�g��\��
    }

    // Restart�{�^���������ꂽ�Ƃ��ɌĂяo�����֐�
    public void RestartGame()
    {
        Debug.Log("Restart�����ꂽ��I");
        SceneManager.LoadScene("GameSCENE");
    }
}
