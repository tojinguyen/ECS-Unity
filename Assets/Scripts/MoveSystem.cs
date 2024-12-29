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
        var unitMoverJob = new UnitMoverJob() { DeltaTime = SystemAPI.Time.DeltaTime };
        unitMoverJob.ScheduleParallel();
    }
}

[BurstCompile]
internal partial struct UnitMoverJob : IJobEntity
{
    public float DeltaTime;

    private void Execute(ref LocalTransform localTransform, in MoveSpeedCompData moveSpeed, ref PhysicsVelocity velocity)
    {
        var targetPosition = localTransform.Position + new float3(10, 0, 0);
        var moveDirection = math.normalize(targetPosition - localTransform.Position);
            
        localTransform.Rotation = quaternion.LookRotationSafe(moveDirection, math.up());
        velocity.Linear = moveDirection * moveSpeed.Value * DeltaTime;
        velocity.Angular = float3.zero;
    }
}
