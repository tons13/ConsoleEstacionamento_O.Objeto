Public Class MetodoEstacionamento

    Private Estacionamento As New List(Of VEICULOS_PM)

    Private retornaEntrada, retornaSaida As DateTime

    Private valor As Decimal

    Private placa, retornaPlaca, opcaostring As String

    Dim opcao As Integer


    Public Sub Inicio()

        Console.WriteLine(":::::::: Seja Bem Vindo ao Estacionamento Orientado a Objeto ::::::::")
        Console.WriteLine("Digite 1 para entrada de veículos ou 2 para saída de veiculos e 3 para visualizar veículos no estacionamento.")
        Console.WriteLine()

        Console.WriteLine("DIGITE 1 PARA ENTRADA DE VEÍCULOS. ")
        Console.WriteLine("DIGITE 2 PARA SAÍDA DE VEÍCULOS. ")
        Console.WriteLine("DIGITE 3 PARA VISUALIZAR VEÍCULOS NO ESTACIONAMENTO. ")
        Console.WriteLine("DIGITE 4 PARA VISUALIZAR VEÍCULOS QUE SAÍRAM DO ESTACIONAMENTO. ")
        Console.WriteLine()

        Console.Write("DIGITE A OPÇÃO: ")


        opcaostring = Console.ReadLine()
        If Not Integer.TryParse(opcaostring, opcao) Then
            MsgBox("DIGITE AS OPÇÕES DISPONIVEIS (1,2,3,4)")
            Console.Clear()
            Inicio()

        Else

            opcao = opcaostring

        End If


        If opcao = 1 Then

            Console.WriteLine()
            Console.WriteLine("CADASTRO VEÍCULOS.")
            Console.Write("Digite a placa do veículo: ")
            placa = Console.ReadLine()
            Entrada(placa)

        End If

        If opcao = 2 Then
            Console.Write("Digite a placa do veículo: ")
            placa = Console.ReadLine()
            Saida(placa)
            System.Console.ReadLine()
        End If


        If opcao = 3 Then
            ListaEstacionamento()
        End If


        If opcao = 4 Then
            ListaSaidaEstacionamento()
        End If



    End Sub

#Region "Registra entrada dos veiculos no Estacionamento"



    Public Sub Entrada(ByVal placa As String)

        Dim query = (From c In Estacionamento Where c.DATA_SAIDA Is Nothing).Count
        If query = 10 Then
            Console.WriteLine("ESTACIONAMENTO LOTADO!")
            Console.ReadLine()

            Console.Clear()
            Inicio()
        End If

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

#End Region

#Region "Registra saida dos veiculos no Estacionamento"


    Public Sub Saida(placa As String)


        Dim query = (From c In Estacionamento
                            Where c.PLACA = placa And c.DATA_SAIDA Is Nothing).FirstOrDefault()

        If query Is Nothing Then
            Console.WriteLine("PLACA NÃO CONSTA NO ESTACIONAMENTO!")
            Console.ReadLine()

            Console.Clear()
            Inicio()
        Else
            query.DATA_SAIDA = Date.Now
            retornaPlaca = query.PLACA
            retornaEntrada = query.DATA_ENTRADA
            retornaSaida = Date.Now

            If DateDiff(DateInterval.Hour, query.DATA_ENTRADA, Date.Now) <= 1 Then
                valor = 10
            Else
                valor = 15
            End If
            query.VALOR = valor

        End If

        Console.WriteLine()
        Console.WriteLine(":::::::: SAÍDA DO VEÍCULO REGISTRADA COM SUCESSO ::::::::")
        Console.WriteLine("A placa do veículo: " & retornaPlaca & "")
        Console.WriteLine("A data e hora de entrada do veículo: " & retornaEntrada & "")
        Console.WriteLine("A data e hora de saída do veículo: " & retornaSaida & "")
        Console.WriteLine("Valor cobrado: R$ " & valor & "")
        Console.ReadLine()

        Console.Clear()
        Inicio()

    End Sub

#End Region

#Region "Listagem dos veiculos que estão no Estacionamento"

    Public Sub ListaEstacionamento()

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

#End Region

#Region "Listagem das Saidas de veiculos do Estacionamento"

    Public Sub ListaSaidaEstacionamento()

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

#End Region




End Class
