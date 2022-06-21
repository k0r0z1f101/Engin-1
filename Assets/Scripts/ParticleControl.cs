using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ParticleControl : MonoBehaviour
{
    private InputParticleControl pcControls;
    private ParticleSystem particleSystem;
    void Awake()
    {
        pcControls = new InputParticleControl();
        pcControls.ParticleControl.Play.performed += PlayParticle;
        pcControls.ParticleControl.Stop.performed += StopParticle;
        pcControls.ParticleControl.Pause.performed += PauseParticle;
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        pcControls.ParticleControl.Play.Enable();
        pcControls.ParticleControl.Stop.Enable();
        pcControls.ParticleControl.Pause.Enable();
    }
    
    private void PlayParticle(InputAction.CallbackContext value)
    {
        particleSystem.Play();
        Debug.Log("Play");
    }
    private void StopParticle(InputAction.CallbackContext value)
    {
        particleSystem.Stop();
        Debug.Log("Stop");
    }
    private void PauseParticle(InputAction.CallbackContext value)
    {
        particleSystem.Pause();
        Debug.Log("Pause");
    }
}
