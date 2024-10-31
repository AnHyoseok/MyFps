using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
   public class CreditUI : MonoBehaviour
   {
        #region Variables
        public GameObject mainManu;
        #endregion

        private void Update()
        {
            GototheMenu();
        }

        private void HideCredits()
        {
            mainManu.SetActive(true);
           this.gameObject.SetActive(false);
        }

        void GototheMenu()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideCredits();
            }
        }
    }
}