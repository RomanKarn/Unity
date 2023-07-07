using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private AudioSource teleportSound;
    [SerializeField] private Transform exitTeleport;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            collision.transform.position = new Vector3(exitTeleport.position.x + Random.Range(-exitTeleport.localScale.x, exitTeleport.localScale.x), exitTeleport.position.y);
            teleportSound.pitch = Random.Range(0.9f, 1.1f);
            teleportSound.PlayOneShot(teleportSound.clip, 1F);
        }
    }
}
