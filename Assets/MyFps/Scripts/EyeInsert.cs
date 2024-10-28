using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace MyFps
{
    public class EyeInsert : Interactive
    {
        #region Variables

        //퍼즐 UI
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI itemText;
        public Sprite itemSprite;

        public GameObject exitWall;
        public GameObject exitWallanim;
        public GameObject EmptyPicture;
        private Animator animator;
        
        public TextMeshProUGUI notItmeText;
        #endregion

        private void Awake()
        {
            animator = GetComponent<Animator>();

        }

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());

        }

        IEnumerator GainPuzzleItem()
        {
          
            if (PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LeftEye) && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RightEye))
            {
                if (puzzleUI != null)
                {
                    //트리거 비활성화
                    this.GetComponent<BoxCollider>().enabled = false;
                    EmptyPicture.SetActive(false);
                    //연출
                    puzzleUI.SetActive(true);
                    itemImage.sprite = itemSprite;

                    itemText.text = $"The Door Opened";

                    yield return new WaitForSeconds(2f);
                    puzzleUI.SetActive(false);
                }

                exitWall.SetActive(false);
                exitWallanim.SetActive(true) ;

            }
            else
            {
                notItmeText.text = "Don't Have Enough Key";
                yield return new WaitForSeconds(0.5f);
                notItmeText.text = "";
            }
        }
    }
}