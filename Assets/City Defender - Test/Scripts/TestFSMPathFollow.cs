using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFSMPathFollow : MonoBehaviour
{

    [SerializeField] float fsmUpdateTimer = 0.01f;
    [SerializeField] float distanceToAttack = 10f;

    private TestEnemy enemy;
    private TestNexus target;
    private FSM fsm;

    private void Start()
    {
        enemy = GetComponent<TestEnemy>();
        target = FindObjectOfType<TestNexus>();


        FSMState charge = new FSMState();
        charge.stayActions.Add(Charge);

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
    private void Charge()
    {
        float step = enemy.GetSpeed() * Time.deltaTime;

        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        transform.position += transform.up * Mathf.Sin(Time.time * 3f) * 0.01f;
    }

    private void Attack()
    {
        float step = enemy.GetSpeed() * Time.deltaTime;

        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step * 2);
    }
}
