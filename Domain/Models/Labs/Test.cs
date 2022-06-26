namespace Domain.Models.Labs
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float TestCharge { get; set; }
        public virtual ICollection<TestParameterCategorical> CategoricalParamters { get; set; } = new HashSet<TestParameterCategorical>();
        public virtual ICollection<TestParameterNumerical> NumericalParamters { get; set; } = new HashSet<TestParameterNumerical>();

    }
}
