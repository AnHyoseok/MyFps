using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
using System.Linq.Expressions;
namespace MyFps
{
    public class Intro : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        public Animator cameraAnim;
        [SerializeField] private string loadToScene = "MainScene01";
        public GameObject houseLight;
        public GameObject introUI;
        public CinemachineDollyCart cart;
        public AudioManager audioManager;
        [SerializeField] private int wayPointIndex; //이동 목표 지점 인덱스
        private bool[] isArrive;
        #endregion

        //0.08
        private void Start()
        {
            //초기화

            cart.m_Speed = 0f;
            wayPointIndex = 0;
            isArrive = new bool[6];
            StartCoroutine(StartIntro());
        }

        private void Update()
        {
            if (cart.m_Position > wayPointIndex-1 && isArrive[wayPointIndex] == false)
            {
                //애니메이션 실행


                // 집 도착 연출
                if (wayPointIndex == 5)
                {
                    StartCoroutine(EndIntro());
                }
                else
                {
                    StartCoroutine(StayIntro());
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                fader.FadeTo(loadToScene);
                audioManager.StopBgm();
            }
        }

        IEnumerator StartIntro()
        {
            isArrive[wayPointIndex] = true;
            yield return new WaitForSeconds(1f);
            fader.FromFade();
            AudioManager.Instance.PlayBgm("MenuBgm");
            cameraAnim.SetTrigger("ArroundTrigger");


            cart.m_Speed = 0.08f;

            wayPointIndex++;


        }

        IEnumerator StayIntro()
        {
            isArrive[wayPointIndex] = true;
            cart.m_Speed = 0f;

            Debug.Log($"{wayPointIndex}번 지점 도착");

            yield return new WaitForSeconds(1f);
            //카메라 애니메이션
            cameraAnim.SetTrigger("ArroundTrigger");

            int nowIndex = wayPointIndex; //현재 위치 하고 있는 웨이포인트 인덱스
            switch (nowIndex)
            {
                case 1:
                    introUI.SetActive(true); break;
                case 2:
                    introUI.SetActive(false); break;
                case 4:
                    houseLight.SetActive(true);
                    break;

            }

            yield return new WaitForSeconds(3f);

            //출발
            cart.m_Speed = 0.08f;

            wayPointIndex++;
        }

        IEnumerator EndIntro()
        {
            isArrive[wayPointIndex] = true;
            cart.m_Speed = 0f;
            Debug.Log("마지막지점 도착");

            yield return new WaitForSeconds(1.5f);

            houseLight.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            audioManager.StopBgm();
            fader.FadeTo(loadToScene);
        }

    }
}