using System;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private GameObject _player = null;
    
    private void Start() 
    {
        _player = GameObject.FindWithTag("Player");
        if (_player == null){
            Debug.Log("No se encontró al jugador");
        }
        else{
            Debug.Log("Se encontró al jugador");
        }
    }

    private void Update() 
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        LookAtPlayer();
    }

    private void AutoDestroy(){
        Destroy(gameObject);
    }

    private void LookAtPlayer(){
        gameObject.transform.LookAt(_player.transform.position);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            Debug.Log("Entró");
            print("Prueba 2");
            AutoDestroy();
        }
    }
}
