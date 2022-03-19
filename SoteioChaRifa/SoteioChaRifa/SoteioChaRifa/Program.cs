Random random = new Random();
Dictionary<int, string> participantes = new Dictionary<int, string>();
KeyValuePair<int, string> PrimeiroLugar = new KeyValuePair<int, string>();
KeyValuePair<int, string> SegundoLugar = new KeyValuePair<int, string>();
participantes.Add(1, "Matheus Condominio");
participantes.Add(2, "Tia Irene");
participantes.Add(3, "Victor Condominio");
participantes.Add(4, "Rafa Rio");
participantes.Add(6, "Marcelo Coiote");
participantes.Add(7, "Kaka Polyana");
participantes.Add(8, "Maira Condominio");
participantes.Add(9, "Leomar");
participantes.Add(10, "Levindo");
participantes.Add(11, "Tia Marli");
participantes.Add(12, "Samuel Paradise in Flames");
participantes.Add(13, "Matheus Condominio");
participantes.Add(14, "Roger");
participantes.Add(15, "Victor Condominio");
participantes.Add(17, "Elissany Dupla Polyana");
participantes.Add(18, "Gabriel Usiminas");
participantes.Add(19, "Fernanda Prima Polyana");
participantes.Add(20, "Chris Marcelo");
participantes.Add(21, "Leomar");
participantes.Add(22, "Ricardinho Sequoia");
participantes.Add(23, "Pollyanna FEAD");
participantes.Add(25, "Leandro Usiminas");
participantes.Add(26, "Tio Euler");
participantes.Add(27, "Renatinho Marcelo");
participantes.Add(28, "Matheus Condominio");
participantes.Add(29, "Carla Ivory");
participantes.Add(30, "Mateus Usiminas");
participantes.Add(31, "Karine Brecho");
participantes.Add(33, "Pablo Condominio");
participantes.Add(34, "Cida Polyana");
participantes.Add(35, "Matheus Condominio");
participantes.Add(36, "Thais Rio");
participantes.Add(37, "Levindo");
participantes.Add(39, "Priscila Fead");
participantes.Add(41, "Tia Nana");
participantes.Add(42, "Victor Condominio");
participantes.Add(43, "Priscila Pos Polyana");
participantes.Add(44, "Leomar");
participantes.Add(45, "Alexandre Polyana");
participantes.Add(46, "Patricia Condominio");
participantes.Add(47, "Alexandre Polyana");
participantes.Add(48, "Matheus Condominio");
participantes.Add(49, "Tuquinha");
participantes.Add(50, "Adriane tio Euler");
participantes.Add(51, "Matheus Condominio");
participantes.Add(54, "Ricardinho Sequoia");
participantes.Add(56, "Priscila Pos Polyana");
participantes.Add(59, "Victor Condominio");
participantes.Add(60, "Tio Claudio");
participantes.Add(61, "Fernanda Amiga Polyana");
participantes.Add(63, "Leomar");
participantes.Add(66, "Matheus Condominio");
participantes.Add(67, "Patricia Condominio");
participantes.Add(69, "Mateus Sequoia");
participantes.Add(70, "Mateus Sequoia");
participantes.Add(71, "Tia Nana");
participantes.Add(74, "Carla Ivory");
participantes.Add(75, "Tio Claudio");
participantes.Add(77, "Victor Condominio");
participantes.Add(79, "Matheus Condominio");
participantes.Add(82, "Leomar");
participantes.Add(83, "Tia Marines");
participantes.Add(85, "Matheus Condominio");
participantes.Add(87, "Josy Prima");
participantes.Add(88, "Ricardinho Sequoia");
participantes.Add(89, "Maria Thereza Pos Polyana");
participantes.Add(93, "Matheus Condominio");
participantes.Add(100, "Tia Irene");
var tamanho = participantes.Count();

for (int i = 0; i < tamanho; i++)
{
    int sorteio1 = random.Next(participantes.Count);
    int sorteio2 = random.Next(participantes.Count);

    PrimeiroLugar = participantes.ElementAt(sorteio1);
    SegundoLugar = participantes.ElementAt(sorteio2);    
    int contagem = i;
    if (contagem == 1)
    {
        break;
    }
}

Console.WriteLine($"Primeiro Lugar: Nome: {PrimeiroLugar.Value}. Número: {PrimeiroLugar.Key} \nSegundo Lugar: Nome: {SegundoLugar.Value}. Número: {SegundoLugar.Key}");
Console.WriteLine("Obrigado por participarem!");

Console.ReadKey();