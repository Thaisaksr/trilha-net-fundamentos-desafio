
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial = 0;
        private decimal _precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        
          public decimal PrecoInicial
    {
        get { return _precoInicial; }
        private set { _precoInicial = value; }
    }

         public decimal PrecoPorHora
    {
        get { return _precoPorHora; }
        private set { _precoPorHora = value; } 
    }
    public Estacionamento(decimal _precoInicial, decimal _precoPorHora)
{

        PrecoInicial = _precoInicial;
        PrecoPorHora = _precoPorHora;
    
}
    
       public void AdicionarVeiculo()
    {
        try
        {
        Console.WriteLine("Digite a placa do veículo para estacionar:(no formato XYZ-1234)");
       
        string placa = Console.ReadLine();
               placa = placa.ToUpper();

        if(placa.Length == 8 && Regex.IsMatch(placa, @"^[A-Za-z]{3}-\d{4}$"))
        {
                veiculos.Add(placa);
                }
        else {
            throw new Exception ("Ocorreu um erro de Digitação");
        }
             
        }
          catch (Exception ex) 
        {
            Console.WriteLine(ex.Message+": O valor de sua placa é inválido, Utilize o formato XYZ-1234" );
         }
    }
    public void RemoverVeiculo()
        {
        Console.WriteLine("Digite a placa do veículo para remover:");
        string placa = Console.ReadLine();
        
        if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine()); 
                decimal valorTotal = 0; 
                valorTotal = (PrecoInicial + PrecoPorHora) * horas;
                
                // Remove a placa digitada da lista de veículos
                
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
        else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                //Realiza um laço de repetição, exibindo os veículos estacionados
                  
                foreach (var placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }   
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
    
        }
    }
}   
