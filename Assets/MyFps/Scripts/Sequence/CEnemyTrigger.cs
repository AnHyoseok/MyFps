using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;  //문
        public AudioSource doorBang;    //문 열기 사운드
        public AudioSource jumpScare;   //적 등장 사운드
        public GameObject theRobot;    //적
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            //문열기
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
           
            //문사운드
            doorBang.Play();
            //enemy 활성화
            theRobot.SetActive(true);
            //enemy 등장 사운드
            yield return new WaitForSeconds(1f);
            jumpScare.Play();

            //Enemy 타겟을 향해 걷기
            RobotController robot = theRobot.transform.GetComponent<RobotController>();
            if (robot != null)
            {
                robot.SetState(RobotState.R_Walk);
            }

            //트리거 충돌체 비활성화
            transform.GetComponent<BoxCollider>().enabled = false;

            Destroy(this.gameObject);
         
        }
    }
}