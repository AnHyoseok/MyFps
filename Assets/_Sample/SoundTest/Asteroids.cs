using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MySample
{
   public class Asteroids : MonoBehaviour
   {
        #region Variables
        public GameObject asteroids;
        public GameObject rangeObject;
        public Transform player;
        BoxCollider rangeCollider;
        public int astcount = 50;
        #endregion
        private void Awake()
        {
            rangeCollider = rangeObject.GetComponent<BoxCollider>();
        }

        private void Start()
        {
            StartCoroutine(RandomRespawn_Coroutine());
        }

        Vector3 Return_RandomPosition()
        {
            Vector3 originPosition = rangeObject.transform.position;
            // 콜라이더의 사이즈를 가져오는 bound.size 사용
            float range_X = rangeCollider.bounds.size.x ;
            float range_Z = rangeCollider.bounds.size.z;

            range_X = Random.Range((range_X / 2) * -1, range_X / 2) + player.position.x;
            range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
            Vector3 RandomPostion = new Vector3(range_X, 1.2f, range_Z);

            Vector3 respawnPosition = originPosition + RandomPostion;
            return respawnPosition;
        }

    
        IEnumerator RandomRespawn_Coroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);


                GameObject instantCapsul = Instantiate(asteroids, Return_RandomPosition(), Quaternion.identity);

                Destroy(instantCapsul, 2f);
            }
        }
    }
}