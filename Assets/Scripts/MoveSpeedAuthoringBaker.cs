using Unity.Entities;

public class MoveSpeedAuthoringBaker : Baker<MoveSpeedAuthoring>
{
    public override void Bake(MoveSpeedAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic); // Lấy Entity từ GameObject
        AddComponent(entity, new MoveSpeedCompData() { Value = authoring.Value }); // Thêm Component với giá trị từ MoveSpeedAuthoring
    }
}
