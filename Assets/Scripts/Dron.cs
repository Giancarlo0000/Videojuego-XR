using System.Collections;
using UnityEngine;

public class Dron : MonoBehaviour
{
    [SerializeField] private string MissileTag = "Missile";
    [SerializeField] private float BulletFrecuency = 3f;
    [SerializeField] public float Life = 10f;
    [SerializeField] private Transform ShootingPointA;
    [SerializeField] private Transform ShootingPointB;
    [SerializeField] private bool CanMove = false;
    [SerializeField] private float PatrolTime = 5f;

    private GameObject _player;
    private bool _isShooting = false;
    private ProjectilesSpawner _spawner;
    private float _currentAngel;
    private float _patrolSpeed;

    public void Initialize(ProjectilesSpawner spawner, float patrolSpeed)
    {
        Life = 10f;
        if (_player == null)
        {
            _player = GameObject.FindWithTag("Player");
        }

        if (_player != null)
        {
            LookAtPlayer();
        }

        _spawner = spawner;
        _patrolSpeed = patrolSpeed;

        if (_spawner != null)
        {
            _currentAngel = Random.Range(0f, 2 * Mathf.PI);
            SetInitialPosition();
        }

        if (CanMove)
        {
            StartCoroutine(PatrolAndAttack());
        }
        else
        {
            LookAtPlayer();
            StartShooting();
        }
    }

    private void Start() 
    {
        _player = GameObject.FindWithTag("Player");

        if (_player != null)
        {
            LookAtPlayer();
        }
    }

    private void SetInitialPosition()
    {
        Vector3 center = _spawner.transform.position;
        Vector3 patrolPosition = new Vector3(
            center.x + _spawner.Radius * Mathf.Cos(_currentAngel),
            transform.position.y,
            center.z + _spawner.Radius * Mathf.Sin(_currentAngel)
        );
        transform.position = patrolPosition;
    }

    private IEnumerator PatrolAndAttack()
    {
        StopShooting();
        float startTime = Time.time;
        while (Time.time - startTime < PatrolTime)
        {
            PatrolPerimeter();
            yield return null;
        }

        LookAtPlayer();
        StartShooting();
    }

    private void PatrolPerimeter()
    {
        if (_spawner == null)
        {
            Debug.LogError("Error en PatrolPerimeter, falta spawner");
            return;
        }

        Vector3 center = _spawner.transform.position;

        _currentAngel += _patrolSpeed * Time.deltaTime;
        if (_currentAngel > 2 * Mathf.PI) _currentAngel -= 2 * Mathf.PI;

        Vector3 patrolPosition = new Vector3(
            center.x + _spawner.Radius * Mathf.Cos(_currentAngel),
            transform.position.y,
            center.z + _spawner.Radius * Mathf.Sin(_currentAngel)
        );

        transform.position = patrolPosition;

        if (_player != null)
        {
            gameObject.transform.LookAt(_player.transform.position);
            Vector3 rotation = gameObject.transform.eulerAngles;
            rotation.y += 90f;
            gameObject.transform.eulerAngles = rotation;
        }
        else
        {
            Debug.LogWarning("No se ecunetra al jugador");
        }
        
    }

    private void LookAtPlayer(){
        gameObject.transform.LookAt(_player.transform.position);
    }

    private void InstantiateProjectiles(){
        if (ShootingPointA != null){
            GameObject projectileA = ObjectPooling.Instance.SpawnFromPool(MissileTag, ShootingPointA.position, Quaternion.identity);
            if (projectileA != null) projectileA.GetComponent<Missile>().Initialize(_player);
        }
        if (ShootingPointB != null){
            GameObject projectileB = ObjectPooling.Instance.SpawnFromPool(MissileTag, ShootingPointB.position, Quaternion.identity);
            if (projectileB != null) projectileB.GetComponent<Missile>().Initialize(_player);
        }
    }

    private void StartShooting()
    {
        if (!_isShooting)
        {
            _isShooting = true;
            InvokeRepeating(nameof(InstantiateProjectiles), BulletFrecuency, BulletFrecuency);
        }
    }

    private void StopShooting()
    {
        _isShooting = false;
        CancelInvoke(nameof(InstantiateProjectiles));
    }

    public void ResetDron()
    {
        Life = 10f;
        if (_player == null)
        {
            _player = GameObject.FindWithTag("Player");
        }

        if (_player != null)
        {
            LookAtPlayer();
        }

        if (CanMove)
        {
            StartCoroutine(PatrolAndAttack());
        }
        else
        {
            StartShooting();
        }
    }

    public void TakeDamage(float damage)
    {
        Life -= damage;
        if (Life <= 0)
        {
            StopShooting();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float damateToPlayer = Life / 2f;
            GameManager.Instance.healthPlayer -= damateToPlayer;
            gameObject.SetActive(false);
        }
    }
}
