using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

    }

    private void Update()
    {

        scoreManager.AddScore(5);
    }
}
