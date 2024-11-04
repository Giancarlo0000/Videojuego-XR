using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private float damage = 5f;
    
    private WinCondition _winCondition;

    private void Awake(){
        _winCondition = FindObjectOfType<WinCondition>();
    }

    private void OnEnable()
    {
        Invoke(nameof(Deactivate), lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Deactivate));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Deactivate();
            Dron dron = other.GetComponent<Dron>();
            dron.TakeDamage(damage);
            if (dron.Life <= 0){
                _winCondition.EnemyDestroyed();
            }           
        }
        if (other.CompareTag("EnemyProjectile"))
        {
            other.gameObject.SetActive(false);
            Deactivate();
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
