using UnityEngine;
using UnityEngine.Events;

public class damage : MonoBehaviour
{
    [SerializeField] private int attackTimer = 5;
    [SerializeField] private int stayAttackTimer = 3;
    [SerializeField] private UnityEvent damageEvent;
    private float timer = 0;
    private bool attackNow = false;
    private Animator animator;
    private AudioSource audio;

    //Todo: figure out later should I move all the damage events to conditions or not for better
    private void Awake()
    {
        timer = attackTimer + stayAttackTimer;
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        damageEvent.AddListener(GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().Killed);
        damageEvent.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<Conditions>().loseScreen);
        damageEvent.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<attackSpawner>().endAttack);
    }

    void Update()
    {
        if (timer <= 0){
            Destroy(gameObject);

        }
        else if (timer <= stayAttackTimer){
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            attackNow = true;

        }
        else if (timer <= (1 + stayAttackTimer) && !animator.GetBool("startLaser")){
            animator.SetBool("startLaser", true);
            audio.Play();

        }

        timer -= Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackNow && collision.gameObject.tag == "Player"){
            damageEvent.Invoke();
        }
    }

}
