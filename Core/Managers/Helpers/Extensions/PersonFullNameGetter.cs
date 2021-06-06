using Model.Models;

namespace Core.Managers.Helpers.Extensions
{
    public static class PersonFullNameGetter
    {
        public static string GetFullName(this Person person)
        {
            string firstName = string.Empty;
            string middleName = string.Empty;
            string lastName = string.Empty;

            if (person.FirstName != null)
                firstName = person.FirstName;
            if (person.MiddleName != null)
                middleName = person.MiddleName;
            if (person.LastName != null)
                lastName = person.LastName;

            return middleName + " " + firstName + " " + lastName;
        }
    }
}
