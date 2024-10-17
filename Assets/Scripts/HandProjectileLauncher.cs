using UnityEngine;
public class HandProjectileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject EnergyBall;
    [SerializeField] private Transform SpawnPointRightHand;
    [SerializeField] private Transform SpawnPointLeftHand;

    private bool _isRightTriggerPressed = false;
    private bool _isLeftTriggerPressed = false;
    private void Update()
    {
        float rightTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        if (rightTriggerValue > 0.1f && !_isRightTriggerPressed)
        {
            Shoot(SpawnPointRightHand);
            _isRightTriggerPressed = true;
        }
        else if(rightTriggerValue <= 0.1f)
        {
            _isRightTriggerPressed = false;
        }

        float leftTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);

        if (leftTriggerValue > 0.1f && !_isLeftTriggerPressed)
        {
            Shoot(SpawnPointLeftHand);
            _isLeftTriggerPressed = true;
        }
        else if(leftTriggerValue <= 0.1f)
        {
            _isLeftTriggerPressed = false;
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
