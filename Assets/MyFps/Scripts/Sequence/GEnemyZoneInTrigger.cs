using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
   public class EnemyZoneInTrigger : MonoBehaviour
   {
        #region Variables
        public Transform gunMan;

        public GameObject enemyZoneOut; //Out 트리거
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            //건맨 추격시작
            if(other.tag == "Player")
            {
                gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);


            }
        }
        private void OnTriggerExit(Collider other)
        {
            //gunMan 제자리로 이동
            if (other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                enemyZoneOut.SetActive(true);
            }
        }
    }
}