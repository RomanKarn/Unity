using UnityEngine;
[CreateAssetMenu(fileName = "Charapters", menuName = "CharaptersData/EnemiData", order = 51)]
public class EnemiCharapterData : CharapterBaseData
{
    [SerializeField] private int point;

    public int GetPoint { get { return point; } }

}
