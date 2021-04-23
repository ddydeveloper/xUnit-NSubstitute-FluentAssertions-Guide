using System;

namespace MortgageAdviser.Services
{
    public interface IPersonValidatorService
    {
        bool IsValidPerson();
    }

    public class PersonValidatorService : IPersonValidatorService
    {
        public bool IsValidPerson()
        {
            throw new NotImplementedException();
        }
    }
}