using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        private AudioManager audioManager;
        #endregion

        void Start()
        {
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

        }

        public void Credits()
        {

        }

        public void QuitGame()
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }
}