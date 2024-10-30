using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
   public class HEnemyZoneOutTrigger : MonoBehaviour
   {
        #region Variables
        public Transform gunMan;

        public GameObject enemyInZone; //in 트리거
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
            Debug.Log("적에게 제자리로 돌아가라");
     
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("InTrigger 활성화");
            if (other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                enemyInZone.SetActive(true);
            }
        }

    }
}