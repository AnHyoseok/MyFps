using MyFps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
   public class PickAmmo : PickUpItem
    {
        #region Variables
        [SerializeField] private int giveAmmo = 7;
        #endregion

        protected override bool OnPickup()
        {
            //탄환 7개 지금
            PlayerStats.Instance.AddAmmo(giveAmmo);
            return true;
        }
    }
}