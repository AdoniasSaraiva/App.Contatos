namespace App.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    public string CriadoPor { get; protected set; }

    public DateTime CriadoEm { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        CriadoPor = "Application";
        CriadoEm = DateTime.UtcNow;
    }
}