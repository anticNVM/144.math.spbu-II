namespace Source
{
    public enum FieldTypes
    {
        FreeSpace,
        TheWall,
        BeyondMap,
    }

    public interface IMap
    {
        FieldTypes GetFieldTypeOn(Coordinates coordinates);
    }
}