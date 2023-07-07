using UnityEngine;

namespace Loding
{
    public class LodingMashPlaer : MonoBehaviour
    {
        [SerializeField] SkinnedMeshRenderer plaerMesh;

        private void OnEnable()
        {
            LodingMesh();
        }
        public void LodingMesh()
        {
            if (PlayerPrefs.HasKey("Player"))
            {
                var obgect = Resources.Load("Player/" + PlayerPrefs.GetString("Player") + "/PlaerMesh", typeof(GameObject)) as GameObject;
                plaerMesh.sharedMesh = obgect.transform.Find("Mesh").GetComponent<SkinnedMeshRenderer>().sharedMesh;

            }
            else
            {
                var obgect = Resources.Load("Player/Defalt/PlaerMesh", typeof(GameObject)) as GameObject;
                plaerMesh.sharedMesh = obgect.transform.Find("Mesh").GetComponent<SkinnedMeshRenderer>().sharedMesh;
            }
        }
    }
}
