using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMMovement_1 : MonoBehaviour
{

    private TestNexus target;
    private float speed;

    [SerializeField] float distanceToAttack = 2f;

    private FSM fsm;
    [SerializeField] float fsmUpdateTimer = 0.4f;

    private void Start()
    {
        target = FindObjectOfType<TestNexus>();
        speed = GetComponent<TestEnemy>().GetSpeed();


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
        Debug.Log((target.transform.position - transform.position).magnitude < distanceToAttack);
        return (target.transform.position - transform.position).magnitude < distanceToAttack;
    }


    /* ACTIONS */
    private void Charge()
    {
        float step = speed * Time.deltaTime;

        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        transform.position += transform.up * Mathf.Sin(Time.time * 3f) * 0.01f;
    }

    private void Attack()
    {
        float step = speed * Time.deltaTime;

        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step * 3);
    }

}
