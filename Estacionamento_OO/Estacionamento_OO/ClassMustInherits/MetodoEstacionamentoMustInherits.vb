Public MustInherit Class MetodoEstacionamentoMustInherits
    Inherits RaisePropertyEvent
    Implements IEstacionamento

    Public MustOverride Sub Inicio() Implements IEstacionamento.Inicio

    Public Sub Entrada(placa As String) Implements IEstacionamento.Entrada

        Console.WriteLine()
        Console.WriteLine("CADASTRO VEÍCULOS.")
        Console.Write("Digite a placa do veículo: ")
        placa = Console.ReadLine()

        Dim query = (From c In Estacionamento Where c.DATA_SAIDA Is Nothing).Count
        If query = 10 Then
            Console.WriteLine("ESTACIONAMENTO LOTADO!")
            Console.ReadLine()

            Console.Clear()
            Inicio()
        End If

        For Each item In (From c In Estacionamento Where c.DATA_SAIDA Is Nothing)
            If item.PLACA = placa Then

                Console.WriteLine()
                Console.WriteLine()
                Console.WriteLine()
                Console.WriteLine()
                Console.WriteLine("PLACA DIGITADA JÁ CONSTA CADASTRADA NO ESTACIONAMENTO!")
                Console.ReadLine()


                Console.Clear()
                Inicio()
            End If
        Next

        Dim newRecord As New VEICULOS_PM
        With newRecord
            .PLACA = placa
            .DATA_ENTRADA = Date.Now
        End With
        Estacionamento.Add(newRecord)
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("VEÍCULO CADASTRADO COM SUCESSO, APERTE QUALQUER TECLA PARA CONTINUAR !")
        Console.ReadLine()

        Console.Clear()
        Inicio()


    End Sub

    Public Sub Saida(placa As String) Implements IEstacionamento.Saida

        Console.Write("Digite a placa do veículo: ")
        placa = Console.ReadLine()

        Dim query = (From c In Estacionamento
                           Where c.PLACA = placa And c.DATA_SAIDA Is Nothing).FirstOrDefault()

        If query Is Nothing Then
            Console.WriteLine("PLACA NÃO CONSTA NO ESTACIONAMENTO!")
            Console.ReadLine()

            Console.Clear()
            Inicio()
        Else
            query.DATA_SAIDA = Date.Now
            RetornaPlaca = query.PLACA
            RetornaEntrada = query.DATA_ENTRADA
            RetornaSaida = Date.Now

            If DateDiff(DateInterval.Hour, query.DATA_ENTRADA, Date.Now) <= 1 Then
                Valor = 10
            Else
                Valor = 15
            End If
            query.VALOR = Valor

        End If

        Console.WriteLine()
        Console.WriteLine(":::::::: SAÍDA DO VEÍCULO REGISTRADA COM SUCESSO ::::::::")
        Console.WriteLine("A placa do veículo: " & RetornaPlaca & "")
        Console.WriteLine("A data e hora de entrada do veículo: " & RetornaEntrada & "")
        Console.WriteLine("A data e hora de saída do veículo: " & RetornaSaida & "")
        Console.WriteLine("Valor cobrado: R$ " & Valor & "")
        Console.ReadLine()

        Console.Clear()
        Inicio()


    End Sub

    Public Sub ListaEstacionamento() Implements IEstacionamento.ListaEstacionamento

        Dim query = (From c In Estacionamento Where c.DATA_SAIDA Is Nothing)
        If query.Count = 0 Then
            Console.WriteLine("NÃO CONSTA VEÍCULOS NO ESTACIONAMENTO")
            Console.ReadLine()

            Console.Clear()
            Inicio()
        End If

        Console.WriteLine()
        Console.WriteLine(":::::::: VÉICULOS QUE ESTÃO NO ESTACIONAMENTO ::::::::")
        Console.WriteLine()

        For Each item In query
            Console.WriteLine("A placa do veículo: " & item.PLACA & "")
            Console.WriteLine("A data e hora de entrada do veículo: " & item.DATA_ENTRADA & "")
            Console.WriteLine()
        Next
        Console.ReadLine()

        Console.Clear()
        Inicio()


    End Sub

    Public Sub ListaSaidaEstacionamento() Implements IEstacionamento.ListaSaidaEstacionamento

        Dim query = (From c In Estacionamento Where c.DATA_SAIDA IsNot Nothing)
        If query.Count = 0 Then
            Console.WriteLine("NÃO CONSTA SAÍDA VEÍCULOS NO ESTACIONAMENTO")
            Console.ReadLine()

            Console.Clear()
            Inicio()
        End If

        For Each item In query
            Console.WriteLine("A placa do veículo: " & item.PLACA & "")
            Console.WriteLine("A data e hora de entrada do veículo: " & item.DATA_ENTRADA & "")
            Console.WriteLine("A data e hora de saída do veículo: " & item.DATA_SAIDA & "")
            Console.WriteLine("Valor Cobrado: " & item.VALOR & "")
            Console.WriteLine()

        Next

        Dim soma = (From c In Estacionamento Select c.VALOR).Sum
        Console.WriteLine("Valor Total: R$ " & soma & "")
        Console.ReadLine()

        Console.Clear()
        Inicio()

    End Sub

    Public MustOverride Property Estacionamento As System.Collections.Generic.List(Of VEICULOS_PM) Implements IEstacionamento.Estacionamento

    Public MustOverride Property Opcao As Integer Implements IEstacionamento.Opcao

    Public MustOverride Property Opcaostring As String Implements IEstacionamento.Opcaostring

    Public MustOverride Property placa As String Implements IEstacionamento.placa

    Public MustOverride Property RetornaEntrada As Date Implements IEstacionamento.RetornaEntrada

    Public MustOverride Property RetornaPlaca As String Implements IEstacionamento.RetornaPlaca

    Public MustOverride Property RetornaSaida As Date Implements IEstacionamento.RetornaSaida

    Public MustOverride Property Valor As Decimal Implements IEstacionamento.Valor

End Class
