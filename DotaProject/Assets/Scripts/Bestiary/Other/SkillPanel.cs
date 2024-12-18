using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
    [Header("\t\t\tSkill values")]
    [SerializeField] TextMeshProUGUI skillNameText;
    [SerializeField] TextMeshProUGUI skillTypeText;
    [SerializeField] TextMeshProUGUI skillDescText;
    [SerializeField] Image skillIcon;
    [SerializeField] TextMeshProUGUI skillCooldownText;
    [SerializeField] TextMeshProUGUI skillManaText;
    [SerializeField] TextMeshProUGUI skillActionPointText;
    [SerializeField] TextMeshProUGUI skillDamageTypeText;
    [Space]
    [Header("\t\t\tOther")]
    [SerializeField] GameObject background;
    [SerializeField] GameObject downStats;
    [SerializeField] GameObject toolTip;
    [SerializeField] TextMeshProUGUI textTip;
    [Space]
    [Header("\t\t\tValues")]
    [SerializeField] float ratio = 40f; //�����������
    [SerializeField] float ratioForDelta = 43.5f; //
    [SerializeField] float downStatsY = 322f;

    //public values
    public RectTransform Background { get => background.GetComponent<RectTransform>(); }

    private void Start()
    {
        EventController.SwitchMenu += Destroy;
    }

    private void Instantiate()
    {
        SetScale();
    }

    public void SetActiveBackground(bool value)
    {
        background.SetActive(value);
    }

    public void SetScale()
    {
        float delta = skillDescText.preferredHeight / ratioForDelta;
        Vector2 deltaVector = new Vector2(0, delta * ratio);

        background.GetComponent<RectTransform>().sizeDelta += deltaVector;

        downStats.transform.localPosition = new Vector3(downStats.transform.localPosition.x, downStatsY);
        downStats.transform.localPosition -= new Vector3(deltaVector.x, deltaVector.y);
        toolTip.transform.position = new Vector3(toolTip.transform.position.x, skillActionPointText.transform.position.y - 40f);
    }

    private void OnDestroy()
    {
        EventController.SwitchMenu -= Destroy;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void SetSkillInPanel(SkillSO skill) //��������� �������� ������ � ������
    {
        skillNameText.text = skill.skillName;
        skillDescText.text = skill.skillDesc;
        skillIcon.sprite = skill.skillIcon;
        skillCooldownText.text = skill.cooldown + " " + Localizator.Localize("Turn");
        skillManaText.text = Localizator.Localize("Mana") + ": " + skill.manaCost;
        skillActionPointText.text = Localizator.Localize("AP") + ": " + skill.actionPointCost;

        if(skill.skillType == SkillType.None)
        {
            skillTypeText.gameObject.SetActive(false);
        }
        else
        {
            skillTypeText.text = Localizator.Localize("Ability") + Localizator.Localize(skill.skillType.ToString());
        }

        if (skill.IsHasSomeSkills)
        {
            toolTip.SetActive(true);
        }
        if (skill.IsDamaging)
        {
            skillDamageTypeText.gameObject.SetActive(true);

            skillDamageTypeText.text = Localizator.Localize("DamageType");
            foreach(var damageType in skill.damageType)
            {
                skillDamageTypeText.text += " "+ IconLoader.LoadSmile(damageType) + Localizator.Localize(damageType.ToString());
            }
        }

        Instantiate();
    }


    #region SetSkillInPanel overrides
    public void SetSkillInPanel(SkillSO skill,Canvas canvas)
    {
        SetSkillInPanel(skill);
        gameObject.transform.SetParent(canvas.transform, false);   
    }
    public void SetSkillInPanel(SkillSO skill,Transform icon, Canvas canvas, float yOffset)
    {
        SetSkillInPanel(skill,canvas);
        transform.position = icon.position - new Vector3(0, yOffset, 0);
    }
    
    public void SetSkillInPanel(SkillSO skill, Transform parent ,float yOffset)
    {
        SetSkillInPanel(skill);
        transform.position = parent.position - new Vector3(0, yOffset, 0);
    }
    #endregion

 
}
