using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObgetsWall : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.activeInHierarchy)
            collision.gameObject.SetActive(false);
    }
}
