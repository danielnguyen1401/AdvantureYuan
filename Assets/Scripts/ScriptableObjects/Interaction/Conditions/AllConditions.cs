using UnityEngine;

public class AllConditions : ResettableScriptableObject
{
    public Condition[] conditions;
    private static AllConditions instance;
    private const string loadPath = "AllConditions";

    public static AllConditions Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<AllConditions> ();
            if (!instance)
                instance = Resources.Load<AllConditions> (loadPath);
            if (!instance)
                Debug.LogError ("AllConditions has not been created yet.  Go to Assets > Create > AllConditions.");
            return instance;
        }
        set { instance = value; }
    }


    public override void Reset ()
    {
        if (conditions == null)
            return;

        foreach (var c in conditions)
        {
            c.satisfied = false;
        }
    }

    public static bool CheckCondition (Condition requiredCondition)
    {
        Condition[] allConditions = Instance.conditions;
        Condition globalCondition = null;
        
        if (allConditions != null && allConditions[0] != null)
        {
            foreach (var c in allConditions)
            {
                if (c.hash == requiredCondition.hash)
                    globalCondition = c;
            }
        }

        if (!globalCondition)
            return false;

        return globalCondition.satisfied == requiredCondition.satisfied;
    }
}
