using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSword : MonoBehaviour
{
    public float straightRange = 2; //zasięgi hitboxa
    private float upRange = 2;
    public float widthRange = 3;

    public float damage = 2;

    public float maxStamina = 100;
    public float stamina;

    private BoxCollider trigger; //referencja do BoxCollader znajdującego się w Unity
    public EnemyMenager enemyMenager; //referencja do EnemyMenagera

    public Animator swordAnim; //Animacja ataku

    public bool IsAvailable = true;
    public float CooldownDuration = 0.4f;

    public Slider slider;

    void Start()
    {
        trigger = GetComponent<BoxCollider>(); //Jak konstruktor w Javie
        trigger.size = new Vector3(straightRange, upRange, widthRange); //ustawianie parametrów hitboxa
        trigger.center = new Vector3(0, 0, 2); //ustawianie środka hitboxa
        stamina = maxStamina;
    }

    void Update()
    {
        SetStamina();
        staminaUp(); //chcemy aby w każdej sekundzie stamina nam się aktualizowała

        if (Input.GetMouseButtonDown(0) && stamina > 20 && IsAvailable && !PauseMenu.isPaused)
        {
            GetComponent<AudioSource>().Stop(); //dzwięk stop żeby nie było pętli a potem start
            GetComponent<AudioSource>().Play();

            swordAnim.SetBool("isAttacking", true);

            stamina -= 25; //każdy atak zabiera 10 staminy

            foreach (var enemy in enemyMenager.enemiesInTrigger) //dla każdego enemy w kolekcji enemyMenager
            {
                enemy.TakeDamage(damage);
            }

            StartCoroutine(StartCooldown());
        }
        else
        {
            swordAnim.SetBool("isAttacking", false);
        }
    }

    private void OnTriggerEnter(Collider other) //Dodawanie przeciwników
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if(enemy)
        {
            enemyMenager.AddEnemy(enemy); //funkcja z enemyMenagera dodająca przeciwnika
        }
    }

    private void OnTriggerExit(Collider other) //Usuwanie Przeciwników
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if(enemy)
        {
            enemyMenager.RemoveEnemy(enemy);
        }
    }

    void staminaUp() //chyba widać co się dzieje
    {
        if (stamina < maxStamina)
        {
            stamina += 0.02f;
        }
        else
        {
            stamina = maxStamina;
        }

        if (stamina < 0)
        {
            stamina = 0;
        }
    }

    public IEnumerator StartCooldown() //Cooldown
    {
        IsAvailable = false;
        yield return new WaitForSeconds(CooldownDuration); //czeka tyle ile podamy
        IsAvailable = true;
    }

    public void SetStamina()
    {
        slider.value = stamina; //stamina na pasku 
    }

    public void SetDamage(float amount)
    {
        damage += amount;
    }

}
