
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace MyFps
{
    public class PickupPuzzleItem : Interactive
    {
        #region Variables
        //퍼즐 UI
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI itemText;

        public GameObject puzzleItemGp;
        [SerializeField]private PuzzleKey PuzzleKey;

        public Sprite itemSprite;                                   // 흭득한 아이템 아이콘
        [SerializeField] private string puzzleStr = "Puzzle Text";   //아이템흭득 안내 텍스트문구
        #endregion
        protected override void DoAction()
        {
          StartCoroutine(GainPuzzleItem());
        }


        IEnumerator GainPuzzleItem()
        {
            //key Item 저장
            PlayerStats.Instance.AccuirePuzzleItem(PuzzleKey);

            if (puzzleUI != null)
            {
                //트리거 비활성화
                this.GetComponent<BoxCollider>().enabled = false;
                puzzleItemGp.SetActive(false);
                //연출
                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleStr = PuzzleKey.ToString();
                itemText.text = $"GET {puzzleStr}";

                yield return new WaitForSeconds(2f);
                puzzleUI.SetActive(false);
            }

            //킬
            Destroy(gameObject);
        }
    }
}