using UnityEngine;

namespace Loding
{
    public class LodingMashSnoubord : MonoBehaviour
    {
        [SerializeField] MeshFilter snoubordMesh;

        private void OnEnable()
        {
            LodingMesh();
        }
        public void LodingMesh()
        {
            if (PlayerPrefs.HasKey("Snoubord"))
            {
                var obgect = Resources.Load("Snoubord/" + PlayerPrefs.GetString("Snoubord") + "/SnoubordMesh", typeof(MeshFilter)) as MeshFilter;
                snoubordMesh.sharedMesh = obgect.sharedMesh;

            }
            else
            {
                var obgect = Resources.Load("Snoubord/Defalt/SnoubordMesh", typeof(MeshFilter)) as MeshFilter;
                snoubordMesh.sharedMesh = obgect.sharedMesh;
            }
        }
    }
}
