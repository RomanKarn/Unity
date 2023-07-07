using UnityEngine;

public class ObgectDeletWater : MonoBehaviour
{
    [SerializeField] private AudioSource deletSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            collision.gameObject.SetActive(false);
            deletSound.pitch = Random.Range(0.9f, 1.1f);
            deletSound.PlayOneShot(deletSound.clip, 1F);
        }
    }
}
