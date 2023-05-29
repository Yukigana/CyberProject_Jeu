using UnityEngine;

public class FightController : MonoBehaviour
{
    [Header("Champion")]
    [SerializeField] private Champion champion;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        champion = this.GetComponent<PlayerController>().GetChampion();
    }

    public void TakeDamage(int damage)
    {
        champion.setPv(champion.getPv() - damage);

        animator.SetTrigger("Hurt");
        print(" pv : " + champion.getPv());

        if(champion.getPv() <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("isDead", true);

        this.GetComponent<BoxCollider2D>().size = new Vector2(2.3f, 0.55f);
        this.enabled = false;
    }
}
