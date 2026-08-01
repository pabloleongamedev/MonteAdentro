using UnityEngine;

namespace MonteAdentro.Systems.Validation.Runtime
{
    public enum ReferenceCriticality
    {
        HardFail,
        SoftFail
    }

    public class RequiredReferenceAttribute : PropertyAttribute
    {
        public ReferenceCriticality Criticality { get; }

        public RequiredReferenceAttribute(ReferenceCriticality criticality = ReferenceCriticality.HardFail)
        {
            Criticality = criticality;
        }
    }
}
