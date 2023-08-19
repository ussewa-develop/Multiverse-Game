using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static WikiSkill;

public class SkillPanel : MonoBehaviour
{
    public TextMeshProUGUI skillNameText;
    public TextMeshProUGUI skillTypeText;
    public TextMeshProUGUI skillDescText;
    public Image skillIcon;
    public TextMeshProUGUI skillCooldownText;
    public TextMeshProUGUI skillManaText;
    public TextMeshProUGUI skillActionPointText;
    public GameObject background;
    public GameObject toolTip;
    public TextMeshProUGUI textTip;
    public TextMeshProUGUI damageTypeText;

    public void SetSkillInPanel(WikiSkill skill, Canvas canvas)
    {
        gameObject.transform.SetParent(canvas.transform, false);
        skillNameText.text = skill.GetName();
        skillDescText.text = skill.GetDescription();
        skillIcon.sprite = skill.GetIcon();
        skillTypeText.text = Localizator.Localize("Ability") + Localizator.Localize(skill.GetSkillType().ToString());
        if (skill.IsHasSomeSkills)
        {
            toolTip.SetActive(true);
        }
        if (skill.IsDamaging)
        {
            damageTypeText.gameObject.SetActive(true);

            damageTypeText.text = Localizator.Localize("DamageType") + 
                IconLoader.LoadSmile(skill.GetDamageType())+Localizator.Localize(skill.GetDamageType().ToString());
        }
        transform.position = skill.gameObject.transform.position - new Vector3(0, 3.5f, 0);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        EventManager.SwitchMenu += Destroy;
    }

    private void OnDestroy()
    {
        EventManager.SwitchMenu -= Destroy;
    }
}
