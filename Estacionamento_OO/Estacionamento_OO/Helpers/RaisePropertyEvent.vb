Imports System.ComponentModel

Public Class RaisePropertyEvent
    Implements INotifyPropertyChanged

    Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) _
    Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    Public Sub RaisePropertyChanged(ByVal nameProperty As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(nameProperty))
    End Sub


End Class
