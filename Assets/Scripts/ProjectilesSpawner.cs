using UnityEngine;

public class ProjectilesSpawner : MonoBehaviour
{
    [SerializeField] private float Radius = 10f;
    [SerializeField] private float TimeInterval = 2f;
    [SerializeField] private GameObject Projectile = null;
    
    private void Start() {
        InvokeRepeating("InstantiateProjectiles", TimeInterval, TimeInterval);
    }

    private void InstantiateProjectiles(){
        float angle = Random.Range(0f, 2 * Mathf.PI);

        Vector3 position = new Vector3(
            transform.position.x + Radius * Mathf.Cos(angle),
            Random.Range(transform.position.y + 2f, transform.position.y + 15f),
            transform.position.z + Radius * Mathf.Sin(angle));

        //Instantiate(Projectile, new Vector3(Random.Range(transform.position.x - 5f, transform.position.x + 5f), Random.Range(transform.position.y + 5f, transform.position.y + 15f), transform.position.z + Radius), Quaternion.identity);
        Instantiate(Projectile, position, Quaternion.identity);
    }

    
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
