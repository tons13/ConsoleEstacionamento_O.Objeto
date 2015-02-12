Public Interface IEstacionamento

    Sub Inicio()

    Sub Entrada(ByVal placa As String)

    Sub Saida(ByVal placa As String)

    Sub ListaEstacionamento()

    Sub ListaSaidaEstacionamento()

    Property Estacionamento As List(Of VEICULOS_PM)

    Property RetornaEntrada As DateTime

    Property RetornaSaida As DateTime

    Property Valor As Decimal

    Property placa() As String

    Property RetornaPlaca As String

    Property Opcaostring As String

    Property Opcao As Integer


End Interface

