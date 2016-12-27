using UnityEngine;
using System.Collections;

public class EffectPropertie : MonoBehaviour {

	public Animator _anim;
	public float Speed;
	public bool IsRage;

	public float PureDamage,PercentDamage;
	public GameObject _TextDamage;

    public bool ManyHit;
    public int _ManyHit;

	public enum OwnerType
	{
		Player,
		Enemy
	}

	public OwnerType Owner;

	void Start () {
	
		_anim = GetComponent<Animator> ();
	}
	

	void Update () {
  
		if (IsRage) 
		{
            if (Owner == OwnerType.Player)
            {
                transform.Translate(Speed * Time.deltaTime, 0, 0);
            }else
            {
                transform.Translate(Speed * -Time.deltaTime, 0, 0);
            }
		}
        
	}

   
	void OnTriggerEnter2D(Collider2D other)
	{
        if (ManyHit)
        {
            if (other.gameObject.tag == "Enemy" && Owner == OwnerType.Player)
            {
                if (IsRage)
                {
                    Speed = 0;
                    _anim.SetBool("Collision", true);
                }
                EnemyStatus estat = other.gameObject.GetComponent<EnemyStatus>();
                for (int i = 1; _ManyHit >= i; i++)
                {
                    
                    estat.CurrentHp = estat.CurrentHp - CalculateDamage() < 0 ? 0 : estat.CurrentHp - CalculateDamage();
                    DrawText(CalculateDamage(), other.transform.position);
                }
            }
            if (other.gameObject.tag == "Player" && Owner == OwnerType.Enemy)
            {
                if (IsRage)
                {
                    Speed = 0;
                    _anim.SetBool("Collision", true);
                }
                PlayerStatus pstat = other.gameObject.GetComponent<PlayerStatus>();
                for (int i = 1; _ManyHit >= i; i++)
                {
                    pstat.CurrentHp = pstat.CurrentHp - CalculateDamage() < 0 ? 0 : pstat.CurrentHp - CalculateDamage();
                    DrawText(CalculateDamage(), other.transform.position);
                }

            }

        }
        else
        {
            
            if (other.gameObject.tag == "Enemy" && Owner == OwnerType.Player)
            {
                EnemyStatus estat = other.gameObject.GetComponent<EnemyStatus>();
                estat.CurrentHp = estat.CurrentHp - CalculateDamage() < 0 ? 0 : estat.CurrentHp - CalculateDamage();
                DrawText(CalculateDamage(), other.transform.position);

                if (IsRage)
                {
                    Speed = 0;
                    _anim.SetBool("Collision", true);
                }


            }
            if (other.gameObject.tag == "Player" && Owner == OwnerType.Enemy)
            {
                PlayerStatus pstat = other.gameObject.GetComponent<PlayerStatus>();
                if (pstat.statusBlock == false)
                {
                    pstat.CurrentHp = pstat.CurrentHp - CalculateDamage() < 0 ? 0 : pstat.CurrentHp - CalculateDamage();
                    DrawText(CalculateDamage(), other.transform.position);
                }
                else
                {
                    DrawText(0, other.transform.position);
                }

                if (IsRage)
                {
                    Speed = 0;
                    _anim.SetBool("Collision", true);
                }
            }
        }
	}

    public void DestroySelf()
	{

		Destroy (gameObject.transform.parent.gameObject,0.2f);
	}

	public float CalculateDamage()
	{
		float damage = PureDamage * (PercentDamage / 100);
        return Random.Range(damage - damage * 10 / 100, damage + damage * 10 / 100);

	}

	public void DrawText(float damage,Vector3 pos)
	{
        GameObject thistext = Instantiate(_TextDamage, pos + new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), -2), _TextDamage.transform.rotation) as GameObject;

		if (thistext != null) 
		{
            if (damage == 0)
            {
                thistext.GetComponent<TextMesh>().text = "BLOCK";
                thistext.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 200));
            }
            else
            {
                thistext.GetComponent<TextMesh>().text = damage.ToString(damage > 0 ? "#,###,###,###" : "");
                thistext.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 200));
            }
		}


	}
}
