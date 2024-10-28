using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
    public class FlyingCup : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float velocity = 1f; //사운드 플레이 기준이 되는 속도
        #endregion

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.relativeVelocity.magnitude > velocity)
            {
                //오브젝트나 바닥에 부딫히는 사운드 재생
                AudioManager.Instance.Play("BreakCup");
            }
        }
    }
}