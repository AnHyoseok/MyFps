using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
    //파일에 저장할 게임 플레이 데이터 목록
    [Serializable]
    public class PlayData 
   {
        public int sceneNumber;
        public int ammoCount;
        public bool hasGun;

        //....health 등등

        //생성자
        public PlayData()
        {
            sceneNumber = PlayerStats.Instance.SceneNumber;
            ammoCount = PlayerStats.Instance.AmmoCount;
            hasGun = PlayerStats.Instance.HasGun;
        }
   }
}