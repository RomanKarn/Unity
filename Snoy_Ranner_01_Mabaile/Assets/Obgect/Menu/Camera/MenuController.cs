using System.Collections.Generic;
using UnityEngine;
using Loding;
using UnityEngine.Audio;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        
        [SerializeField] private GameObject controllerAndtoid;
        
        [SerializeField] private Transform globalTargetLook;
        [SerializeField] private Transform targenMainMenu;
        [SerializeField] private Transform targenShopMenuMenu;
        [SerializeField] private Transform targenHelperMenu;
        [SerializeField] private MoveTargetByCamera moveCamera;

        [SerializeField] private Transform muveCameraTransform;
        [SerializeField] private MuveCamera muveCamera;
        [SerializeField] private Animator plaerMenu;

        [SerializeField] private LodingMashSnoubord snoybordResetMesh;
        [SerializeField] private List<string> snoybordSelect;
        private int nowSelectSnoybord;

        [SerializeField] private LodingMashPlaer plaerResetMesh;
        [SerializeField] private List<string> plaerSelect;
        private int nowSelectPlaer;

        [SerializeField] private AudioSource scoundClic;
        [SerializeField] private AudioMixerGroup mainMixer;
        private int enableSound;
        private int enableMusic;

        public LayerMask layer;
        private bool androindPlay;
        private void Start()
        {
            androindPlay = true;
            FoindIDSnoubord();
            FoindIDPlaer();
            LodingSoundAndMusic();
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f, layer))
                {
                    EventEnableMenu(hit.transform.name);
                    scoundClic.pitch = Random.Range(0.4f, 0.5f);
                    scoundClic.Play();
                }

            }
            muveCameraTransform.LookAt(globalTargetLook);
        }

        private void EventEnableMenu(string nameEvent)
        {
            switch (nameEvent)
            {
                case "Start":
                    StartGame();
                    break;
                case "Shop":
                    MenuShop();
                    break;
                case "HelpProgrammer":
                    MenuHelpProgrammer();
                    break;
                case "BeakMainMenu":
                    BeakMainMenu();
                    break;
                case "LeftSelectSnoubord":
                    LeftSelectSnoubord();
                    break;
                case "RigthSelectSnoubord":
                    RigthSelectSnoubord();
                    break;
                case "LeftSelectPlaer":
                    LeftSelectPlaer();
                    break;
                case "RigthSelectPlaer":
                    RigthSelectPlaer();
                    break;
                case "Sound":
                    SvitchSound();
                    break;
                case "Music":
                    SvitchMusic();
                    break;
                case "Exit":
                    Exit();
                    break;
                case "Busty":
                    Busty();
                    break;
            }

        }
            
        private void StartGame()
        {
            muveCamera.enabled = true;
            plaerMenu.SetBool("StartGame", true);
            this.GetComponent<MenuController>().enabled = false;
            muveCameraTransform.Rotate(45, 0, 0);
            if(androindPlay)
                controllerAndtoid.SetActive(true);
        }
        private void MenuShop()
        {
            moveCamera.SelectTarget(targenShopMenuMenu);
        }
        private void MenuHelpProgrammer()
        {
            moveCamera.SelectTarget(targenHelperMenu);
        }

        private void BeakMainMenu()
        {
            moveCamera.SelectTarget(targenMainMenu);
        }

        private void FoindIDSnoubord()
        {
            if (PlayerPrefs.HasKey("Snoubord"))
            {
                for (int i = 0; snoybordSelect.Count > i; i++)
                {
                    if (PlayerPrefs.GetString("Snoubord") == snoybordSelect[i])
                    {
                        nowSelectSnoybord = i;
                        break;
                    }
                }
            }
            else
            {
                nowSelectSnoybord = 0;
            }
        }
        private void FoindIDPlaer()
        {
            if (PlayerPrefs.HasKey("Player"))
            {
                for (int i = 0; plaerSelect.Count > i; i++)
                {
                    if (PlayerPrefs.GetString("Player") == plaerSelect[i])
                    {
                        nowSelectPlaer = i;
                        break;
                    }
                }
            }
            else
            {
                nowSelectPlaer = 0;
            }
        }
        private void LeftSelectSnoubord()
        {
            nowSelectSnoybord--;
            if (nowSelectSnoybord < 0)
            {
                nowSelectSnoybord = snoybordSelect.Count - 1;
            }
            PlayerPrefs.SetString("Snoubord", snoybordSelect[nowSelectSnoybord]);
            snoybordResetMesh.LodingMesh();
        }
        private void RigthSelectSnoubord()
        {
            nowSelectSnoybord++;
            if (nowSelectSnoybord > snoybordSelect.Count - 1)
            {
                nowSelectSnoybord = 0;
            }
            PlayerPrefs.SetString("Snoubord", snoybordSelect[nowSelectSnoybord]);
            snoybordResetMesh.LodingMesh();
        }

        private void LeftSelectPlaer()
        {
            nowSelectPlaer--;
            if (nowSelectPlaer < 0)
            {
                nowSelectPlaer = plaerSelect.Count - 1;
            }
            PlayerPrefs.SetString("Player", plaerSelect[nowSelectPlaer]);
            plaerResetMesh.LodingMesh();
        }
        private void RigthSelectPlaer()
        {
            nowSelectPlaer++;
            if (nowSelectPlaer > plaerSelect.Count - 1)
            {
                nowSelectPlaer = 0;
            }
            PlayerPrefs.SetString("Player", plaerSelect[nowSelectPlaer]);
            plaerResetMesh.LodingMesh();
        }
    
        private void SvitchSound()
        {
            if (enableSound==1)
            {
                mainMixer.audioMixer.SetFloat("Sound", 0f);
                enableSound = 0;
            }
            else 
            {
                mainMixer.audioMixer.SetFloat("Sound", -80f);
                enableSound = 1;
            }
            PlayerPrefs.SetInt("Sound", enableSound);
        }
        private void SvitchMusic()
        {
            if (enableMusic==1)
            {
                mainMixer.audioMixer.SetFloat("Music", 0f);
                enableMusic= 0;
            }
            else
            {
                mainMixer.audioMixer.SetFloat("Music", -80f);
                enableMusic= 1;
            }
            PlayerPrefs.SetInt("Music", enableMusic);
        }
    
        private void LodingSoundAndMusic()
        {
            if(PlayerPrefs.HasKey("Sound"))
            {
                enableSound = PlayerPrefs.GetInt("Sound");
            }
            else
            {
                enableSound = 1;
            }
            if (PlayerPrefs.HasKey("Music"))
            {
                enableMusic = PlayerPrefs.GetInt("Music");
            }
            else
            {
                enableMusic = 1;
            }
            
            if (enableSound != 1)
            {
                mainMixer.audioMixer.SetFloat("Sound", 0f);
            }
            else
            {
                mainMixer.audioMixer.SetFloat("Sound", -80f);
            }

            if (enableMusic != 1)
            {
                mainMixer.audioMixer.SetFloat("Music", 0f);
            }
            else
            {
                mainMixer.audioMixer.SetFloat("Music", -80f);
            }
            PlayerPrefs.SetInt("Sound", enableSound);
            PlayerPrefs.SetInt("Music", enableMusic);
        }
    
        private void Exit()
        {
            Application.Quit();
        }
        private void Busty()
        {
            Application.OpenURL("https://boosty.to/lazybee");
        }
    }
}