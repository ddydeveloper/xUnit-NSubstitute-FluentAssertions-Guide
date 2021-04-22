using System;

namespace MortgageAdviser.Services
{
    public interface IPersonValidator
    {
        bool IsValidPerson();
    }

    public class PersonValidator : IPersonValidator
    {
        public bool IsValidPerson()
        {
            throw new NotImplementedException();
        }
    }
}