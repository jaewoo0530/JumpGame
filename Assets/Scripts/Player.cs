using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform respawnPoint; // 리스폰 위치

    public void RespawnPlayer()
    {
        // 새로운 플레이어 인스턴스 생성
        GameManager.Instance.RespawnPlayer();
    }

    public void Die()
    {
        // 현재 플레이어 파괴
        Destroy(gameObject);

        // 리스폰 처리
        RespawnPlayer();
    }
}
