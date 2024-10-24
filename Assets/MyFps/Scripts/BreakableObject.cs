using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyFps
{
   public class BreakableObject : MonoBehaviour,IDamageable
   {
        #region Variables
        public GameObject fakeVase;     //깨지기전
        public GameObject breakVase;    //깨질때
        public GameObject EffectObject; //깨지는 움직임 효과 오브젝트
        public GameObject HiddenItem;
        private bool isBreak=false;

      [SerializeField]  private bool unBreakable = false; // true : 깨지지 않는다
        #endregion

        public void TakeDamage(float damage)
        {
            //끼짐 여부 체크
            if (unBreakable)
                return;

            //원샷원킬
            if (!isBreak)
            {
                StartCoroutine(BreakObject());
            }
         
        }

        IEnumerator BreakObject()
        {
            isBreak = true;
            this.GetComponent<BoxCollider>().enabled = false;
            fakeVase.SetActive(false);
            yield return new WaitForSeconds(0.05f);
            breakVase.SetActive(true);

            AudioManager.Instance.PlayBgm("PotterySmash");
            if (EffectObject != null)
            {
                EffectObject.SetActive(true);
                yield return new WaitForSeconds(0.05f);
                EffectObject.SetActive(false);
            }

            //숨겨진 아이템 있으면 아이템 보여주기
            if (HiddenItem != null)
            {
                HiddenItem.SetActive(true );
            }

        }
        
    }
}