using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // �̱��� ����
    public GameObject playerPrefab; // �÷��̾� ������
    public Transform respawnPoint; // ������ ��ġ

    private GameObject currentPlayer; // ���� �÷��̾� �ν��Ͻ�

    private void Awake()
    {
        // �̱��� �ʱ�ȭ
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
        // ���� ���� �� ù ��° �÷��̾� ����
        if (respawnPoint == null)
        {
            GameObject defaultRespawnPoint = new GameObject("DefaultRespawnPoint");
            defaultRespawnPoint.transform.position = new Vector3(0f, 0f, 0f);
            respawnPoint = defaultRespawnPoint.transform;
        }
        RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        if (playerPrefab != null && respawnPoint != null)
        {
            // ���� �÷��̾ ���� ��� ����
            if (currentPlayer != null)
            {
                Destroy(currentPlayer);
            }

            // ���ο� �÷��̾� ���� �� ����
            currentPlayer = Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation);
        }
        else
        {
            Debug.LogError("PlayerPrefab or RespawnPoint is not assigned!");
        }
    }
}
