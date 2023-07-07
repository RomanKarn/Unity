using UnityEngine;
using UnityEngine.VFX;

public class OnTrigetGroundDisable : MonoBehaviour
{
    [SerializeField] private VisualEffect particalGround;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if ((collision.tag == "Ground")||(collision.tag == "Water"))
        {
            collision.gameObject.SetActive(false);
            particalGround.Play();
            particalGround.SetFloat("Radius",0.8f);
        }
    }
}
