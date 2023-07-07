using System.Collections;
using UnityEngine;

namespace Controller
{
    public class DisbleGroundRayController : MonoBehaviour
    {
        [SerializeField] private GameObject disableGroundPoint;
       // [SerializeField] private GameObject ecxplosuenEffect;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask colishionLaer;
        [SerializeField] private AudioSource explosionSound;

        [SerializeField] private float timerPlayEffect;
        private bool playEffect;
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                disableGroundPoint.SetActive(true);
                RaycastHit hit;
                if(!playEffect)
                {
                    playEffect = true;
            //        ecxplosuenEffect.SetActive(true);
                    explosionSound.pitch = Random.Range(0.9f, 1.2f);
                    explosionSound.Play();
                    StartCoroutine(EnablePartical());
                }
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f, colishionLaer))
                {
                    Vector3 target = hit.point;
                    disableGroundPoint.transform.position = target;
                }
            }
            else
            {
                disableGroundPoint.SetActive(false);
            }
        }

        IEnumerator EnablePartical()
        {
            yield return new WaitForSecondsRealtime(explosionSound.clip.length);
         //   ecxplosuenEffect.SetActive(false);
            playEffect = false;
        }
    }
}