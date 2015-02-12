Public Class MetodoEstacionamentoInherits
    Inherits MetodoEstacionamentoMustInherits


    Public Overrides Sub Inicio()

        Console.WriteLine(":::::::: Seja Bem Vindo ao Estacionamento Orientado a Objeto ::::::::")
        Console.WriteLine("Digite 1 para entrada de veículos ou 2 para saída de veiculos e 3 para visualizar veículos no estacionamento.")
        Console.WriteLine()

        Console.WriteLine("DIGITE 1 PARA ENTRADA DE VEÍCULOS. ")
        Console.WriteLine("DIGITE 2 PARA SAÍDA DE VEÍCULOS. ")
        Console.WriteLine("DIGITE 3 PARA VISUALIZAR VEÍCULOS NO ESTACIONAMENTO. ")
        Console.WriteLine("DIGITE 4 PARA VISUALIZAR VEÍCULOS QUE SAÍRAM DO ESTACIONAMENTO. ")
        Console.WriteLine()

        Console.Write("DIGITE A OPÇÃO: ")

        Opcaostring = Console.ReadLine()

        If Not Integer.TryParse(Opcaostring, Opcao) Then
            MsgBox("DIGITE AS OPÇÕES DISPONIVEIS (1,2,3,4)")
            Console.Clear()
            Inicio()
        Else
            Opcao = Opcaostring
        End If

        If Opcao = 1 Then
            Entrada(placa)
        End If

        If Opcao = 2 Then
            Saida(placa)
        End If

        If Opcao = 3 Then
            ListaEstacionamento()
        End If

        If Opcao = 4 Then
            ListaSaidaEstacionamento()
        End If

    End Sub

    Private _Estacionamento As New List(Of VEICULOS_PM)
    Public Overrides Property Estacionamento As System.Collections.Generic.List(Of VEICULOS_PM)
        Get
            Return _Estacionamento
        End Get
        Set(value As System.Collections.Generic.List(Of VEICULOS_PM))
            _Estacionamento = value
            RaisePropertyChanged("Estacionamento")
        End Set
    End Property

    Private _Opcao As Integer
    Public Overrides Property Opcao As Integer
        Get
            Return _Opcao
        End Get
        Set(value As Integer)
            _Opcao = value
            RaisePropertyChanged("Opcao")
        End Set
    End Property

    Private _Opcaostring As String
    Public Overrides Property Opcaostring As String
        Get
            Return _Opcaostring
        End Get
        Set(value As String)
            _Opcaostring = value
            RaisePropertyChanged("Opcaostring")
        End Set
    End Property

    Private _placa As String
    Public Overrides Property placa As String
        Get
            Return _placa
        End Get
        Set(value As String)
            _placa = value
            RaisePropertyChanged("placa")
        End Set
    End Property

    Private _RetornaEntrada As Date
    Public Overrides Property RetornaEntrada As Date
        Get
            Return _RetornaEntrada
        End Get
        Set(value As Date)
            _RetornaEntrada = value
            RaisePropertyChanged("RetornaEntrada")
        End Set
    End Property

    Private _RetornaPlaca As String
    Public Overrides Property RetornaPlaca As String
        Get
            Return _RetornaPlaca
        End Get
        Set(value As String)
            _RetornaPlaca = value
            RaisePropertyChanged("RetornaPlaca")
        End Set
    End Property

    Private _RetornaSaida As Date
    Public Overrides Property RetornaSaida As Date
        Get
            Return _RetornaSaida
        End Get
        Set(value As Date)
            _RetornaSaida = value
            RaisePropertyChanged("RetornaSaida")
        End Set
    End Property

    Private _Valor As Decimal
    Public Overrides Property Valor As Decimal
        Get
            Return _Valor
        End Get
        Set(value As Decimal)
            _Valor = value
            RaisePropertyChanged("Valor")
        End Set
    End Property

 
End Class
