using UnityEngine;

public class HandProjectileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject EnergyBall;
    [SerializeField] private Transform SpawnPointRightHand;
    [SerializeField] private Transform SpawnPointLeftHand;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Shoot(SpawnPointRightHand);
        }

        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            Shoot(SpawnPointLeftHand);
        }
    }

    private void Shoot(Transform spawnPoint)
    {
        GameObject projectile = Instantiate(EnergyBall, spawnPoint.position, Quaternion.identity);

        Vector3 direction = spawnPoint.forward;

        Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            rigidbody.velocity = direction * 10f;
        }
    }
}
