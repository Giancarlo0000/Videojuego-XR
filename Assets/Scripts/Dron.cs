using UnityEngine;

public class Dron : MonoBehaviour
{
    [SerializeField] private GameObject Projectile = null;
    [SerializeField] private float BulletFrecuency = 3f;
    private WinCondition _winCondition;
    private GameObject _player;

    private void Awake()
    {
        _winCondition = FindObjectOfType<WinCondition>();
    }

    private void Start() 
    {
        _player = GameObject.FindWithTag("Player");
        LookAtPlayer();
        InvokeRepeating("InstantiateProjectiles", BulletFrecuency, BulletFrecuency);
    }

    private void LookAtPlayer(){
        gameObject.transform.LookAt(_player.transform.position);
    }

    private void InstantiateProjectiles(){
        Instantiate(Projectile, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        _winCondition.EnemyDestroyed();
    }
}
