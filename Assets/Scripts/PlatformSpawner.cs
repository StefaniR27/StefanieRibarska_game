using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D col)
{
    Debug.Log("TRIGGER HIT");

    if (!col.CompareTag("Player")) return;

    Instantiate(platformPrefab, spawnPoint.position, Quaternion.identity);
}
}