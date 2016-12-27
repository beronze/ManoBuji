using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {


    Animator _anim;
	//Attack
	public float AttackSpeed,LimedBlock = 100f;
	public Transform PointEffect;
	public GameObject[] Skill;
	public float[] CurrentCooldownSkill,MaxCooldownSkill;
	public int NumberSkillUse;
    public GameObject P_Screen;


	void Start () {
		_anim = gameObject.GetComponent<Animator> ();

	}
	
	void Update () {

        _anim.SetFloat("CurrentHp", GetComponent<PlayerStatus>().CurrentHp);
        _anim.SetFloat("CurrentBlock", GetComponent<PlayerStatus>().CurrentBlock);
		//Attack

		//rage
		for (int i = 0; i<Skill.Length; i++) 
		{
            if (CurrentCooldownSkill[i] < MaxCooldownSkill[i])
            {
				CurrentCooldownSkill[i] += Time.deltaTime;
			} 
			else 
			{
                CurrentCooldownSkill[i] = MaxCooldownSkill[i];
			}
		}

        if (GetComponent<PlayerStatus>().CurrentBlock < GetComponent<PlayerStatus>().MaxBlock)
        {
            GetComponentInChildren<PlayerStatus>().CurrentBlock += Time.deltaTime * 20;
        }
        if(_anim.GetBool("Block"))
        {
            GetComponentInChildren<PlayerStatus>().CurrentBlock -= Time.deltaTime * 100;
        }


        if (Input.GetKeyDown(KeyCode.A) && CurrentCooldownSkill[0] >= MaxCooldownSkill[0]) 
		{
			NumberSkillUse = 0;
			_anim.SetBool("IsTakingDamage",true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && CurrentCooldownSkill[1] >= MaxCooldownSkill[1])
        {
            NumberSkillUse = 1;
            _anim.SetBool("IsTakingDamage", true);
        }
        else if (Input.GetKeyDown(KeyCode.W) && CurrentCooldownSkill[2] >= MaxCooldownSkill[2])
        {
            NumberSkillUse = 2;
            _anim.SetBool("IsTakingDamage", true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && CurrentCooldownSkill[3] >= MaxCooldownSkill[3])
        {
            NumberSkillUse = 3;
            _anim.SetBool("IsTakingDamage", true);
        }



        if (GetComponent<PlayerStatus>().CurrentBlock >= 300f)
        {
            LimedBlock = 100f;
        }else if (GetComponent<PlayerStatus>().CurrentBlock <= 100f)
        {
            LimedBlock = 300f;
        }
        if (Input.GetKey(KeyCode.D) && GetComponent<PlayerStatus>().CurrentBlock > LimedBlock)
        {
            _anim.SetBool("Block", true);
            GetComponentInChildren<PlayerStatus>().statusBlock = true;
        }
        else
        {
            _anim.SetBool("Block", false);
            GetComponentInChildren<PlayerStatus>().statusBlock = false;
        }
	}

	//Attack
	public void TakeDamage()
	{
        GameObject thisEffect = Instantiate(Skill[NumberSkillUse],PointEffect.position,PointEffect.rotation)as GameObject;
        if (thisEffect != null)
        {
            thisEffect.GetComponentInChildren<EffectPropertie>().PureDamage = GetComponent<PlayerStatus>().Damage;
            CurrentCooldownSkill[NumberSkillUse] =MaxCooldownSkill[NumberSkillUse] / AttackSpeed;
        }
	}
	public void CancelAttack()
	{
		_anim.SetBool ("IsTakingDamage", false);
	}

	public void Die()
	{
		_anim.SetBool ("IsDie", true);
        Time.timeScale = 0;
        P_Screen.SetActive(true);

	}
	public void DestroySelf()
	{
		Destroy(gameObject, 0.5f);
	}



}
