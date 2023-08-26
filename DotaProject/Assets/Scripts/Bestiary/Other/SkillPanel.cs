using TMPro;
using UnityEngine;
using UnityEngine.UI;

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



    public void SetSkillInPanel(SkillSO skill, Transform icon) //установка значений скилла в панель
    {
        skillNameText.text = skill.skillName;
        skillDescText.text = skill.skillDesc;
        skillIcon.sprite = skill.skillIcon;
        skillTypeText.text = Localizator.Localize("Ability") + Localizator.Localize(skill.skillType.ToString());
        if (skill.IsHasSomeSkills)
        {
            toolTip.SetActive(true);
        }
        if (skill.IsDamaging)
        {
            damageTypeText.gameObject.SetActive(true);

            damageTypeText.text = Localizator.Localize("DamageType") +
                IconLoader.LoadSmile(skill.damageType) + Localizator.Localize(skill.damageType.ToString());
        }
        transform.position = icon.position - new Vector3(0, 3.5f, 0);
    }


    #region SetSkillInPanel overrides
    public void SetSkillInPanel(SkillSO skill,Transform icon,Canvas canvas)
    {
        SetSkillInPanel(skill,icon);
        gameObject.transform.SetParent(canvas.transform, false);   
    }
    public void SetSkillInPanel(SkillSO skill,Transform icon, Canvas canvas, float yOffset)
    {
        SetSkillInPanel(skill,icon,canvas);
        transform.position = icon.position - new Vector3(0, yOffset, 0);
    }
    
    public void SetSkillInPanel(SkillSO skill, Transform icon, Transform parent ,float yOffset)
    {
        SetSkillInPanel(skill,icon);
        transform.position = parent.position - new Vector3(0, yOffset, 0);
    }
    #endregion

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        EventController.SwitchMenu += Destroy;
    }

    private void OnDestroy()
    {
        EventController.SwitchMenu -= Destroy;
    }
}
