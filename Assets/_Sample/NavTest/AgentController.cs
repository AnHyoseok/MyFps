using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace MySample
{
    // 마우스로 그라운드를 클릭하면 클릭한 지점으로 Agent를 이동

    public class AgentController : MonoBehaviour
    {
        #region Variables
        NavMeshAgent agent;
        [SerializeField] private Vector3 woldPosition; //이동 목표지점
        #endregion

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.destination = hit.point;
                }
            }

        }
    }
}