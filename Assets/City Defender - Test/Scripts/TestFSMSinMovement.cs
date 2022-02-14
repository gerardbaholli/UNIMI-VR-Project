using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation
{

    public class TestFSMSinMovement : MonoBehaviour
    {

        private TestEnemy enemy;
        private TestNexus target;

        [SerializeField] float distanceToAttack = 10f;

        private PathCreator[] pathCreatorList;
        private PathCreator pathCreator;
        [SerializeField] EndOfPathInstruction endOfPathInstruction;
        private float distanceTravelled;

        private FSM fsm;
        [SerializeField] float fsmUpdateTimer = 0.01f;

        private void Start()
        {
            enemy = GetComponent<TestEnemy>();
            target = FindObjectOfType<TestNexus>();

            pathCreatorList = FindObjectsOfType<PathCreator>();
            int numberOfPathCreator = pathCreatorList.Length;
            pathCreator = pathCreatorList[Random.Range(0, numberOfPathCreator)];


            FSMState charge = new FSMState();
            charge.stayActions.Add(PathFollow);

            FSMState attack = new FSMState();
            attack.stayActions.Add(Attack);

            FSMTransition t1 = new FSMTransition(Distance);
            charge.AddTransition(t1, attack);

            fsm = new FSM(charge);

            StartCoroutine(Patrol());
        }

        private IEnumerator Patrol()
        {
            while (true)
            {
                fsm.Update();
                yield return new WaitForSeconds(fsmUpdateTimer);
            }
        }

        /* CONDITIONS */
        public bool Distance()
        {
            return (target.transform.position - transform.position).magnitude < distanceToAttack;
        }


        /* ACTIONS */
        private void PathFollow()
        {
            if (pathCreator != null)
            {
                distanceTravelled += enemy.GetSpeed() * Time.deltaTime * 2;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        private void Attack()
        {
            float step = enemy.GetSpeed() * Time.deltaTime;

            transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step * 2);
        }
    }

}
