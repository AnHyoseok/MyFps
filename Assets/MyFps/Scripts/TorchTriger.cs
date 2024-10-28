using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
   public class TorchTriger : MonoBehaviour
   {
        #region Variables
        public GameObject thePlayer;
        [SerializeField] private GameObject torch1;
        [SerializeField] private GameObject torch2;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            torch1.SetActive(true);
            torch2.SetActive(true);
        }

    }
}