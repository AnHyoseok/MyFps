using MyFps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
    public class PickUpItem : MonoBehaviour
    {
        #region Variables
        //public GameObject thePlayer;


        private Vector3 startPosition;  //시작 위치

        [SerializeField][Range(0f, 10f)] private float speed =1f;
        [SerializeField][Range(0f, 10f)] private float length = 0.8f;

        private float runningTime = 0f;
        private float yPos = 0f;


        #endregion

        private void Start()
        {
            //처음위치
            startPosition = transform.position;
        }
        private void Update()
        {
           ItemMove();
            ItemRotate();
        }

        void ItemMove()
        {
            runningTime += Time.deltaTime * speed;
            yPos = Mathf.Sin(runningTime) * length;
            this.transform.position = startPosition +Vector3.up * yPos;
          
        }

        void ItemRotate()
        {
            transform.Rotate(30f * Time.deltaTime, 20f * Time.deltaTime, 10f * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            //플레이어 체크
            if (other.tag == "Player")
            {
               if(OnPickup() == true)
                {
                   //흭득성공 효과,사운드,이펙트

                   //킬
                    Destroy(gameObject);
                }
            }

   
        }

        //아이템 흭득 성공,실패 반환
       protected virtual bool OnPickup()
        {
          

            //탄환 지급 : 7개
            //hp,mp 아이템
            //...

            return true;
        }
    }
}