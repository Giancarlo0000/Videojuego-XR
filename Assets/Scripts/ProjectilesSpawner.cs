using UnityEngine;

public class ProjectilesSpawner : MonoBehaviour
{
    [SerializeField] public float Radius = 10f;
    [SerializeField] private float TimeInterval = 2f;
    [SerializeField] private string EnemyTag = "Enemy";
    [SerializeField] private float MinimumHeight = 2f;
    [SerializeField] private float MaximumHeight = 7f;
    [SerializeField] private float MinPatrolSpeed = 0.15f;
    [SerializeField] private float MaxPatrolSpeed = 0.25f;

    private float _timeSinceLastSpawn = 0f;

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= TimeInterval)
        {
            _timeSinceLastSpawn = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        float angle = Random.Range(0f, 2 * Mathf.PI);

        Vector3 position = new Vector3(
            transform.position.x + Radius * Mathf.Cos(angle),
            Random.Range(transform.position.y + MinimumHeight, transform.position.y + MaximumHeight),
            transform.position.z + Radius * Mathf.Sin(angle));

        GameObject enemy = ObjectPooling.Instance.SpawnFromPool(EnemyTag, position, Quaternion.identity);

        if (enemy != null)
        {
            Dron dronComponent = enemy.GetComponent<Dron>();
            if (dronComponent != null)
            {
                float patrolSpeed = Random.Range(MinPatrolSpeed, MaxPatrolSpeed);
                enemy.GetComponent<Dron>().Initialize(this, patrolSpeed);
            } 
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
