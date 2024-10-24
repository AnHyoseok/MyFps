using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

namespace MyFps
{
    public class DoorKeyOpen : Interactive
    {
        #region Variables

        //action
        private Animator animator;
        private Collider m_Collider;

        public TextMeshProUGUI sequneceText;

        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<BoxCollider>();
        }

        protected override void DoAction()
        {
            
            if (PlayerStats.Instance.HasPuzzleItem(PuzzleKey.ROOM01_KEY))
            {
                OpenDoor();
            }
            else
            {
              StartCoroutine(  LockedDoor());
            }

        }

        void OpenDoor()
        {
            //문이 열리는 액션
            animator.SetBool("IsOpen", true);
            GetComponent<Collider>().enabled = false;
            AudioManager.Instance.Play("DoorOpen");
        }

        IEnumerator LockedDoor()
        {
            //문 잠긴 소리
            unInteractive = true; //인터랙티브 기능 정지
            sequneceText.text = "The Door Is Locked";

            AudioManager.Instance.Play("DoorLocked");
          
            yield return new WaitForSeconds(1f);

            sequneceText.text = "";
            unInteractive = false; //인터랙티브 기능 복원
        }

    }

}