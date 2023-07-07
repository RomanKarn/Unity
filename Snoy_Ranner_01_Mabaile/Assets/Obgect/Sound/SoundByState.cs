using State;
using UnityEngine;

public class SoundByState : MonoBehaviour
{
    [SerializeField] private StateMashin plaer;
    [SerializeField] private AudioSource playLoopGround;
    [SerializeField] private AudioSource playLoopFaly;
    [SerializeField] private AudioSource playOnGround;
    [SerializeField] private AudioSource playOnFaly;
    void Start()
    {
        plaer.svitchStateMove += SoundOnGraund;
        plaer.svitchStateFlay += SoundOnFlay;
    }
    private void SoundOnGraund()
    {
        playLoopFaly.Stop();
        playLoopGround.Play();
        playOnGround.Play();
    }
    private void SoundOnFlay()
    {
        playLoopGround.Stop();
        playOnFaly.Play();
        playLoopFaly.Play();
    }
}
