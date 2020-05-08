using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

[System.Serializable]
public class HealthManager
{
    #region Private Properties
#pragma warning disable CS0649
    [Header("Health Settings")]
    [Tooltip("The current health value of this pawn."),
        SerializeField] private float _currentHealth = 100;
    [Tooltip("The maximum health value of this pawn."), 
        SerializeField] private float _maxHealth = 100;

    [Tooltip("An event that notifies listeners when this pawn's current health has changed."),
        Space, SerializeField] private UnityEvent _currentHealthChanged;
    [Tooltip("An event that notifies listeners when this pawn's max health has changed."),
        SerializeField] private UnityEvent _maxHealthChanged;
    [Tooltip("An event that notifies listeners when this pawn has been killed."),
        SerializeField] private UnityEvent _onDead;
#pragma warning restore CS0649
    #endregion

    #region Public Properties
    /// <summary>
    /// The current health value of this pawn.
    /// </summary>
    public float CurrentHealth
    {
        get { return _currentHealth; }
    }

    /// <summary>
    /// The maximum health value of this pawn.
    /// </summary>
    public float MaxHealth
    {
        get { return _maxHealth; }
    }
    #endregion

    /// <summary>
    /// Set the health values of the HealthManager to the specified initial values.
    /// </summary>
    /// <param name="initialValue">The value to initialize the health values to.</param>
    public void InitializeHealthValues(float initialValue)
    {
        _maxHealth = initialValue;
        _maxHealthChanged.Invoke();
        ResetCurrentHealth();
    }

    /// <summary>
    /// Resets the current health value to the max value.
    /// </summary>
    public void ResetCurrentHealth()
    {
        _currentHealth = _maxHealth;
        _currentHealthChanged.Invoke();
    }

    /// <summary>
    /// Adds one or more listeners to the CurrentHealthChanged event.
    /// </summary>
    /// <param name="calls">The names of the functions to call when CurrentHealthChanged is invoked.</param>
    public void AddCurrentHealthListener(params UnityAction[] calls)
    {
        foreach (UnityAction call in calls)
        {
            Events.AddListener(_currentHealthChanged, calls);
        }
    }

    /// <summary>
    /// Removes one or more listeners from the CurrentHealthChanged event.
    /// </summary>
    /// <param name="calls">The names of the functions to remove from the CurrentHealthChanged invoke array.</param>
    public void RemoveCurrentHealthListener(params UnityAction[] calls)
    {
        foreach (UnityAction call in calls)
        {
            Events.RemoveListener(_currentHealthChanged, calls);
        }
    }

    /// <summary>
    /// Adds one or more listeners to the MaxHealthChanged event.
    /// </summary>
    /// <param name="calls">The names of the functions to call when MaxHealthChanged is invoked.</param>
    public void AddMaxHealthListener(params UnityAction[] calls)
    {
        foreach (UnityAction call in calls)
        {
            Events.AddListener(_maxHealthChanged, calls);
        }
    }

    /// <summary>
    /// Removes one or more listeners from the MaxHealthChanged event.
    /// </summary>
    /// <param name="calls">The names of the functions to remove from the MaxHealthChanged invoke array.</param>
    public void RemoveMaxHealthListener(params UnityAction[] calls)
    {
        foreach (UnityAction call in calls)
        {
            Events.RemoveListener(_maxHealthChanged, calls);
        }
    }

    /// <summary>
    /// Adds one or more listeners to the OnDead event.
    /// </summary>
    /// <param name="calls">The names of the functions to call when OnDead is invoked.</param>
    public void AddOnDeadListener(params UnityAction[] calls)
    {
        foreach (UnityAction call in calls)
        {
            Events.AddListener(_onDead, calls);
        }
    }

    /// <summary>
    /// Removes one or more listeners from the OnDead event.
    /// </summary>
    /// <param name="calls">The names of the functions to remove from the OnDead invoke array.</param>
    public void RemoveOnDeadListener(params UnityAction[] calls)
    {
        foreach (UnityAction call in calls)
        {
            Events.AddListener(_onDead, calls);
        }
    }
}
