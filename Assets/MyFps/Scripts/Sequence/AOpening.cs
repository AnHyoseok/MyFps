using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace MyFps
{
    public class AOpening : MonoBehaviour
    {
        #region Variables

        public GameObject thePlayer;

        public SceneFader fader;

        //sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField] string sequence = "I need get out of here";
        #endregion

        void Start()
        {

            StartCoroutine(PlaySequence());
        }

        //오프닝 시퀀스
        IEnumerator PlaySequence()
        {

            //0.플레이 캐릭터 비 활성화
            thePlayer.SetActive(false);
            //1.페이드인 연출(1초 대기후 페인드인 효과)
            fader.FromFade(1f); //2초동안 페이드효과
            //2.화면 하단에 시나리오 텍스트 화면 출력(3초)
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;
            //  (I need get out of here)
            //3. 3초후에 시나리오 텍스트 없어진다
            yield return new WaitForSeconds(3f);
            textBox.gameObject.SetActive(false);
            //SequenceText.SetActive(false);
            //4.플레이 캐릭터 활성화
            thePlayer.SetActive(true);



        }
    }
}