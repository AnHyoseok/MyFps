using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
   public class CinemachineShake : Singleton<CinemachineShake>
   {
       #region Variables
        private CinemachineVirtualCamera cvCamera;
        private CinemachineBasicMultiChannelPerlin channelPerlin;

       //[SerializeField] private float amplitued = 1f; //흔들림의 크기
       [SerializeField] private float frequency = 1f; //흔들림의 속도

        private bool isShake = false;               //흔들리고 있는지 여부
        #endregion

        protected override void Awake()
        {
            base.Awake();

            cvCamera = GetComponent<CinemachineVirtualCamera>();
            channelPerlin = cvCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void Update()
        {
            //치팅키
            if(Input.GetKeyDown(KeyCode.G))
            {
                ShakeCamera(1f, 1f);
            }
        }

        //카메라 흔들기
        //amplitued : 흔들림 세기 , 크기 , shakeTime : 흔들리는시간
        public void ShakeCamera(float amplitued,float shakeTime)
        {
            //현재 흔들리고 있으면 더 흔들리지 않는다;
            if (isShake)
                return;

            StartCoroutine(StartShake(amplitued, shakeTime));
        }

        IEnumerator StartShake(float amplitued, float shakeTime)
        {
            isShake = true;
            channelPerlin.m_AmplitudeGain = amplitued;
            channelPerlin.m_FrequencyGain = frequency;

            yield return new WaitForSeconds(shakeTime);

            channelPerlin.m_AmplitudeGain = 0f;
            channelPerlin.m_FrequencyGain = 0f;
            isShake = false;
        }
    }
}