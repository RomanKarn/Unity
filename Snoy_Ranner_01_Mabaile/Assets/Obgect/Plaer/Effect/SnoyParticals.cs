using State;
using UnityEngine;

public class SnoyParticals : MonoBehaviour
{
    [SerializeField] private StateMashin plaer;
    [SerializeField] private Rigidbody plaerSpeed;
    [SerializeField] private ParticleSystem particalSnoy;

    void Start()
    {
        plaer.svitchStateMove += EnablePastical;
        plaer.svitchStateFlay += DisablePastical;
    }

    void FixedUpdate()
    {
        var emissSpeed = particalSnoy.main;
        emissSpeed.startSpeedMultiplier = plaerSpeed.velocity.magnitude;
        var emiss = particalSnoy.emission;
        emiss.rateOverDistance = plaerSpeed.velocity.magnitude/5;
    }

    private void EnablePastical()
    {
        particalSnoy.Play();
    }
    private void DisablePastical()
    {
        particalSnoy.Stop();
    }
}
