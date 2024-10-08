using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

namespace MyFps
{
    public class DoorCellOpen : MonoBehaviour
    {
        #region Variables
        //action UI
        public GameObject actionUi;
        public GameObject extraCrossUi;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Open The Door";
        private float theDistance;

        public Animator animator;
        private Collider Collider;
        public AudioSource AudioSource;
        private bool isOpen = false;
        #endregion

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
            Collider=GetComponent<Collider>();
            animator = GetComponent<Animator>();
        }

        void DoorOpen()
        {
            //e키입력시 도어 오픈 
            if (Input.GetKeyDown(KeyCode.E))
            {

            }
        }


        private void OnMouseOver()
        {
            //PlayerCasting.distanceFromTarget

            //e키입력시 도어 오픈 
            if (theDistance <= 2f)
            {
                actionUi.SetActive(true);
                actionText.text = action;
                extraCrossUi.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    isOpen = !isOpen; 
                    animator.SetBool("IsOpen", isOpen);
                    AudioSource.Play();

                    // 문이 열렸을 때만 콜라이더 비활성화
                    if (isOpen)
                    {
                        Collider.enabled = false; 
                    }
                    else
                    {
                        Collider.enabled = true;  
                    }
                }
            }
            // 플레이어가 멀어지면 UI 숨기기
            else
            {
                actionUi.SetActive(false); 
                extraCrossUi.SetActive(false);
            }

        }

        private void OnMouseExit()
        {
            actionUi.SetActive(false);
        }
    }
}