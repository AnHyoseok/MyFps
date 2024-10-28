using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace MyFps
{
   public class PickupLeftEYE : Interactive
    {
        #region Variables
        //퍼즐 UI
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI itemText;

        public GameObject puzzleItemGp;
        public Sprite itemSprite;                                   // 흭득한 아이템 아이콘
       [SerializeField] private string puzzleStr = "Puzzle Text";   //아이템흭득 안내 텍스트문구
        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GetItem());
        }

        IEnumerator GetItem()
        {
            //key Item 저장
            PlayerStats.Instance.AccuirePuzzleItem(PuzzleKey.LeftEye);

        
            
            if (puzzleUI != null)
            {
                //트리거 비활성화
                this.GetComponent<BoxCollider>().enabled = false;
                puzzleItemGp.SetActive(false);
                //연출
                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                itemText.text = puzzleStr;

                yield return new WaitForSeconds(2f);
                puzzleUI.SetActive(false);
            }
          
            //킬
            Destroy(gameObject);

        }
    }
}