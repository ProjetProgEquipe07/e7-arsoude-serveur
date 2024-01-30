namespace arsoudeServeur.Services.Interfaces
{
    public interface IEmailService
    {
        Task EnvoiEmailAsync(string email, string subject, string message);
    }
}
