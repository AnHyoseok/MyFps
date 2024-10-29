using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
   public class FExitTriger : MonoBehaviour
   {
        //씬클리어
        #region Variables
        public GameObject exitUI;
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion

    
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(GameClear());
           
        }

        IEnumerator GameClear()
        {
            //클리어처리
            exitUI.SetActive(true);

            //배경음 종료
            AudioManager.Instance.StopBgm();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            yield return new WaitForSeconds(2f);
            //씬이동
            fader.FadeTo(loadToScene);
       
        }
    }
}