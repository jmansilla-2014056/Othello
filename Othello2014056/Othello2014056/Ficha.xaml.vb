Imports System.Windows.Media.Animation

Public Class Ficha
    Private _color As Colores
    Private _storyBoard As StoryBoard

#Region "Enumeracion"

    Public Enum Colores As Integer
        Negro
        Rojo
    End Enum
#End Region

    Public Property Color As Colores
        Get
            Return _color
        End Get

        Set(value As Colores)
            Me._color = value

            Select Case value
                Case Colores.Negro
                    Circle.Fill = New SolidColorBrush(Colors.Purple)
                Case Colores.Rojo
                    Circle.Fill = New SolidColorBrush(Colors.Green)
                    Exit Select
            End Select
            _storyBoard.Begin()
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        _storyBoard = CType(Me.Resources("Animacion"), Storyboard)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        For Each _item In _storyBoard.Children
            Storyboard.SetTarget(_item, imageeen)
            Storyboard.SetTarget(_item, Circle)
        Next
        _storyBoard.Begin()



    End Sub
End Class