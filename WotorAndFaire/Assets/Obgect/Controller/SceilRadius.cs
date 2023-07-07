using UnityEngine;
using UnityEngine.UI;

public class SceilRadius : MonoBehaviour, IInit
{
    [SerializeField] private GameObject disablePoint;
    [SerializeField] private Slider sliderRadiys;

    public bool InitStart()
    {
        sliderRadiys.onValueChanged.AddListener(ChangeRadius);
        return true;
    }
    private void ChangeRadius(float amount)
    {
        disablePoint.transform.localScale= new Vector3(amount, amount, amount);
    }
}
