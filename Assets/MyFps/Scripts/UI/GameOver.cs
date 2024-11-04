using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
       [SerializeField] private string loadToScene = "MainScene01";
        int sceneNumber = PlayerStats.Instance.SceneNumber;
        #endregion


        private void Start()
        {
            //마우스 커버 상태 설정
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //페이드인 효과
            fader.FromFade();
        }

        public void Retry()
        {
            fader.FadeTo(sceneNumber);
            Debug.Log("리트라이");
          
        }
        public void Menu()
        {
            Debug.Log("go to menu");
        }
    }

}