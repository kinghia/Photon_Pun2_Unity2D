using System.Collections;
using UnityEngine;
using Photon.Pun;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefabs;
    [SerializeField] Transform rangePlayer;
    [SerializeField] float minDistance = 5f;
    [SerializeField] float maxRange = 15f;

    public float timeSpawn = 1f;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized * Random.Range(minDistance, maxRange);
            Vector3 spawnPosition = rangePlayer.position + new Vector3(randomDirection.x, randomDirection.y, 0 );
            yield return new WaitForSeconds(timeSpawn);
            PhotonNetwork.Instantiate("Enemy_Bat", spawnPosition, Quaternion.identity);
            Debug.Log("spawn enemy");
        }
    }

    void OnDrawGizmosSelected()
    {
        if (rangePlayer == null) return;

        Gizmos.DrawWireSphere(rangePlayer.position, minDistance);        
    }

}
