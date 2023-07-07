using UnityEngine;

public class InitGameStartPoint : MonoBehaviour
{
    [SerializeField] private Questions questionInit;
    [SerializeField] private Plaer plaerInit;
    void Start()
    {
        questionInit.Init();
        plaerInit.Init();
    }

}
