using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ParticleControl : MonoBehaviour
{
    private InputParticleControl pcControls;
    private ParticleSystem particleSystem;
    private Coroutine deactivateCoroutine;
    void Awake()
    {
        pcControls = new InputParticleControl();
        pcControls.ParticleControl.Play.performed += PlayParticle;
        pcControls.ParticleControl.Stop.performed += StopParticle;
        pcControls.ParticleControl.Pause.performed += PauseParticle;
        pcControls.ParticleControl.Deactivate.performed += DeactivatePS;
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        pcControls.ParticleControl.Play.Enable();
        pcControls.ParticleControl.Stop.Enable();
        pcControls.ParticleControl.Pause.Enable();
        pcControls.ParticleControl.Deactivate.Enable();
        pcControls.ParticleControl.Deactivate.Enable();
    }
    
    private void PlayParticle(InputAction.CallbackContext value)
    {
        particleSystem.Play();
        DeactivatePS();
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

    private void OnDisable()
    {
        pcControls.ParticleControl.Play.Disable();
        pcControls.ParticleControl.Stop.Disable();
        pcControls.ParticleControl.Pause.Disable();
        pcControls.ParticleControl.Deactivate.Disable();
    }
    
    private void DeactivatePS(InputAction.CallbackContext value)
    {
        if(deactivateCoroutine == null)
        {
            deactivateCoroutine = StartCoroutine(WaitForParticle());
            Debug.Log("waiting for deactivation");
        }
    }
    
    private void DeactivatePS()
    {
        print(deactivateCoroutine);
        if (deactivateCoroutine == null)
        {
            deactivateCoroutine = StartCoroutine(WaitForParticle());
            Debug.Log("waiting for deactivation");
        }
    }

    private void TestEvent2(int ahahahah, string hihihihi)
    {
        
    }
    
    private void TestEvent(int ahaha)
    {
        print("hahaha: " + ahaha);
    }

    IEnumerator WaitForParticle()
    {
        while(particleSystem.IsAlive())
        {
            Debug.Log("Checking particle is alive");
            yield return null;
        }
        
        Debug.Log("Deactivation");
        gameObject.SetActive(false);
        deactivateCoroutine = null;
        //Return to pool

    }
}
