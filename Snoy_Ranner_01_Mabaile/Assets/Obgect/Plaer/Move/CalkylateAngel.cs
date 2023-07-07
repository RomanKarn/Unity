using UnityEngine;

namespace Angele
{
    public static class CalkylateAngel
    {
        public static float AngelX(Transform obgect)
        {
            return Vector3.Angle(Vector3.forward, new Vector3(obgect.transform.forward.x, obgect.transform.forward.x, obgect.transform.forward.z));
        }
        public static float AngelY(Transform obgect)
        {
            return Vector3.Angle(Vector3.forward, new Vector3(obgect.transform.forward.x, obgect.transform.forward.x, obgect.transform.forward.z));
        }
        public static float AngelZ(Transform obgect)
        {
            return Vector3.Angle(Vector3.up, new Vector3(obgect.transform.right.x, obgect.transform.right.y, obgect.transform.right.z));
        }
    }
}