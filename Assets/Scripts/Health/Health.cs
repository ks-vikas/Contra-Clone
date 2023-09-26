using UnityEngine;

public class Health : MonoBehaviour
{   
    // player intial health
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }//read only from outside 

    private Animator anim;
    private bool dead;

    //set intial health to 100%
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }


    // update health when player takes damage.
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);//health will be between 0 to 100%

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");    //player is hurt play hurt animation
            //iframes
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die"); // player is dead play death animation
                GetComponent<PlayerMovement>().enabled = false; // restrict player further movements afterwards
                dead = true;
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth); // collected positive health.
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}