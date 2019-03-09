using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{

    private AISpawner m_AIManager;

    private bool m_isMoving = false;
    private bool m_isTurning;

    private Vector3 m_wayPoint;
    private Vector3 m_lastWaypoint = new Vector3(0f, 0f, 0f);
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
