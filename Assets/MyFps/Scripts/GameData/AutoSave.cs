using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace MyFps
{
    //플레이씬이 시작하면 자동으로 게임 데이터 저장
   public class AutoSave : MonoBehaviour
   {
        #region Variables

        #endregion

        private void Start()
        {
            //씬번호 저장
            AutoSaveData();
        }

        void AutoSaveData()
        {
            //현재 씬 저장
            
            int sceneNumber = PlayerStats.Instance.SceneNumber;
            Debug.Log($"데이터로드 씬번호{sceneNumber}");
            int playScene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log($"데이터저장 씬번호{playScene}");
            
            //새로 플레이 하는 씬이냐?
            if(playScene > sceneNumber)
            {
                //PlayerPrefs.SetInt("PlayScene", playScene);
                PlayerStats.Instance.SceneNumber = playScene;
                SaveLoad.SaveData();
            }
          
           
        }
    }
}