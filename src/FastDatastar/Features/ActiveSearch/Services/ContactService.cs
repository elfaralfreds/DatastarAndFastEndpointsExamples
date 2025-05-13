using Bogus;
using FastDatastar.Features.ActiveSearch.Dto;

namespace FastDatastar.Features.ActiveSearch.Services;

public class ContactService
{
    public static List<Contact> Contacts { get; internal set; }

    static ContactService()
    {
        Contacts = new Faker<Contact>()
            .RuleFor(u => u.Firstname, f => f.Name.FirstName())
            .RuleFor(u => u.Lastname, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Firstname, u.Lastname))
            .Generate(100);
    }

    public static List<Contact> Search(string? input)
    {
        if (string.IsNullOrEmpty(input))
            return Contacts;

        var search = input.ToLower();

        return Contacts
            .Where(c => c.Firstname.ToLower().Contains(search) || c.Lastname.ToLower().Contains(search) || c.Email.ToLower().Contains(search))
            .ToList();
    }
}