using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody _rigidbody;
    public ParticleSystem[] WheelParticle;
    public float RaycastDistance = 2f;
    public float ActivationSpeed;
    public float CarVelocity = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CarVelocity = _rigidbody.velocity.magnitude;

        RaycastHit hit;

        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, RaycastDistance);

        foreach(var particle in WheelParticle)
        {
            if (isGrounded && _rigidbody.velocity.magnitude > ActivationSpeed)
            {
                if (!particle.isPlaying)
                {
                    particle.Play();
                }
            }
            else
            {
                if (particle.isPlaying)
                {
                    particle.Stop();
                }
            }
        }
    }
}
