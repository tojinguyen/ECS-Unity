using Unity.Entities;
using UnityEngine;

class SelectedAuthoring : MonoBehaviour
{
    class SelectedAuthoringBaker : Baker<SelectedAuthoring>
    {
        public override void Bake(SelectedAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Selected());
            SetComponentEnabled<Selected>(entity, false);
        }
    }
}


public struct Selected : IComponentData, IEnableableComponent
{
}