Module Module1

    Sub Main()
        Console.WriteLine("Entre com seu primeiro nome: ")
        Dim nome As String = Console.ReadLine
        Console.WriteLine("Entre com seu segundo nome: ")
        Dim sobrenome As String = Console.ReadLine
        Console.WriteLine("Entre com a sua idade: ")
        Dim idade As Integer = Console.ReadLine
        Dim pessoa = New Pessoa(nome, sobrenome, idade)
        Console.ReadKey()
    End Sub

End Module
