using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform respawnPoint;
    private void Start()
    {
        GameObject respawnObject = GameObject.FindWithTag("RespawnPoint");
        if (respawnObject != null)
        {
            respawnPoint = respawnObject.transform;
        }
    }

    public void RespawnPlayer()
    {
        GameObject target = GameObject.FindWithTag("Player");
        // 새로운 플레이어 인스턴스 생성
        Instantiate(target, respawnPoint.position, respawnPoint.rotation);
    }
    public void Die()
    {
        Destroy(gameObject);
        RespawnPlayer();
    }
}
