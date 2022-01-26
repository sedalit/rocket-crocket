using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float energyBonus;
    void Update()
    {
        transform.Rotate(0, 2, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Rocket rocket))
        {
            Debug.Log("PowerUp");
            rocket.AddEnergy(energyBonus);
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        SoundManager.Instanse.PlayOneShot(SoundManager.Instanse.CollectPowerUp);
    }
}
