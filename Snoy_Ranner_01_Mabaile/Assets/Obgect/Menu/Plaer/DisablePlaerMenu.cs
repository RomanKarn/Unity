using UnityEngine;

public class DisablePlaerMenu : MonoBehaviour
{
    [SerializeField] private GameObject plaer;

    public void DisableMenuPlaerAndEnablePlaer()
    {
        plaer.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
