using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

    Animator _anim;

    public GameObject[] Skill;
    public Transform SkillPoint;
    bool C_Enemy;

    void Start()
    {
        _anim = GetComponent<Animator>();
        StartCoroutine(_Waiting());
    }

    void Update()
    {
        _anim.SetFloat("CurrentHp", GetComponent<EnemyStatus>().CurrentHp);

    }


    public void TakeDamage()
    {

        GameObject thisEffect = Instantiate(Skill[Random.Range(0,Skill.Length)], SkillPoint.position, SkillPoint.rotation) as GameObject;
        if (thisEffect != null)
        {

            thisEffect.GetComponentInChildren<EffectPropertie>().PureDamage = GetComponent<EnemyStatus>().Damage;

        }
    }


    IEnumerator _Waiting()
    {
        _anim.SetBool("Collision", false);
        yield return new WaitForSeconds(Random.Range(2.0F, 8.0F));
        _anim.SetBool("Collision", true);

    }
    public void CancelAttack()
    {
        StartCoroutine(_Waiting());
    }

    public void Die()
    {
        _anim.SetBool("IsDie", true);

    }

    public void DestroySelf()
    {
        Destroy(gameObject, 0.1f);
        
    }
    public void ChageScene(string scenename)
    {
        Application.LoadLevel(scenename);
        Time.timeScale = 1;
    }
}
