Public Class VEICULOS_PM

    Private _PLACA As String
    Public Property PLACA() As String
        Get
            Return _PLACA
        End Get
        Set(ByVal value As String)
            _PLACA = value
        End Set
    End Property

    Private _DATA_ENTRADA As DateTime
    Public Property DATA_ENTRADA() As DateTime
        Get
            Return _DATA_ENTRADA
        End Get
        Set(ByVal value As DateTime)
            _DATA_ENTRADA = value
        End Set
    End Property

    Private _DATA_SAIDA As Nullable(Of DateTime)
    Public Property DATA_SAIDA() As Nullable(Of DateTime)
        Get
            Return _DATA_SAIDA
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _DATA_SAIDA = value
        End Set
    End Property

    Private _VALOR As Nullable(Of Decimal)
    Public Property VALOR() As Nullable(Of Decimal)
        Get
            Return _VALOR
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _VALOR = value
        End Set
    End Property

End Class
