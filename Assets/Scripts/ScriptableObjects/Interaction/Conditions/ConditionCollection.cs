using System.Linq;
using UnityEngine;

public class ConditionCollection : ScriptableObject
{
    public string description;
    public Condition[] requiredConditions = new Condition[0];
    public ReactionCollection reactionCollection;


    public bool CheckAndReact()
    {
        if (requiredConditions.Any(rc => !AllConditions.CheckCondition (rc)))
        {
            return false;
        }

        if(reactionCollection)
            reactionCollection.React();

        return true;
    }
}