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



    public void SetSkillInPanel(WikiSkill skill)
    {
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
                IconLoader.LoadSmile(skill.GetDamageType()) + Localizator.Localize(skill.GetDamageType().ToString());
        }
        transform.position = skill.gameObject.transform.position - new Vector3(0, 3.5f, 0);
    }


    #region SetSkillInPanel overrides

    public void SetSkillInPanel(WikiSkill skill, Canvas canvas)
    {
        SetSkillInPanel(skill);
        gameObject.transform.SetParent(canvas.transform, false);   
    }

    public void SetSkillInPanel(WikiSkill skill, float yOffset)
    {
        SetSkillInPanel(skill);
        transform.position = skill.gameObject.transform.position - new Vector3(0, yOffset, 0);
    }

    public void SetSkillInPanel(WikiSkill skill, Canvas canvas, float yOffset)
    {
        SetSkillInPanel(skill, canvas);
        transform.position = skill.gameObject.transform.position - new Vector3(0, yOffset, 0);
    }

    public void SetSkillInPanel(WikiSkill skill, Transform parent ,float yOffset)
    {
        SetSkillInPanel(skill);
        transform.position = parent.position - new Vector3(0, yOffset, 0);
    }

    public void SetSkillInPanel(WikiSkill skill, Canvas canvas, Transform parent, float yOffset)
    {
        SetSkillInPanel(skill, canvas);
        transform.position = parent.position - new Vector3(0, yOffset, 0);
    }

    #endregion

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
