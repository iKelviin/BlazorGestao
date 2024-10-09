namespace Gestao.Domain;

public class Documents
{
    public int Id { get; set; }
    public string Path { get; set; } = null!;

    public int?  FinancialTransactionId { get; set; }
    public FinancialTransaction? FinancialTransaction { get; set; }
}
