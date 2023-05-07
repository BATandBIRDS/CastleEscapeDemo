using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CombatSystem : MonoBehaviour
{// Observer

    // ATTACH TO THE ENEMIES
    [SerializeField] int enemyLevel;
    [SerializeField] TextMeshPro lvlTxt;
    [SerializeField] ParticleSystem dieEffect;
    [SerializeField] GameObject loosePanel;

    Animator animator;
    EnemyMover em;

    void Start()
    {
        em = GetComponent<EnemyMover>();
        animator = GetComponent<Animator>();
        loosePanel.SetActive(false);
        lvlTxt.text = "lvl: " + enemyLevel;
        lvlTxt.color = Color.red;
        ItemCollection.GotKey += TurnLvlTxtGreen;
    }

    private void OnDestroy()
        {
            ItemCollection.GotKey -= TurnLvlTxtGreen;
        }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            int plyrLvl = other.GetComponent<ItemCollection>().GetPlayerLevel();
            if (enemyLevel <= plyrLvl)
            {
                em.canMove = false;
                dieEffect.Play();
                Invoke("Die", 0.5f);
            }
            else
            {
                // YOU DIED (REPLAY OR EXIT CANVAS)
                animator.ResetTrigger("isRunning");
                animator.SetTrigger("canAttack");
                em.canMove = false;
                Invoke("KillPlayer", 1.5f);
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void KillPlayer()
    {
        loosePanel.SetActive(true);
    }

    void TurnLvlTxtGreen()
    {
        lvlTxt.color = Color.green;
    }
}
