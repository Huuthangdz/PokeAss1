using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float range; 
    [SerializeField] private Transform centrePoint;
    [SerializeField] private float detectionRange = 10f;

    private Vector3 currentDestination; // Biến lưu điểm đích hiện tại
    private Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>().transform;
        SetRandomDestination(); // Đặt điểm ngẫu nhiên ban đầu
    }

    // Update is called once per frame
    void Update()
    {
        // Luôn kiểm tra khoảng cách với Player
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            // Nếu trong phạm vi phát hiện, chuyển mục tiêu đến vị trí của Player
            agent.SetDestination(player.position);
        }
        else if (agent.remainingDistance <= agent.stoppingDistance)
        {
            // Nếu không trong phạm vi và đã đến đích hiện tại, chọn điểm ngẫu nhiên mới
            SetRandomDestination();
        }
    }
    private void SetRandomDestination()
    {
        Vector3 point;
        if (RandomPoint(centrePoint.position, range, out point))
        {
            currentDestination = point;
            agent.SetDestination(currentDestination);
        }
    }
    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
