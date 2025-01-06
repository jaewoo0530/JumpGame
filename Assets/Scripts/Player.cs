using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerPrefab; // 플레이어 프리팹
    public Transform respawnPoint;  // 리스폰 위치

    public void RespawnPlayer()
    {
        // 새로운 플레이어 인스턴스 생성
        Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation);
    }
    public void Die()
    {
        Destroy(gameObject);
        RespawnPlayer();
    }
}
