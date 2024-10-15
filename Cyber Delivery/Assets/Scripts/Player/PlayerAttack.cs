using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] musicNotes;
    [SerializeField] private AudioClip musicNoteClip;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(musicNoteClip);
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        musicNotes[FindMusicNote()].transform.position = firePoint.position;
        musicNotes[FindMusicNote()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindMusicNote()
    {
        for (int i = 0; i < musicNotes.Length; i++)
        {
            if (!musicNotes[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
