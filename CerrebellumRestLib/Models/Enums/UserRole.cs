namespace CerebellumRestLib.Models.Enums
{
    public enum UserRole : byte
    {
        Unknown = 0,
        ClasterInspector = 4,
        ClasterAdmin = 5,
        DepartamentUserExternal = 6,
        DepartamentUser = 7,
        GlobalAdministrator = 8,
        DepartamentAdmin = 10,
        DepartamentInspector = 11,
        GlobalInspector = 12
    }
}