using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace MyFps
{
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        public GameObject preesKeyUI;
        private bool isAnykey;
        #endregion

        void Start()
        {
            isAnykey = false ;
            //페이드인 효과
            fader.FromFade();

            StartCoroutine(TitleProcess());
        }

        private void Update()
        {
            if (Input.anyKey && isAnykey==true)
            {
                GoToMenu();
            }
        }

        void GoToMenu()
        {
            StopAllCoroutines();
            fader.FadeTo(loadToScene);
        }

        IEnumerator TitleProcess()
        {
            yield return new WaitForSeconds(2f);
            preesKeyUI.SetActive(true);
            isAnykey = true;
            yield return new WaitForSeconds(10f);
            GoToMenu();
        }
    }
}