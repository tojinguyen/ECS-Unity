using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

partial struct MoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var (localTransform, moveSpeed, velocity) in 
                 SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeedCompData>, RefRW<PhysicsVelocity>>())
        {
            var targetPosition = localTransform.ValueRO.Position + new float3(10, 0, 0);
            var moveDirection = math.normalize(targetPosition - localTransform.ValueRO.Position);
            
            localTransform.ValueRW.Rotation = quaternion.LookRotationSafe(moveDirection, math.up());
            velocity.ValueRW.Linear = moveDirection * moveSpeed.ValueRO.Value * deltaTime;
            velocity.ValueRW.Angular = float3.zero;
        }
    }
}
