using UnityEngine;

public class Spavner : MonoBehaviour
{
    public GameObject platform;
    public Transform plaerPosishion;

    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private bool enablePlasform=true;
    void Start()
    {
        
    }
    void Update()
    {
        if((Vector3.Distance(endPoint.position, plaerPosishion.position)<20)&&(enablePlasform))
        {
          this.enablePlasform = false;
          GameObject newPlatform =  Instantiate(platform, endPoint.position + this.transform.position - this.startPoint.position,this.transform.rotation);
        //  newPlatform.transform.position = endPoint.position + newPlatform.transform.position- newPlatform.GetComponent<Spavner>().startPoint.position;
          newPlatform.GetComponent<Spavner>().plaerPosishion= this.plaerPosishion;
            newPlatform.GetComponent<Spavner>().enablePlasform = true;
        }
    }
}
