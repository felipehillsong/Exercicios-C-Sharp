using System.Collections.Generic;

namespace MeuAcerto.Selecao.KataGildedRose
{
    class GildedRose
    {
        IList<Item> Itens;
        public GildedRose(IList<Item> Itens)
        {
            this.Itens = Itens;
        }

        public void AtualizarQualidade()
        {
            for (var i = 0; i < Itens.Count; i++)
            {
                if (Itens[i].Nome != "Queijo Brie Envelhecido" && Itens[i].Nome != "Ingressos para o concerto do Turisas" && Itens[i].Nome != "Bolo de Mana Conjurado")
                {
                    if (Itens[i].Qualidade > 0)
                    {
                        if (Itens[i].Nome != "Dente do Tarrasque")
                        {
                            if (Itens[i].Qualidade > 50)
                            {
                                System.Console.WriteLine("Qualidade passou dos 50");
                            }
                            else if (Itens[i].Qualidade <= 0)
                            {
                                System.Console.WriteLine("Qualidade não pode ser negativa");
                            }
                            else
                            {
                                Itens[i].Qualidade = Itens[i].Qualidade - 1;
                            }
                        }
                        else
                        {
                            Itens[i].Qualidade = 80;
                        }
                    }
                }
                else
                {
                    if (Itens[i].Qualidade < 50)
                    {
                        Itens[i].Qualidade = Itens[i].Qualidade + 1;

                        if (Itens[i].Nome == "Ingressos para o concerto do Turisas")
                        {
                            if (Itens[i].PrazoParaVenda < 11)
                            {
                                if (Itens[i].Qualidade < 50)
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade + 1;
                                }
                                else
                                {
                                    System.Console.WriteLine("Qualidade passou dos 50");
                                }
                            }

                            if (Itens[i].PrazoParaVenda < 6)
                            {
                                if (Itens[i].Qualidade < 50)
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade + 1;
                                }
                                else
                                {
                                    System.Console.WriteLine("Qualidade passou dos 50");
                                }
                            }
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Qualidade passou dos 50");
                    }
                }

                if (Itens[i].Nome != "Dente do Tarrasque" && Itens[i].Nome != "Bolo de Mana Conjurado")
                {
                    Itens[i].PrazoParaVenda = Itens[i].PrazoParaVenda - 1;
                }

                if (Itens[i].PrazoParaVenda < 0)
                {
                    if (Itens[i].Nome != "Queijo Brie Envelhecido" && Itens[i].Nome != "Bolo de Mana Conjurado")
                    {
                        if (Itens[i].Nome != "Ingressos para o concerto do Turisas")
                        {
                            if (Itens[i].Qualidade > 0)
                            {
                                if (Itens[i].Nome != "Dente do Tarrasque")
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade - 1;
                                }
                            }
                        }
                        else
                        {
                            Itens[i].Qualidade = Itens[i].Qualidade - Itens[i].Qualidade;
                        }
                    }
                    else
                    {
                        if (Itens[i].Qualidade < 50)
                        {
                            Itens[i].Qualidade = Itens[i].Qualidade + 1;
                        }
                        else
                        {
                            System.Console.WriteLine("Qualidade passou dos 50");
                        }
                    }
                }

                if (Itens[i].Nome == "Bolo de Mana Conjurado")
                {
                    Itens[i].Qualidade = Itens[i].Qualidade - 2;
                }
            }
        }
    }
}
