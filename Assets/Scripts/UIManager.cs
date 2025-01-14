using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // UI 요소 참조
    public GameObject gameOverText;
    public GameObject clearText;
    public Button restartButton;

    void Start()
    {
        // 초기 상태: 모든 UI 비활성화
        gameOverText.SetActive(false);
        clearText.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // Restart 버튼에 클릭 이벤트 연결
        restartButton.onClick.AddListener(RestartGame);
    }

    // 게임 오버 화면 표시
    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // 클리어 화면 표시
    public void ShowClear()
    {
        clearText.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // 게임 재시작
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
