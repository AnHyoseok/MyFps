using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        private AudioManager audioManager;

        public GameObject loadGameScene;
        public GameObject mainMenuUI;
        public GameObject optionUI;
        public GameObject creditUI;

        //Audio
        public AudioMixer audioMixer;
        public Slider bgmSlider;
        public Slider sfxSlider;

        //저장되어 있는 씬 번호
        private int sceneNumber;
        #endregion

        private void Start()
        {
            //게임 데이터 초기화
            InitGameData();

            
            Debug.Log($"저장된 sceneNumber:{PlayerStats.Instance.SceneNumber}");

            //저장된 씬이 있으면
            if (sceneNumber > 0)
            {
                loadGameScene.SetActive(true);
            }

            //씬 페이드인 효과
            fader.FromFade();

            //참조
            audioManager = AudioManager.Instance;

            //Bgm 플레이
            audioManager.PlayBgm("MenuBgm");
        }

    

        private void InitGameData()
        {
            //게임설정값, 저장데이터, 저장된 옵션값 불러오기
            LoadOptions();


            //게임 플레이 데이터 로드
            PlayData playData = SaveLoad.LoadData();
            PlayerStats.Instance.PlayerStatInit(playData);
            sceneNumber = PlayerStats.Instance.SceneNumber;// 추가
        }

        public void NewGame()
        {

            //게임 데이터 초기화
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");

            //PlayerPrefs.DeleteKey("PlayScene");

            fader.FadeTo(loadToScene);
        }

        public void LoadGame()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");

            Debug.Log($"GOto LoadGame{sceneNumber}번 씬");
            fader.FadeTo(sceneNumber);
        }

        public void Options()
        {
            audioManager.Play("MenuButton");

            ShowOptions();
        }

        public void Credits()
        {
            ShowCredit();
        }

        public void QuitGame()
        {
            //Cheating
            PlayerPrefs.DeleteAll();

            Debug.Log("Quit Game");
            Application.Quit();
        }

        private void ShowOptions()
        {
            audioManager.Play("MenuButton");

            mainMenuUI.SetActive(false);
            optionUI.SetActive(true);
        }

        public void HideOptions()
        {
            //옵션값 저장하기
            SaveOptions();

            optionUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }

        //AudioMixer Bgm -40~0
        public void SetBgmVolume(float value)
        {
            audioMixer.SetFloat("BgmVolume", value);
        }

        //AudioMixer Sfx -40~0
        public void SetSfxVolume(float value)
        {
            audioMixer.SetFloat("SfxVolume", value);
        }

        //옵션값 저장하기
        private void SaveOptions()
        {
            PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
            PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
        }

        //옵션값 로드하기
        private void LoadOptions()
        {
            //배경음 볼륨
            float bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 0);
            //Debug.Log($"bgmVolume: {bgmVolume}");
            SetBgmVolume(bgmVolume);        //사운드 볼륨 조절
            bgmSlider.value = bgmVolume;    //UI 셋팅

            //효과음 볼륨
            float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 0);
            //Debug.Log($"sfxVolume: {sfxVolume}");
            SetSfxVolume(sfxVolume);        //사운드 볼륨 조절
            sfxSlider.value = sfxVolume;    //UI 셋팅

            //기타...
        }

        private void ShowCredit()
        {
            mainMenuUI.SetActive(false);
            creditUI.SetActive(true);
        }


    }
}