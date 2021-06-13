namespace Calculator.Core.Dtos
{
    public record CalculateDto(string Operator, int num1, int num2);

    public record ExecuteDto(int num1, int num2);
}
