using System.Security.Cryptography;

namespace Database
{
    public enum Employment
    {
        Full = 1,
        Part = 2,
        Student = 3
    }

    public enum AssetType
    {
        IT = 1,
        Office = 2
    }

    public enum Gender
    {
        Female = 1,
        Male = 2
    }

    public enum Status
    {
        Active = 1,
        Leaver = 2,
        ComingSoon = 3
    }

    public enum Project
    {
        External = 1,
        Internal = 2,
        Absence = 3
    }

    public enum ResourceType
    {
        Devices = 1,
        Rooms = 2
    }

    public enum Type
    {
        daily = 1,
        weekly = 2,
        monthly = 3
    }

    public enum EntryStatus
    {
        Unlocked = 1,
        Locked = 2
    }

<<<<<<< HEAD
    public enum EducationType
    {
        School = 1,
        Course = 2,
        Certificate = 3
=======
    public enum ReservationStatus
    {
        Available = 1,
        Reserved = 2    
>>>>>>> 96b8f1ddccaa828f263a98f4100c79502cea3156
    }

}
