using System.Collections.Generic;
using UnityEngine;

public class SnoyBruse : MonoBehaviour
{
    [Header("SnoySled!!!!!!!!!!!!!!!!!!!!!!")]
    public CustomRenderTexture snoyHeigthMap;
    [Header("SnoySledUpdate!!!!!!!!!!!!!!!!!!!!!!")]
    public Material heigthMapUpdate;
    public LayerMask layerMask;

    public GameObject snoubord;

    private static readonly int DrawPosition = Shader.PropertyToID("_DrawPosition");
    private static readonly int DrawAngle = Shader.PropertyToID("_DrawAngle");
    void Start()
    {
        snoyHeigthMap.Initialize();
    }

    void Update()
    {
        
        Ray ray = new Ray(snoubord.transform.position+Vector3.forward,Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit,1f, layerMask))
        {

            Vector2 hitTextureCoord = hit.textureCoord;
            heigthMapUpdate.SetVector(DrawPosition, hitTextureCoord);
            heigthMapUpdate.SetFloat(DrawAngle, transform.rotation.eulerAngles.y * Mathf.Deg2Rad);


        }
    }
}
