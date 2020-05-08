namespace SchoolLocker.Core.Contracts.Entities
{
    public interface IPupil : IEntityObject
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        string Name { get; }

    }
}
