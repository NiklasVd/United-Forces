using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MovableActor : Actor
{
    public bool isDead;
    public int baseMaxHealth, baseMovementSpeed;
    public Dictionary<AttributeType, int> attributes;
    public List<ActorAudioItem> audioItems;
    
    public WeaponItem weaponSlot;
    public ThrowableItem throwableSlot;
    public InteractionItem interactionSlot1, interactionSlot2;

    public Item currentSlotItem;
    public GameObject currentSlotGameObject;

    // References
    public AudioSource audioSource;
    public Transform weaponTransform, weaponRecoilTransform;

    protected override void Awake()
    {
        Initialize();
        base.Awake();
    }

    public void PlayAudio(ActorAudioItem item)
    {
        audioSource.PlayOneShot(item.audioClip);
    }
    public void ReceiveDamage(int damage, Actor damagedealer)
    {
        attributes[AttributeType.CurrentHealth] -= damage;
        CheckDeathState();
    }
    public void SetCurrentSlot(Item slot)
    {
        currentSlotItem = slot;

        Destroy(currentSlotGameObject);
        if(currentSlotItem != null)
        {
            currentSlotGameObject = (GameObject)Instantiate(currentSlotItem.itemObject);
        }
    }

    private void Initialize()
    {
        attributes = new Dictionary<AttributeType, int>();
        attributes.Add(AttributeType.CurrentHealth, baseMaxHealth);
        attributes.Add(AttributeType.MaxHealth, baseMaxHealth);
        attributes.Add(AttributeType.MovementSpeed, baseMovementSpeed);
    }
    private void CheckDeathState()
    {
        if (attributes[AttributeType.CurrentHealth] <= 0)
        {
            attributes[AttributeType.CurrentHealth] = 0;
            isDead = true;
        }
    }
}

[Serializable]
public enum AttributeType
{
    CurrentHealth,
    MaxHealth,
    MovementSpeed
}
[Serializable]
public class ActorAudioItem
{
    public static List<ActorAudioItem> actorAudioItems = new List<ActorAudioItem>()
    {
        new ActorAudioItem("Civilian Scream 1", ResourceManager.Instance.GetAudioClip("Civilian Scream 1")),
        new ActorAudioItem("Civilian Scream 2", ResourceManager.Instance.GetAudioClip("Civilian Scream 2"))

        // TODO: Add more default audio items
    };

    public string name;
    public AudioClip audioClip;

    private ActorAudioItem(string name, AudioClip audioclip)
    {
        this.name = name;
        this.audioClip = audioclip;
    }
}
