using System;
using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private GameObject _player = null;
    private Coroutine _rotationCoroutine;

    public void Initialize(GameObject player)
    {
        _player = player;
        if (_player == null)
        {
            Debug.Log("No se encontró al jugador");
        }
        else
        {
            Debug.Log("Se encontró al jugador");
        }
    }

    private void OnEnable()
    {
        Invoke(nameof(AutoDeactivate), 5f);
        _rotationCoroutine = StartCoroutine(RotateMissile());
        
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(AutoDeactivate));
        if (_rotationCoroutine != null)
        {
            StopCoroutine(_rotationCoroutine);
            _rotationCoroutine = null;
        }
    }

    private void Update() 
    {
        _player = GameObject.FindWithTag("Player");
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        //LookAtPlayer();
    }

    private void LookAtPlayer(){
        gameObject.transform.LookAt(_player.transform.position);
    }

    private IEnumerator RotateMissile()
    {
        while (true)
        {
            transform.Rotate(new Vector3(1f, 0.45f, 1.2f), 200 * Time.deltaTime);
            yield return null;
        }
    }

    private void AutoDeactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            GameManager.Instance.healthPlayer -= 10f;
            print(GameManager.Instance.healthPlayer);
            gameObject.SetActive(false);
        }
    }
}
