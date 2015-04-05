using UnityEngine;
using System.Collections;
using System;

public class WeaponAttachmentItem : Item
{
    public WeaponAttachmentType type;
}

[Serializable]
public enum WeaponAttachmentType
{
    Sight,
    MuzzleExtension,
    BodyExtension
}
