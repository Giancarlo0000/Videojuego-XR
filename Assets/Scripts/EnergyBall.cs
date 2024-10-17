using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    [SerializeField] private float lifeTime = 10f;
    
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print(other.gameObject);            
            Destroy(other.gameObject);            
            Destroy(gameObject);

        }
        if (other.CompareTag("EnemyProjectile"))
        {
            print(other.gameObject);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
