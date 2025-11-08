using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minWalkTime = 2f;
    public float maxWalkTime = 5f;
    public float minIdleTime = 1f;
    public float maxIdleTime = 3f;

    private Animator animator;
    private float actionTimer;
    private bool isWalking;

    void Start()
    {
        animator = GetComponent<Animator>();
        ChooseAction();
    }

    void Update()
    {
        actionTimer -= Time.deltaTime;

        if (isWalking)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (actionTimer <= 0f)
        {
            ChooseAction();
        }
    }

    void ChooseAction()
    {
        if (Random.value > 0.5f) // 50% chance walk or idle
        {
            isWalking = true;
            actionTimer = Random.Range(minWalkTime, maxWalkTime);
            transform.Rotate(0, Random.Range(-90f, 90f), 0); // random direction
        }
        else
        {
            isWalking = false;
            actionTimer = Random.Range(minIdleTime, maxIdleTime);
        }
    }
}
