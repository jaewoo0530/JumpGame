using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글턴 패턴
    public GameObject playerPrefab; // 플레이어 프리팹
    public Transform respawnPoint; // 리스폰 위치

    private GameObject currentPlayer; // 현재 플레이어 인스턴스

    private void Awake()
    {
        // 싱글턴 초기화
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 게임 시작 시 첫 번째 플레이어 생성
        RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        if (playerPrefab != null && respawnPoint != null)
        {
            // 이전 플레이어가 있을 경우 삭제
            if (currentPlayer != null)
            {
                Destroy(currentPlayer);
            }

            // 새로운 플레이어 생성 및 관리
            currentPlayer = Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation);
        }
        else
        {
            Debug.LogError("PlayerPrefab or RespawnPoint is not assigned!");
        }
    }
}
