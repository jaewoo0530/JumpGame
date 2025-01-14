using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // UI ��� ����
    public GameObject gameOverText;
    public GameObject clearText;
    public Button restartButton;

    void Start()
    {
        // �ʱ� ����: ��� UI ��Ȱ��ȭ
        gameOverText.SetActive(false);
        clearText.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // Restart ��ư�� Ŭ�� �̺�Ʈ ����
        restartButton.onClick.AddListener(RestartGame);
    }

    // ���� ���� ȭ�� ǥ��
    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // Ŭ���� ȭ�� ǥ��
    public void ShowClear()
    {
        clearText.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // ���� �����
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
