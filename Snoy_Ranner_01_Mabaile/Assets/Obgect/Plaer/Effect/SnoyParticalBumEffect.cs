using UnityEngine;
using State;
public class SnoyParticalBumEffect : MonoBehaviour
{
    [SerializeField] private StateMashin plaer;
    [SerializeField] private Rigidbody plaerSpeed;
    [SerializeField] private ParticleSystem particalSnoy;
    void Start()
    {
        plaer.svitchStateMove += SnoyPasticalBum;
    }

    private void SnoyPasticalBum()
    {
        var emissSpeed = particalSnoy.main;
        emissSpeed.startSpeedMultiplier = plaerSpeed.velocity.magnitude/4;

        var emiss = particalSnoy.emission;
        ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[emiss.burstCount];
        emiss.GetBursts(bursts);

        var main = particalSnoy.main;
        bursts[0].minCount = bursts[0].maxCount = (short)(plaerSpeed.velocity.magnitude * 5);

        emiss.SetBursts(bursts);
        particalSnoy.Play();
    }
}
