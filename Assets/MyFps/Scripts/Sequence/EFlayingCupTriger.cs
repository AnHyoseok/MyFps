using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace MyFps
{
    public class EFlayingCupTriger : MonoBehaviour
    {
        #region Variables
        public GameObject activityObject;
        public GameObject thePlayer;
        #endregion

    

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(BreakCup());

        }

        IEnumerator BreakCup()
        {
          
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            activityObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            
            Destroy(activityObject);
            thePlayer.GetComponent<FirstPersonController>().enabled = true;
            Destroy(gameObject);

        }

    }
}