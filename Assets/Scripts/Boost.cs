using UnityEngine;
using UnityEngine.InputSystem;

public class Boost : MonoBehaviour
{
    public Rigidbody rb;
    public float boostAmount;
    private bool isShifting = false;
    public ParticleSystem boostParticles;
    public ParticleSystem boostParticles2;
    void Start()
    {
        
    }
    void Update()
{
    if (Keyboard.current == null) return;

    isShifting = Keyboard.current.leftShiftKey.isPressed;

    if (boostParticles != null)
    {
        if (isShifting)
        {
            if (!boostParticles.isPlaying)
            {
                boostParticles.Play(true);
                boostParticles2.Play(true);
            }
        }
        else
        {

            if (boostParticles.isPlaying)
            {
                boostParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                boostParticles2.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }
    }
}

    void FixedUpdate()
    {
        if (isShifting && rb != null)
        {
            
            rb.AddForce(transform.forward * boostAmount, ForceMode.Acceleration);
        }
        
    }
}
