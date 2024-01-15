using LicenceStore.Domain.Exceptions;

namespace LicenceStore.Application.Common.Exceptions;

public class ValidationException : BaseException
{
    public ValidationException(IDictionary<string, string[]> failures) : base("One or more validation failures have occurred.",
        failures)
    {
    }
}
