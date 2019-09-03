using System;

public interface IEquipment
{
    event Action<object> OnEquipCallback;
    void Equip(object equipmentPiece);
    void Add(object equipmentPiece);
    void Remove(object equipmentPiece);
}
