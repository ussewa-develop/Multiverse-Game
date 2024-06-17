using Mono.Cecil;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class EntityScreen : MonoBehaviour
{
    //скрипт экрана героя

    [Header("\t\t\tGeneral")]
    [SerializeField] private Image entityIcon;
    [SerializeField] private Image entityConceptSprite;
    [SerializeField] private TextMeshProUGUI heroNameText;
    [SerializeField] private TextMeshProUGUI raceEntityText;
    [SerializeField] private TextMeshProUGUI combatSkillText;
    [SerializeField] private TextMeshProUGUI nonCombatSkillsText;
    [SerializeField] protected RectTransform contentField;
    [Space]
    [Header("\t\tAttack/Weapon")]
    [SerializeField] private TextMeshProUGUI typeAttackText;
    [SerializeField] private TextMeshProUGUI elementAttackText;
    [SerializeField] private TextMeshProUGUI weaponText;
    [SerializeField] private TextMeshProUGUI weaponTypeText;
    [SerializeField] private Image attackIcon;
    [Space]
    [Header("\t\t\tPrefabs")]
    [SerializeField] private Canvas canvasForSpells;
    [SerializeField] private RectTransform summonContentPrefab; 
    [SerializeField] private Image iconAbillityPrefab;
    [SerializeField] private SkillSO emptySkill;

    //public values
    public RectTransform ContentField { get => contentField; }

    private void Start()
    {
        EventController.SwitchMenu += SetNormalScale;
    }

    public Canvas CreateCanvasForSpells(Transform parent)
    {
        return Instantiate(canvasForSpells, parent);
    }

    public void CreateEntity(EntitySO entity, Transform parent)
    {
        //
        // Создаем канвас для нормального отображения панелек способностей
        Canvas canvas = CreateCanvasForSpells(parent);
        //

        entityIcon.sprite = entity.icon;
        heroNameText.text = entity.entityName;

        entityConceptSprite.sprite = entity.concept;

        raceEntityText.text = IconLoader.LoadSmile(entity.race) + entity.race.ToString();

        typeAttackText.text = Localizator.Localize("TypeAttack") + IconLoader.LoadSmile(entity.typeAttack) + Localizator.Localize(entity.typeAttack.ToString());

        weaponText.text = Localizator.Localize("WeaponText") + Localizator.Localize(entity.weapon.ToString());
        weaponTypeText.text = Localizator.Localize("WeaponType") + Localizator.Localize(entity.weaponType.ToString());
        attackIcon.sprite = IconLoader.LoadIcon(entity.weapon);

        elementAttackText.text = Localizator.Localize("ElementOfAttack");
        foreach(Element attackElement in entity.attackElement)
        {
            elementAttackText.text += " " + IconLoader.LoadSmile(attackElement) + Localizator.Localize(attackElement.ToString());
        }

        CreateSpells(combatSkillText.transform, entity.skills, parent, canvas); //создание обычных скиллов

        CreateSpells(nonCombatSkillsText.transform, entity.nonCombatSkills, parent, canvas);//создание небоевых скиллов 
    }

    public virtual void CreateHero(HeroSO hero)
    {
        CreateEntity(hero, contentField.transform);
    }

    public void CreateSpells(Transform position, SkillSO[] skills, Transform parent, Canvas canvas)
    {
        float offset = 150f;
        float yCoordinate = position.localPosition.y - offset;

        if(skills is not null && skills.Length > 0)
        {
            int counter = 0;//переменная для подсчета скиллов, которые не нужно создавать в бестиарии
            foreach(SkillSO skill in skills) //подсчет "не нужных" скиллов в бестиарии
            {
                if(!skill.IsAddedInBestiary)
                {
                    counter++;
                }
            }
            for (int skillId = 0; skillId < skills.Length; skillId++) //создаю иконки способностей в зависимости от их количества
            {
                CreateSpell(skills[skillId], skillId, skills.Length-counter, yCoordinate, parent, canvas);
            }
        }
        else
        {
            CreateSpell(emptySkill, 0, 1, yCoordinate, parent, canvas);
        }
    }


    public void CreateSpell(SkillSO skill, int skillId, int skillsCount ,float yForSkill, Transform parent, Canvas canvas) //создаем иконки способностей героя
    {
        if (!skill.IsAddedInBestiary && skill.IsHasSummons) // если спобность не нужно добавлять в бестиарий, но с нее будет сумон
        {
            List<SummonSO> summons = new List<SummonSO>();
            summons = skill.summon;
            foreach (var summon in summons)
            {
                CreateSummon(summon);
            }
            return;
        }
        Image gate;
        gate = Instantiate(iconAbillityPrefab, gameObject.transform);
        gate.rectTransform.SetParent(parent, false);
        gate.GetComponent<SkillGate>().skill = skill;
        gate.GetComponent<SkillGate>().canvasForSkillPanel = canvas;
        gate.GetComponent<SkillGate>().Instantiate(this);
        if (skill.IsHasSummons)
        {
            List<SummonSO> summons = new List<SummonSO>();
            summons = skill.summon;
            foreach (var summon in summons)
            {
                CreateSummon(summon);
            }
        }
        gate.sprite = gate.GetComponent<SkillGate>().skill.skillIcon;
        gate.transform.localPosition = CalcCoordForSpell(skillsCount, skillId, yForSkill);
        
    }


    private void CreateSummon(SummonSO summon) 
    {
        RectTransform summonContent;
        summonContent = Instantiate(summonContentPrefab, contentField);
        contentField.sizeDelta += new Vector2(0, 1500);
        summonContent.transform.localPosition = new Vector2(0, EventController.yForSummonsContentfield);
        summonContent.GetComponent<SummonScreen>().CreateEntity(summon,summonContent);
        summonContent.GetComponent<SummonScreen>().Instantiate(summonContent);

        EventController.yForSummonsContentfield -= EventController.deltaForY; // координата Y для выставления позиции сумоннов
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

    private void SetNormalScale() //выставляем стандартный скейл для contentField
    {
        contentField.sizeDelta = new Vector2 (0, 2000);
    }

    private void OnDestroy()
    {
        EventController.SwitchMenu -= SetNormalScale;
    }


}
