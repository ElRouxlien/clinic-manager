using BaseTPFinal2526.Models;
using System.Text.RegularExpressions;

namespace BaseTPFinal2526.Validators
{
    public class PersonsValidator
    {
        protected bool IsValid(Person person)
        {
            return IsFirstNameValid(person.FirstName)
                && IsLastNameValid(person.LastName)
                && IsAddressValid(person.Address)
                && IsPhoneValid(person.PhoneNumber)
                && IsEmailValid(person.Email);
        }

        private bool IsFirstNameValid(string firstName)
        {
            return !string.IsNullOrWhiteSpace(firstName);
        }

        private bool IsLastNameValid(string lastName)
        {
            return !string.IsNullOrWhiteSpace(lastName);
        }

        private bool IsAddressValid(string address)
        {
            return !string.IsNullOrWhiteSpace(address);
        }

        private bool IsPhoneValid(string phone)
        {
            return !string.IsNullOrWhiteSpace(phone);
        }

        private bool IsEmailValid(string email)
        {
            var emailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", RegexOptions.Compiled);

            if (string.IsNullOrWhiteSpace(email))
                return false;

            return emailRegex.IsMatch(email);
        }
    }
}
