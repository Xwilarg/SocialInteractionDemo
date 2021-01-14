using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _heart;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _heart = GameObject.FindGameObjectWithTag("Heart").transform;
        _agent.SetDestination(_heart.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Heart"))
        {
            GameManager.S.TakeDamage();
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
