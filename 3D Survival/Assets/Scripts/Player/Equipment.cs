using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent;

    private PlayerController controller;
    private PlayerCondition condition;

    void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
        condition = CharacterManager.Instance.Player.condition;
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && curEquip != null && controller.canLook)
        {
            curEquip.OnAttackInput();
        }
    }

    public void EquipNew(ItemData data)
    {
        UnEquip(data);
        curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<Equip>();
        if(data.type == ItemType.Equipable)
        {
            for(int i=0; i<data.equipables.Length; i++)
            {
                switch (data.equipables[i].type)
                {
                    case EquipableStatType.Speed:
                        //�̵��ӵ� ����
                        controller.moveSpeed += data.equipables[i].value;
                        break;
                    case EquipableStatType.Power: 
                        //���ݷ� ����
                        break;
                    case EquipableStatType.Jump: 
                        //������ ����
                        break;
                    default: 
                        break;
                }
            }
        }
    }

    public void UnEquip(ItemData data)
    {
        if (curEquip != null)
        {
            Destroy(curEquip.gameObject);
            if (data.type == ItemType.Equipable)
            {
                for (int i = 0; i < data.equipables.Length; i++)
                {
                    switch (data.equipables[i].type)
                    {
                        case EquipableStatType.Speed:
                            //�̵��ӵ� ����
                            controller.moveSpeed -= data.equipables[i].value;
                            break;
                        case EquipableStatType.Power:
                            //���ݷ� ����
                            break;
                        case EquipableStatType.Jump:
                            controller.jumpPower -= data.equipables[i].value;
                            //������ ����
                            break;
                        default:
                            break;
                    }
                }
            }
            curEquip = null;
        }
    }
}