using System;

namespace RedisSample.GetAndSetComplexValue
{
    public class Client
    {
        private const string template = "CPF: {0} - Name: {1} - Birth: {2}";
        public string Cpf { get; private set;}
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public Client(string cpf) => Cpf = cpf;

        public override string ToString() => string.Format(template, Cpf, Name, Birth.ToString("dd/MM/yyyy"));
    }
}