using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MySample
{
   public class MoveWall : MonoBehaviour
   {
        #region Variables
        [SerializeField] private float speed = 1f;
       
        //이동 방향
        [SerializeField] private float dir = 1f;
        [SerializeField] private float movetime = 1f;
        [SerializeField] private float countdown = 1f;

        #endregion

        private void Start()
        {
            countdown = movetime;
        }

        private void Update()
        {
            if(countdown <= 0f)
            {
                dir *= -1;

                countdown = 1f;
            }
            countdown -=Time.deltaTime;
            transform.Translate(Vector3.right * speed * dir * Time.deltaTime, Space.World);
        }
    }
}