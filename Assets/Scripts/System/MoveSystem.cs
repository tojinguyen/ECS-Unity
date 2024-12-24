using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

partial struct MoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var localTransform in SystemAPI.Query<RefRW<LocalTransform>>())
        {
            localTransform.ValueRW.Position = localTransform.ValueRO.Position + new float3(1, 0, 0) * SystemAPI.Time.DeltaTime;
        }
    }
}