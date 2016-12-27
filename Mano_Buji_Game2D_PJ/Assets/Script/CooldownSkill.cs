using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CooldownSkill : MonoBehaviour {

    public Image Fill;
    public PlayerController _SkillCooldown;
    public int NumberSkill;

    void Start()
    {   
        _SkillCooldown = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (_SkillCooldown != null)
        {
            Fill.fillAmount = _SkillCooldown.CurrentCooldownSkill[NumberSkill] / _SkillCooldown.MaxCooldownSkill[NumberSkill];
        }
    }
}
