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
    private GameObject GOChildPoubelle;


    private KidSpawnerManager spawner;
    private GameManager gameManager;
    private PlayerSeat player;
    private GameObject targetManager;

    private List<GameObject> targetsAvaible = new List<GameObject>();
    private GameObject target;
    public Animator animator;
    public bool isSwming;

    private void OnTriggerEnter(Collider collider)
    {
        if (arrived) return;


        if(collider.tag == "Player")
        {

            if (player.seatAvailable)
            {
                Embark();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isSwming = false;

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
        GOChildPoubelle = GameObject.Find("GOChildPoubelle");
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!embarqued)
        {
            timeAlive -= Time.deltaTime;
        }
        if(timeAlive <= 0)
        {
            if (!arrived) spawner.removeKids();
            else EventManager.TriggerEvent("addScore", new Hashtable() { { "addScore", scoreAdd } });
            Destroy(this.gameObject);
        }

        if (isSwming)
        {
            kidSwiming();
        }
    }

    private void kidSwiming()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        var q = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 360);
    }

    public void Embark()
    {
        animator.SetTrigger("swim");
        isSwming = true;

        FindTarget();
        targetManager.GetComponent<TargetManager>().setActiveTarget(target);
        player.seatAvailable = false;
        player.client = this.gameObject;
        EventManager.TriggerEvent("addTime", new Hashtable() { { "addTime", timeAdd } });
        embarqued = true;
    }


    public void Disembark()
    {
        spawner.removeKids();
        arrived = true;
        timeAlive = 20f;
        embarqued = false;
        this.transform.parent = GOChildPoubelle.transform;
        player.isOnBeluga = false;
        animator.SetTrigger("eject");


        EventManager.TriggerEvent("addScore", new Hashtable() { { "addScore", scoreAdd } });
    }

    public void FindTarget()
    {
        List<GameObject> listTarget = spawner.targetList;
        

        target = listTarget[Random.Range(0,listTarget.Count)];
              
    }
}
