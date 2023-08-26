using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class EntityScreen : MonoBehaviour
{
    //������ ������ �����

    [Header("\t\t   General")]
    [SerializeField] Image entityIcon;
    [SerializeField] Image entityConceptSprite;
    [SerializeField] TextMeshProUGUI heroNameText;
    [SerializeField] TextMeshProUGUI elementEntityText;
    [SerializeField] public Image iconAbillityPrefab;
    [SerializeField] public RectTransform summonContentPrefab; 
    [SerializeField] public RectTransform contentField;
    [SerializeField] public Canvas canvasForSpells;
    [Header("\t\tAttack/Weapon")]
    [SerializeField] TextMeshProUGUI typeAttackText;
    [SerializeField] TextMeshProUGUI elementAttackText;
    [SerializeField] TextMeshProUGUI weaponText;
    [SerializeField] TextMeshProUGUI weaponTypeText;
    [SerializeField] Image attackIcon;

    private void Start()
    {
        EventController.SwitchMenu += SetNormalScale;
    }

    public void CreateEntity(EntitySO entity, Transform parent, float yCoordinate)
    {
        //
        // ������� ������ ��� ����������� ����������� ������� ������������
        Canvas canvas = Instantiate(canvasForSpells, parent);
        //

        entityIcon.sprite = entity.icon;
        heroNameText.text = entity.entityName;

        entityConceptSprite.sprite = entity.concept;

        elementEntityText.text = IconLoader.LoadSmile(entity.generalElement) + Localizator.Localize(entity.generalElement.ToString());

        typeAttackText.text = Localizator.Localize("TypeAttack") + IconLoader.LoadSmile(entity.typeAttack) + Localizator.Localize(entity.typeAttack.ToString());

        weaponText.text = Localizator.Localize("WeaponText") + Localizator.Localize(entity.weapon.ToString());
        weaponTypeText.text = Localizator.Localize("WeaponType") + Localizator.Localize(entity.weaponType.ToString());
        attackIcon.sprite = IconLoader.LoadIcon(entity.weapon);

        elementAttackText.text = Localizator.Localize("ElementOfAttack") + IconLoader.LoadSmile(entity.attackElement) + Localizator.Localize(entity.attackElement.ToString());


        for (int skillId = 0; skillId < entity.skills.Length; skillId++) //������ ������ ������������ � ����������� �� �� ����������
        {
            CreateSpell(entity.skills, skillId, yCoordinate, parent, canvas);
        }

        yCoordinate -= 300;

        for (int skillId = 0; skillId < entity.nonCombatSkills.Length; skillId++) //������ ������ �� ������ ������������ � ����������� �� �� ����������
        {
            CreateSpell(entity.nonCombatSkills, skillId, yCoordinate, parent, canvas);
        }
    }

    public virtual void CreateHero(HeroSO hero)
    {
        float posY = -1117f;
        CreateEntity(hero, contentField.transform, posY);        
    }

    public void CreateSpell(SkillSO[] skills, int skillId, float yCoordinate, Transform parent, Canvas canvas) //������� ������ ������������ �����
    {
        Image gate;
        gate = Instantiate(iconAbillityPrefab, gameObject.transform);
        gate.rectTransform.SetParent(parent, false);
        gate.GetComponent<SkillGate>().skill = skills[skillId];
        gate.GetComponent<SkillGate>().canvasForSkillPanel = canvas;
        if(skills[skillId].IsHasSummons)
        {
            List<SummonSO> summons = new List<SummonSO>();
            summons = skills[skillId].summon;
            foreach (var summon in summons)
            {
                CreateSummon(summon);
            }
        }
        gate.sprite = gate.GetComponent<SkillGate>().skill.skillIcon;
        gate.transform.localPosition = CalcCoordForSpell(skills.Length, skillId, yCoordinate);
                
    }

    private void CreateSummon(SummonSO summon) 
    {
        float posY = -1000;
        RectTransform summonContent;
        summonContent = Instantiate(summonContentPrefab, contentField);
        contentField.sizeDelta += new Vector2(0, 1300);
        summonContent.transform.localPosition = new Vector2(0, EventController.yForSummonsContentfield);

        summonContent.GetComponent<SummonScreen>().CreateEntity(summon,summonContent,posY);

        EventController.yForSummonsContentfield -= EventController.deltaForY; // ���������� Y ��� ����������� ������� ��������
    }

    private Vector2 CalcCoordForSpell(int numberOfAbilities, int spellNumber, float posY)
    {
        #region Magic Numbers
        float startX = 950f;
        float deltaForStartCoord = 91.7f;
        float offsetX = 170f;
        float numberOfSpells = numberOfAbilities - 1;

        float deltaX = offsetX * spellNumber;
        float posX = startX - (numberOfSpells * deltaForStartCoord);
        #endregion

        return new Vector2(posX + deltaX, posY);
    }

    private void SetNormalScale() //���������� ����������� ����� ��� contentField
    {
        contentField.sizeDelta = new Vector2 (0, 2000);
    }

    private void OnDestroy()
    {
        EventController.SwitchMenu -= SetNormalScale;
    }


}
