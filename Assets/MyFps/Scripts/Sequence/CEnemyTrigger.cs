using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
       
            theDoor.GetComponent<Animator>().SetBool("IsOpen",true);
            //트리거 충돌체 비활성화
            transform.GetComponent<BoxCollider>().enabled = false;
            theDoor.GetComponent<BoxCollider>().enabled = false;
            yield return null;
        }
    }
}