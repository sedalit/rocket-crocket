using UnityEngine;

public enum RocketState
{
    Idle = 1,
    Fly = 2,
    Destroyed = 3,
    Win = 4
}
public class Rocket : MonoBehaviour
{
    [Header("Main settings")]
    [SerializeField] private float linearSpeed;
    [SerializeField] private float angularSpeed;
    [SerializeField] private float startEnergy;
    [SerializeField] private float energyApply;

    [Header("Particle System")]
    [SerializeField] private GameObject[] launchSfx;
    [SerializeField] private GameObject explosionSfx;
    [SerializeField] private GameObject finishSfx;

    private RocketState rocketState;
    private Rigidbody rigidBody;
    private float currentEnergy;
    public float CurrentEnergy => currentEnergy;
    public float StartEnergy => startEnergy;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rocketState = RocketState.Idle;
        currentEnergy = startEnergy;
    }
    private void Update()
    {
        if (rocketState == RocketState.Fly)
        {
            Launch();
            ProceesRotationInput();
        }
    }

    private void ProceesRotationInput()
    {
        rigidBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * angularSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * angularSpeed * Time.deltaTime);
        }
        rigidBody.freezeRotation = false;
    }

    private void Launch()
    {
        if (currentEnergy > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rigidBody.AddRelativeForce(Vector3.up * linearSpeed * Time.deltaTime);
                currentEnergy -= energyApply * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartFlyParticles();
                if (SoundManager.Instanse.Source.isPlaying == false)
                {
                    SoundManager.Instanse.Play(SoundManager.Instanse.Fly);
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                StopFlyParticles();
                SoundManager.Instanse.Source.Pause();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (rocketState == RocketState.Fly)
        {
            if (collision.transform.CompareTag("Finish"))
            {
                rocketState = RocketState.Win;
                finishSfx.GetComponent<ParticleSystem>().Play();
                SoundManager.Instanse.Play(SoundManager.Instanse.FinishLevel);
                SceneController.Instance.Fader.gameObject.SetActive(true);
                SceneController.Instance.Invoke("FinishLevel", 2f);
            }
            else if (collision.transform.tag != "Friendly")
            {
                rocketState = RocketState.Destroyed;
                SceneController.Instance.Fader.gameObject.SetActive(true);
                SoundManager.Instanse.Play(SoundManager.Instanse.Death);
                explosionSfx.GetComponent<ParticleSystem>().Play();
                SceneController.Instance.Invoke("RestartLevel", 2.7f);
            }
        }
    }

    public void OnCountdownFinish()
    {
        rocketState = RocketState.Fly;
    }

    public void AddEnergy(float value)
    {
        currentEnergy += value;
    }

    private void StartFlyParticles()
    {
        if (rocketState != RocketState.Fly) return;
        foreach (var sfx in launchSfx)
        {
            var particleEffects = sfx.GetComponentsInChildren<ParticleSystem>();
            foreach (var particleEffect in particleEffects)
            {
                particleEffect.Play();
            }
        }
    }

    private void StopFlyParticles()
    {
        foreach (var sfx in launchSfx)
        {
            var particleEffects = sfx.GetComponentsInChildren<ParticleSystem>();
            foreach (var particleEffect in particleEffects)
            {
                particleEffect.Stop();
            }
        }
    }
}
