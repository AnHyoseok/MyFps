using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //퍼즐 아이템 흭득 여부
    public enum PuzzleKey
    {
        ROOM01_KEY,
        LeftEye,
        RightEye,
        MAX_KEY,        //퍼즐 아이템 갯수
    }
    //플레이어의 속성값을 관리하는(싱글톤, DontDestroy) 클래스 .. ammo
    public class PlayerStats : PersistentSingleton<PlayerStats>
    {
        #region Variables
        //저장된 SceneNumber
        private int sceneNumber;
        public int SceneNumber
        {
            get { return sceneNumber; }
            set { sceneNumber = value; }
        }

        //지금 플레이 하고 있는 신 넘버
        private int nowSceneNumber;
        public int NowSceneNumber
        {
            get { return nowSceneNumber; }
            set { nowSceneNumber = value; }
        }

        //탄환 갯수
        [SerializeField] private int ammoCount;

        public int AmmoCount
        {
            get { return ammoCount; }
            set { ammoCount = value; }
        }

        //무기 소지 여부 
        private bool hasGun;
        public bool HasGun
        {
            get { return hasGun; }
             private set { hasGun = value; }
        }

        //게임 퍼즐 아이템 키
        private bool[] puzzleKeys;

        #endregion

        private void Start()
        {
            //속성값/Data 초기화
            AmmoCount = 0;
            puzzleKeys = new bool[(int)PuzzleKey.MAX_KEY];
        }

        public void PlayerStatInit(PlayData playData)
        {
            if(playData != null)
            {
                SceneNumber = playData.sceneNumber;
                AmmoCount = playData.ammoCount;
                hasGun = playData.hasGun;
            }
            else //저장된 데이터가 없으면
            {
                SceneNumber = 0;
                AmmoCount = 0;
                hasGun = false;
            }
        }
        public void AddAmmo(int amount)
        {
            AmmoCount += amount;
        }

        public bool UseAmmo(int amount)
        {
            //소지 갯수 체크
            if (AmmoCount < amount)
            {
                Debug.Log("You need to reload!!!!");
                return false;   //사용량보다 부족하다
            }


            AmmoCount -= amount;

            return true;
        }

        //퍼즐아이템 흭득
        public void AccuirePuzzleItem(PuzzleKey key)
        {
            puzzleKeys[(int)key] = true;
        }

        //퍼즐아이템 소지여부
        public bool HasPuzzleItem(PuzzleKey key)
        {
            return puzzleKeys[(int)key];
        }

        //무기 흭득 셋팅
        public void SetHasGun(bool value)
        {
            HasGun = value;

        }
    }

}