using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{

    public class PickupPistol : Interactive
    {
        #region Variables
   

 
        //action
        public GameObject realPistol;
        public GameObject Arrow;


        #endregion

        protected override void DoAction()
        {
            realPistol.SetActive(true);
            Arrow.SetActive(false);
            Destroy(gameObject);
        }

     
    }

}

