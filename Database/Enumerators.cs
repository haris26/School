using System.Security.Cryptography;

namespace Database
{
// Workforce Roster

    public enum EmploymentType
    {
        Full = 1,
        Part = 2,
        Student = 3
    }

    public enum EmploymentStatus
    {
        Active = 1,
        Leaver = 2,
        ComingSoon = 3
    }

    public enum Gender
    {
        Female = 1,
        Male = 2
    }

    public enum ProjectType
    {
        External = 1,
        Internal = 2,
        Absence = 3
    }

// Skills Library

    public enum EducationType
    {
        School = 1,
        Course = 2,
        Certificate = 3
    }

    public enum Level
    {
        VeryLow = 1,
        BasicCapability = 2,
        Competent = 3,
        DevelopedSkills = 4,
        HighlySkilled = 5
    }

    public enum AssessmentType
    {
        Self = 0,
        Supervisor = 1
    }

    public enum CategoryType
    {
        Skills = 0,
        Educations = 1
    }

// Reservation System

    public enum RepeatType
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3
    }

    public enum ReservationStatus
    {
        Available = 1,
        Reserved = 2
    }

// Procurement System
    
    public enum AssetType
    {
        Device = 1,
        Office = 2
    }

    public enum AssetStatus
    {
        Active = 1,
        ComingSoon = 2,
        OutOfOrder = 3
    }

    public enum HistoryStatus
    {
        Active = 1,
        Inactive = 2
    }

  
    public enum RequestStatus
    {
        AvaitingForApprovale = 1,
        Cancelled = 2,
        Approved = 3,
        Completed = 4,
        InProccess = 5
    }

    public enum RequestType
    {
        Equipment = 1,
        Service = 2
    }
    
// Time Tracking

    public enum EntryStatus
    {
        Unlocked = 1,
        Locked = 2
    }
}
