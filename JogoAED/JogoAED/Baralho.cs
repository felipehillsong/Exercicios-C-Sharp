using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogoAED
{
    public class Baralho
    {
        public List<Carta> Cartas { get; set; }
        
        public Baralho()
        {
            Carta AsPaus = new Carta("ÁS", "Paus", 1, 1);
            Carta DoisPaus = new Carta("Dois", "Paus", 2, 2);
            Carta TresPaus = new Carta("Três", "Paus", 3, 5);
            Carta QuartroPaus = new Carta("Quatro","Paus", 4, 4);
            Carta CincoPaus = new Carta("Cinco","Paus", 5, 3);
            Carta SeisPaus = new Carta("Seis", "Paus", 6, 3);
            Carta SeteCPaus = new Carta("Sete", "Paus", 7, 7);
            Carta OitoPaus = new Carta("Oito", "Paus", 8, 8);
            Carta NovePaus = new Carta("Nove", "Paus", 9, 7);
            Carta DezPaus = new Carta("Dez", "Paus", 10, 10);
            Carta ValetePaus = new Carta("Valete", "Paus", 11, 11);
            Carta DamaPaus = new Carta("Dama", "Paus", 12, 10);
            Carta ReiPaus = new Carta("Rei", "Paus", 13, 13);

            Carta AsCopas = new Carta("ÁS", "Copas", 1, 2);
            Carta DoisCopas = new Carta("Dois", "Copas", 2, 3);
            Carta TresCopas = new Carta("Três", "Copas", 3, 4);
            Carta QuartroCopas = new Carta("Quatro", "Copas", 4, 4);
            Carta CincoCopas = new Carta("Cinco", "Copas", 5, 2);
            Carta SeisCopas = new Carta("Seis", "Copas", 6, 3);
            Carta SeteCopas = new Carta("Sete", "Copas", 7, 8);
            Carta OitoCopas = new Carta("Oito", "Copas", 8, 7);
            Carta NoveCopas = new Carta("Nove", "Copas", 9, 8);
            Carta DezCopas = new Carta("Dez", "Copas", 10, 10);
            Carta ValeteCopas = new Carta("Valete", "Copas", 11, 12);
            Carta DamaCopas = new Carta("Dama", "Copas", 12, 12);
            Carta ReiCopas = new Carta("Rei", "Copas", 13, 13);

            Carta AsEspada = new Carta("ÀS", "Espada", 1, 3);
            Carta DoisEspada = new Carta("Dois", "Espada", 2, 4);
            Carta TresEspada = new Carta("Três", "Espada", 3, 3);
            Carta QuartroEspada = new Carta("Quatro", "Espada", 4, 4);
            Carta CincoEspada = new Carta("Cinco", "Espada", 5, 4);
            Carta SeisEspada = new Carta("Seis", "Espada", 6, 4);
            Carta SeteEspada = new Carta("Sete", "Espada", 7, 7);
            Carta OitoEspada = new Carta("Oito", "Espada", 8, 6);
            Carta NoveEspada = new Carta("Nove", "Espada", 9, 8);
            Carta DezEspada = new Carta("Dez", "Espada", 10, 10);
            Carta ValeteEspada = new Carta("Valete", "Espada", 11, 10);
            Carta DamaEspada = new Carta("Dama", "Espada", 12, 11);
            Carta ReiEspada = new Carta("Rei", "Espada", 13, 12);

            Carta AsOuro = new Carta("ÁS", "Ouro", 1, 4);
            Carta DoisOuro = new Carta("Dois", "Ouro", 2, 5);
            Carta TresOuro = new Carta("Três", "Ouro", 3, 2);
            Carta QuartroOuro = new Carta("Quatro", "Ouro", 4, 3);
            Carta CincoOuro = new Carta("Cinco", "Ouro", 5, 5);
            Carta SeisOuro = new Carta("Seis", "Ouro", 6, 5);
            Carta SeteOuro = new Carta("Sete", "Ouro", 7, 6);
            Carta OitoOuro = new Carta("Oito", "Ouro", 8, 5);
            Carta NoveOuro = new Carta("Nove", "Ouro", 9, 9);
            Carta DezOuro = new Carta("Dez", "Ouro", 10, 10);
            Carta ValeteOuro = new Carta("Valete", "Ouro", 11, 12);
            Carta DamaOuro = new Carta("Dama", "Ouro", 12, 11);
            Carta ReiOuro = new Carta("Rei", "Ouro", 13, 12);

            Cartas = new List<Carta>();
            Cartas.Add(AsPaus);
            Cartas.Add(DoisPaus);
            Cartas.Add(TresPaus);
            Cartas.Add(QuartroPaus);
            Cartas.Add(CincoPaus);
            Cartas.Add(SeisPaus);
            Cartas.Add(SeteCPaus);
            Cartas.Add(OitoPaus);
            Cartas.Add(NovePaus);
            Cartas.Add(DezPaus);
            Cartas.Add(ValetePaus);
            Cartas.Add(DamaPaus);
            Cartas.Add(ReiPaus);
            Cartas.Add(AsCopas);
            Cartas.Add(DoisCopas);
            Cartas.Add(TresCopas);
            Cartas.Add(QuartroCopas);
            Cartas.Add(CincoCopas);
            Cartas.Add(SeisCopas);
            Cartas.Add(SeteCopas);
            Cartas.Add(OitoCopas);
            Cartas.Add(NoveCopas);
            Cartas.Add(DezCopas);
            Cartas.Add(ValeteCopas);
            Cartas.Add(DamaCopas);
            Cartas.Add(ReiCopas);
            Cartas.Add(AsEspada);
            Cartas.Add(DoisEspada);
            Cartas.Add(TresEspada);
            Cartas.Add(QuartroEspada);
            Cartas.Add(CincoEspada);
            Cartas.Add(SeisEspada);
            Cartas.Add(SeteEspada);
            Cartas.Add(OitoEspada);
            Cartas.Add(NoveEspada);
            Cartas.Add(DezEspada);
            Cartas.Add(ValeteEspada);
            Cartas.Add(DamaEspada);
            Cartas.Add(ReiEspada);
            Cartas.Add(AsOuro);
            Cartas.Add(DoisOuro);
            Cartas.Add(TresOuro);
            Cartas.Add(QuartroOuro);
            Cartas.Add(CincoOuro);
            Cartas.Add(SeisOuro);
            Cartas.Add(SeteOuro);
            Cartas.Add(OitoOuro);
            Cartas.Add(NoveOuro);
            Cartas.Add(DezOuro);
            Cartas.Add(ValeteOuro);
            Cartas.Add(DamaOuro);
            Cartas.Add(ReiOuro);          
            
        }

        public void Embaralhar()
        {
            var embaralhar = new Random();
            var cartas = Cartas.OrderBy(x => embaralhar.Next()).Select(x => x.Face + "\n" + x.Naipe + "\n" + "Peso: " + x.Peso + "\n");
            foreach(var carta in cartas)
            {
                Console.WriteLine(carta);
            }     

            
        } 
        
        
    }
}