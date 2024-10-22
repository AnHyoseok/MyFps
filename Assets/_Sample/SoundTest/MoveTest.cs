using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
namespace MySample
{
   public class MoveTest : MonoBehaviour
   {
        #region Variables
        [SerializeField] private float power = 5f;
        private Rigidbody rb;
        #endregion

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

    
        private void FixedUpdate()
        {
            rb.AddForce(Vector3.forward * power,ForceMode.Acceleration);

            if (Input.GetKey(KeyCode.A) == true)
            {
                rb.AddForce(Vector3.left * power);
            }

            if (Input.GetKey(KeyCode.D) == true)
            {
                rb.AddForce(Vector3.right * power);
            }
         
        }
    }
}