Public Class Pessoa
    Private Nome As String
    Private Sobrenome As String
    Private Idade As Integer

    Public Property NomePessoa() As String
        Get
            Return Nome
        End Get
        Set(ByVal Value As String)
            Nome = Value
        End Set
    End Property

    Public Property SobrenomePessoa() As String
        Get
            Return Sobrenome
        End Get
        Set(ByVal Value As String)
            Sobrenome = Value
        End Set
    End Property

    Public Property IdadePessoa() As Integer
        Get
            Return Idade
        End Get
        Set(ByVal Value As Integer)
            Idade = Value
        End Set
    End Property

    Public Sub New(ByVal nome As String, ByVal sobrenome As String, ByVal idade As Integer)
        NomePessoa = nome
        SobrenomePessoa = sobrenome
        IdadePessoa = idade
        Console.WriteLine($"Meu nome é {NomePessoa}, meu sobrenome é {SobrenomePessoa} e tenho {IdadePessoa} anos!")
    End Sub
End Class
