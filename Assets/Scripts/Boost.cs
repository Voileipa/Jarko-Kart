using UnityEngine;
using UnityEngine.InputSystem;
public class Boost : MonoBehaviour
{
    private Rigidbody rb;
    public float boostAmount;
    private bool isShifting = false;
    public ParticleSystem boostParticles;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            }
        }
        else
        {

            if (boostParticles.isPlaying)
            {
                boostParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }
    }
}

    void FixedUpdate()
    {
        if (isShifting && rb != null)
        {
            
            rb.AddForce(transform.forward * boostAmount, ForceMode.Force);
        }
        
    }
}
