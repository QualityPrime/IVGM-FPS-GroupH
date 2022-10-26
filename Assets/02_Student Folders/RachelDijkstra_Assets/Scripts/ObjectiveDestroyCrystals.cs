using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveDestroyCrystals : MonoBehaviour
{
    [Tooltip("Chose whether you need to kill every enemies or only a minimum amount")]
    public bool mustKillAllEnemies = true;
    [Tooltip("This is the amount of crystal kills required")]
    public int killsToCompleteObjective = 3;

    public GameObject crystal1;
    public GameObject crystal2;
    public GameObject crystal3;
    bool destroyed1;
    bool destroyed2;
    bool destroyed3;
    bool firstFrame;
    Objective m_Objective;
    int m_KillTotal;

    void Start()
    {
        m_Objective = GetComponent<Objective>();
        DebugUtility.HandleErrorIfNullGetComponent<Objective, ObjectiveKillEnemies>(m_Objective, this, gameObject);

        killsToCompleteObjective = 3;

        // set a title and description specific for this type of objective, if it hasn't one
        if (string.IsNullOrEmpty(m_Objective.title))
            m_Objective.title = "Deactivate enemy shield";

        if (string.IsNullOrEmpty(m_Objective.description))
            m_Objective.description = GetUpdatedCounterAmount();

        destroyed1 = false;
        destroyed2 = false;
        destroyed3 = false;
        firstFrame = true;

        m_KillTotal = 0;
    }

    void Update()
    {
        if (m_Objective.isCompleted)
            return;
        if (firstFrame)
        {
            firstFrame = false;
            string notificationText = string.Empty;
            m_Objective.UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
        }

        if (!destroyed1 && crystal1 == null)
        {
            destroyed1 = true;
            m_KillTotal++;
            if(m_KillTotal == 2)
            {
                string notificationText = "Only one crystal left";
                m_Objective.UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
            }
            else
            {
                string notificationText = string.Empty;
                m_Objective.UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
            }
        }
        if (!destroyed2 && crystal2 == null)
        {
            destroyed2 = true;
            m_KillTotal++;
            if (m_KillTotal == 2)
            {
                string notificationText = "Only one crystal left";
                m_Objective.UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
            }
            else
            {
                string notificationText = string.Empty;
                m_Objective.UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
            }
        }
        if (!destroyed3 && crystal3 == null)
        {
            destroyed3 = true;
            m_KillTotal++;
            if (m_KillTotal == 2)
            {
                string notificationText = "Only one crystal left";
                m_Objective.UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
            }
            else
            {
                string notificationText = string.Empty;
                m_Objective.UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
            }
        }

        if(m_KillTotal == 3)
        {
            m_Objective.CompleteObjective(string.Empty, GetUpdatedCounterAmount(), "Objective complete : " + m_Objective.title);
        }

    }

    string GetUpdatedCounterAmount()
    {
        return m_KillTotal + " / " + killsToCompleteObjective;
    }
}
