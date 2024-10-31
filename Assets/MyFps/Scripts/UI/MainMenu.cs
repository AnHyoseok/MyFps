using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        public GameObject mainMenuUI;
        public GameObject OptionUI;
        public GameObject CreditUI;

        [SerializeField] private string loadToScene = "MainScene01";
        
        private AudioManager audioManager;
        
        //Audio
        public AudioMixer audioMixer;
        public Slider bgmSlider;
        public Slider sfxSlider;
        #endregion

        void Start()
        {
            //게임 저장데이터,저장된 옵션값 불러오기
            LoadOption();

            //씬페이드 효과
            fader.FromFade();

            //참조
            audioManager = AudioManager.Instance;

            //bgm 플레이
            audioManager.PlayBgm("MenuBgm");
        }

        public void NewGame()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");
            fader.FadeTo(loadToScene);
        }

        public void LoadGame()
        {

        }

        public void Options()
        {
        
            audioManager.Play("MenuButton");
            mainMenuUI.SetActive(false);
            OptionUI.SetActive(true);
        }

        public void Credits()
        {
            ShowCredit();
        }

        public void QuitGame()
        {

            
           
            Debug.Log("Quit Game");
            Application.Quit();
        }

       public void HideOptions()
        {
            SaveOptions();
            audioManager.Play("MenuButton");
            mainMenuUI.SetActive(true );
            OptionUI.SetActive(false);
        }

        //AudioMix BGM - 40~ 0
        public void SetBgmVolume(float value)
        {
            audioMixer.SetFloat("BGM",value);
        } 
        //AudioMix SFX - 40~ 0
        public void SetSfxVolume(float value)
        {
            audioMixer.SetFloat("SFX",value);
        }

        //옵션값 저장하기
        private void SaveOptions()
        {
            PlayerPrefs.SetFloat("BGM",bgmSlider.value);
            PlayerPrefs.SetFloat("SFX", sfxSlider.value);
        }
        //옵션값 로드하기
        private void LoadOption()
        {
            //배경음 볼륨
            float bgmVolume = PlayerPrefs.GetFloat("BGM", 0);
            SetBgmVolume(bgmVolume);    //사운드 볼륨 조절
            bgmSlider.value = bgmVolume;
            //교과음 볼륨
            float sfxVolume = PlayerPrefs.GetFloat("SFX",0);
            SetSfxVolume(sfxVolume);
            sfxSlider.value = sfxVolume;

        }

        private void ShowCredit()
        {
            mainMenuUI.SetActive(false);
            CreditUI.SetActive(true);
        }

        
       
    }
}