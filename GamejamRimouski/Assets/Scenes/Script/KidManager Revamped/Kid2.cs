using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid2 : MonoBehaviour
{
    public bool embarqued = false;
    public bool arrived = false;
    public float timeAlive = 30f;
    public int timeAdd = 15;
    public int scoreAdd = 5;
    public float speed = 1.0f;

    private KidSpawnerManager spawner;
    private GameManager gameManager;
    private PlayerSeat player;
    private GameObject targetManager;

    private List<GameObject> targetsAvaible = new List<GameObject>();
    private GameObject target;
    public Animator animator;

    private void OnTriggerEnter(Collider collider)
    {
        if (arrived) return;
        if(collider.tag == "Player")
        {
            if(player.seatAvailable)
            {
                Embark();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("GameManager");
        spawner = GameObject.Find("Spawner").GetComponent<KidSpawnerManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSeat>();
        targetManager = GameObject.FindGameObjectWithTag("TargetManager");
        animator = GetComponent<Animator>();
        Debug.Log("start : " + this.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update : " + this.transform.position);
        if (!embarqued)
        {
            timeAlive -= Time.deltaTime;
        }
        if(timeAlive <= 0)
        {
            if (!arrived) spawner.removeKids();
            else EventManager.TriggerEvent("addScore", new Hashtable() { { "addScore", scoreAdd } });
            Destroy(this.gameObject);
        }
    }

    public void Embark()
    {
        float step = speed * Time.deltaTime;

        FindTarget();
        targetManager.GetComponent<TargetManager>().setActiveTarget(target);
        Debug.Log("Embark()");
        player.seatAvailable = false;
        player.client = this.gameObject;
        this.transform.parent = player.transform;

        EventManager.TriggerEvent("addTime", new Hashtable() { { "addTime", timeAdd } });
        animator.SetTrigger("swim");
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        embarqued = true;
    }


    public void Disembark()
    {

        spawner.removeKids();
        arrived = true;
        Debug.Log("Disembark()");
        timeAlive = 20f;
        embarqued = false;
        this.transform.parent = null;

        animator.SetTrigger("eject");


        target = null;
        targetManager.GetComponent<TargetManager>().removeActiveTarget();


        EventManager.TriggerEvent("addScore", new Hashtable() { { "addScore", scoreAdd } });
    }

    public void FindTarget()
    {
        List<GameObject> listTarget = spawner.targetList;
        

        target = listTarget[Random.Range(0,listTarget.Count)];
              
    }
}
