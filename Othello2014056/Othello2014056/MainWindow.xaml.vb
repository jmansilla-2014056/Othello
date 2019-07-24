
Class MainWindow
    Dim _ficha1 As New Ficha
    Dim _ficha2 As New Ficha
    Private _matriz(0 To 7, 0 To 7) As Ficha
    Private _matriz2(0 To 8, 0 To 8) As String
    Dim _contandor As Integer = 4
    Dim _fr As Integer = 2
    Dim _fn As Integer = 2
    Dim _permiso As Boolean
    Dim _permiso2 As Boolean

    'Dim Lista As String = "."

#Region "Variables"
    Private _x As Double
    Private _y As Double
    Private _alternar As Integer
    Private _alternar2 As Integer
    Private variable As Double
#End Region

    Sub Main()
        Grid.SetRow(Menu, 0)
        Grid.SetRow(Tablero, 2)
    End Sub

#Region "Funcion para salir"
    Private Sub Salir(ByVal sender As System.Object, ByVal ev As System.Windows.RoutedEventArgs)
        Dim respuesta As String
        respuesta = MsgBox("Desea salir?", vbOKCancel)
        If (respuesta = 0) Then
            Exit Sub
        ElseIf (respuesta = 1) Then
            Close()
        End If
    End Sub
#End Region

#Region "Funcion Nuevo"
    Private Sub Nuevo(ByVal sender As System.Object, ByVal ev As System.Windows.RoutedEventArgs)
        Dim int As Integer = 8
        For H As Integer = 0 To 7
            For value As Integer = 0 To _matriz.Length
                int = int - 1
                Tablero.Children.RemoveRange(1, 1)
                For value2 As Integer = 0 To 7
                    If int < 8 And int > -1 Then
                        _matriz(value2, int) = Nothing
                        _matriz(value2, int) = Nothing
                    Else
                        int = 8
                    End If
                Next
            Next
        Next
        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location)
        Application.Current.Shutdown()
    End Sub
#End Region

    Private Sub Grid_MouseMove(ByVal Sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs)
        _alternar = (Int(e.GetPosition(Sender).X / 85.25))
        _alternar2 = (Int(e.GetPosition(Sender).Y / 68.625))
    End Sub

    Private Sub Grid_Click(ByVal Sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        If _alternar2 >= 0 And _alternar <= 7 And _alternar2 < 8 And _alternar > -1 Then
            If _matriz(_alternar, _alternar2) Is Nothing Then
                'If Lista.Contains(_alternar & _alternar2) Then
                '    Console.WriteLine("Hola")
                'Else
                Permiso()
                If variable = 0 And _permiso = True Then
                    Dim _ficha As New Ficha
                    _ficha.Color = Ficha.Colores.Negro
                    Grid.SetColumn(_ficha, _alternar)
                    Grid.SetRow(_ficha, _alternar2)
                    _matriz(_alternar, _alternar2) = _ficha
                    _matriz2(_alternar, _alternar2) = "Negra"
                    Tablero.Children.Add(_matriz(_alternar, _alternar2))
                    _contandor = _contandor + 1
                    'Lista = Lista & "." & _alternar & _alternar2 & "."
                    variable = 1
                    Turno.Fill = New SolidColorBrush(Colors.Green)
                    For repetir As Integer = 0 To 7
                        VerificarV()
                        VerificarH()
                        VerificarX()
                        VerificarY()
                    Next
                    Contador()
                    'Console.WriteLine(Lista)
                ElseIf variable = 1 And _permiso2 = True Then
                    Dim _ficha As New Ficha
                    _ficha.Color = Ficha.Colores.Rojo
                    Grid.SetColumn(_ficha, _alternar)
                    Grid.SetRow(_ficha, _alternar2)
                    _matriz(_alternar, _alternar2) = _ficha
                    _matriz2(_alternar, _alternar2) = "Rojo"
                    Tablero.Children.Add(_matriz(_alternar, _alternar2))
                    _contandor = _contandor + 1
                    'Lista = Lista & "." & _alternar & _alternar2 & "."
                    variable = 0
                    Turno.Fill = New SolidColorBrush(Colors.Purple)
                    For repetir As Integer = 0 To 7
                        VerificarV()
                        VerificarH()
                        VerificarX()
                        VerificarY()
                    Next
                    Contador()
                    'Console.WriteLine(Lista)
                End If
            End If
        End If
        'End If
        Ganador()
    End Sub

    Public Sub New()
        Defecto()
    End Sub

    Sub Defecto()
        InitializeComponent()
        Dim _ficha As New Ficha
        _ficha.Color = Ficha.Colores.Negro
        _matriz(3, 3) = _ficha
        _matriz2(3, 3) = "Negra"
        Grid.SetColumn(_matriz(3, 3), 3)
        Grid.SetRow(_matriz(3, 3), 3)
        Tablero.Children.Add(_matriz(3, 3))

        Dim _ficha1 As New Ficha
        _ficha1.Color = Ficha.Colores.Rojo
        _matriz(4, 3) = _ficha1
        _matriz2(4, 3) = "Rojo"
        Grid.SetColumn(_matriz(4, 3), 4)
        Grid.SetRow(_matriz(4, 3), 3)
        Tablero.Children.Add(_matriz(4, 3))

        Dim _ficha2 As New Ficha
        _ficha2.Color = Ficha.Colores.Rojo
        _matriz(3, 4) = _ficha2
        _matriz2(3, 4) = "Rojo"
        Grid.SetColumn(_matriz(3, 4), 3)
        Grid.SetRow(_matriz(3, 4), 4)
        Tablero.Children.Add(_matriz(3, 4))

        Dim _ficha3 As New Ficha
        _ficha3.Color = Ficha.Colores.Negro
        _matriz(4, 4) = _ficha3
        _matriz2(4, 4) = "Negra"
        Grid.SetColumn(_matriz(4, 4), 4)
        Grid.SetRow(_matriz(4, 4), 4)
        Tablero.Children.Add(_matriz(4, 4))
    End Sub

    Public Sub VerificarV()
        Try
            Dim _ficha As New Ficha
            _ficha.Color = Ficha.Colores.Negro
            Dim _ficha2 As New Ficha
            _ficha2.Color = Ficha.Colores.Rojo
            Dim _escan As Integer = _alternar2
            Dim _escan2 As Integer = _alternar2
            For X As Integer = 0 To 7
                If _matriz2(_alternar, _alternar2) = "Rojo" Then
                    _escan = _escan + 1
                    If _escan < 8 Then
                        If _matriz2(_alternar, _escan) = "Rojo" Then
                            _matriz2(_alternar, _escan - 1) = "Rojo"
                            _matriz(_alternar, _escan - 1) = _ficha2
                            Grid.SetColumn(_matriz(_alternar, _escan - 1), _alternar)
                            Grid.SetRow(_matriz(_alternar, _escan - 1), _escan - 1)
                            Tablero.Children.Add((_matriz(_alternar, _escan - 1)))
                            Exit For
                        ElseIf _matriz2(_alternar, _escan) = "" Then
                            Exit For
                        End If
                    End If
                ElseIf _matriz2(_alternar, _alternar2) = "Negra" Then
                    _escan = _escan + 1
                    If _escan < 8 Then
                        If _matriz2(_alternar, _escan) = "Negra" Then
                            _matriz2(_alternar, _escan - 1) = "Negra"
                            _matriz(_alternar, _escan - 1) = _ficha
                            Grid.SetColumn(_matriz(_alternar, _escan - 1), _alternar)
                            Grid.SetRow(_matriz(_alternar, _escan - 1), _escan - 1)
                            Tablero.Children.Add((_matriz(_alternar, _escan - 1)))
                            Exit For
                        ElseIf _matriz2(_alternar, _escan) = "" Then
                            Exit For
                        End If
                    End If
                End If
            Next
            For X As Integer = 0 To 7
                If _matriz2(_alternar, _alternar2) = "Rojo" Then
                    _escan2 = _escan2 - 1
                    If _escan2 > -1 Then
                        If _matriz2(_alternar, _escan2) = "Rojo" Then
                            _matriz2(_alternar, _escan2 + 1) = "Rojo"
                            _matriz(_alternar, _escan2 + 1) = _ficha2
                            Grid.SetColumn(_matriz(_alternar, _escan2 + 1), _alternar)
                            Grid.SetRow(_matriz(_alternar, _escan2 + 1), _escan2 + 1)
                            Tablero.Children.Add(_matriz(_alternar, _escan2 + 1))
                            Exit For
                        ElseIf _matriz2(_alternar, _escan2) = "" Then
                            Exit For
                        End If
                    End If
                ElseIf _matriz2(_alternar, _alternar2) = "Negra" Then
                    _escan2 = _escan2 - 1
                    If _escan2 > -1 Then
                        If _matriz2(_alternar, _escan2) = "Negra" Then
                            _matriz2(_alternar, _escan2 + 1) = "Negra"
                            _matriz(_alternar, _escan2 + 1) = _ficha
                            Grid.SetColumn(_matriz(_alternar, _escan2 + 1), _alternar)
                            Grid.SetRow(_matriz(_alternar, _escan2 + 1), _escan2 + 1)
                            Tablero.Children.Add(_matriz(_alternar, _escan2 + 1))
                            Exit For
                        ElseIf _matriz2(_alternar, _escan2) = "" Then
                            Exit For
                        End If
                    End If
                End If
            Next
        Catch rgEx As ArgumentException
        End Try
    End Sub

    Public Sub VerificarH()
        Dim _ficha As New Ficha
        _ficha.Color = Ficha.Colores.Negro
        Dim _ficha2 As New Ficha
        _ficha2.Color = Ficha.Colores.Rojo
        Dim _escan As Integer = _alternar
        Dim _escan2 As Integer = _alternar
        Try
            For X As Integer = 0 To 7
                If _matriz2(_alternar, _alternar2) = "Rojo" Then
                    _escan = _escan + 1
                    If _escan < 8 Then
                        If _matriz2(_escan, _alternar2) = "Rojo" Then
                            _matriz2(_escan - 1, _alternar2) = "Rojo"
                            _matriz(_escan - 1, _alternar2) = _ficha2
                            Grid.SetColumn(_matriz(_escan - 1, _alternar2), _escan - 1)
                            Grid.SetRow(_matriz(_escan - 1, _alternar2), _alternar2)
                            Tablero.Children.Add((_matriz(_escan - 1, _alternar2)))
                            Exit For
                        ElseIf _matriz2(_escan, _alternar2) = "" Then
                            Exit For
                        End If
                    End If
                ElseIf _matriz2(_alternar, _alternar2) = "Negra" Then
                    _escan = _escan + 1
                    If _escan < 8 Then
                        If _matriz2(_escan, _alternar2) = "Negra" Then
                            _matriz2(_escan - 1, _alternar2) = "Negra"
                            _matriz(_escan - 1, _alternar2) = _ficha
                            Grid.SetColumn(_matriz(_escan - 1, _alternar2), _escan - 1)
                            Grid.SetRow(_matriz(_escan - 1, _alternar2), _alternar2)
                            Tablero.Children.Add(_matriz(_escan - 1, _alternar2))
                            Exit For
                        ElseIf _matriz2(_escan, _alternar2) = "" Then
                            Exit For
                        End If
                    End If
                End If
            Next
            For X As Integer = 0 To 7
                If _matriz2(_alternar, _alternar2) = "Rojo" Then
                    _escan2 = _escan2 - 1
                    If _escan2 > -1 Then
                        If _matriz2(_escan2, _alternar2) = "Rojo" Then
                            _matriz2(_escan2 + 1, _alternar2) = "Rojo"
                            _matriz(_escan2 + 1, _alternar2) = _ficha2
                            Grid.SetColumn(_matriz(_escan2 + 1, _alternar2), _escan2 + 1)
                            Grid.SetRow(_matriz(_escan2 + 1, _alternar2), _alternar2)
                            Tablero.Children.Add(_matriz(_escan2 + 1, _alternar2))
                            Exit For
                        ElseIf _matriz2(_escan2, _alternar2) = "" Then
                            Exit For
                        End If
                    End If
                ElseIf _matriz2(_alternar, _alternar2) = "Negra" Then
                    _escan2 = _escan2 - 1
                    If _escan2 > -1 Then
                        If _matriz2(_escan2, _alternar2) = "Negra" Then
                            _matriz2(_escan2 + 1, _alternar2) = "Negra"
                            _matriz(_escan2 + 1, _alternar2) = _ficha
                            Grid.SetColumn(_matriz(_escan2 + 1, _alternar2), _escan2 + 1)
                            Grid.SetRow(_matriz(_escan2 + 1, _alternar2), _alternar2)
                            Tablero.Children.Add(_matriz(_escan2 + 1, _alternar2))
                            Exit For
                        ElseIf _matriz2(_escan2, _alternar2) = "" Then
                            Exit For
                        End If
                    End If
                End If
            Next
        Catch rgEx As ArgumentException
        End Try
    End Sub

    Public Sub VerificarX()
        Dim _ficha As New Ficha
        _ficha.Color = Ficha.Colores.Negro
        Dim _ficha2 As New Ficha
        _ficha2.Color = Ficha.Colores.Rojo
        Dim _escan As Integer = _alternar
        Dim _escan2 As Integer = _alternar2
        Dim _escanb As Integer = _alternar
        Dim _escanb2 As Integer = _alternar2
        Try
            For X As Integer = 0 To 7
                If _matriz2(_alternar, _alternar2) = "Rojo" Then
                    _escan = _escan + 1
                    _escan2 = _escan2 + 1
                    If _escan < 8 And _escan2 < 8 Then
                        If _matriz2(_escan, _escan2) = "Rojo" Then
                            _matriz2(_escan - 1, _escan2 - 1) = "Rojo"
                            _matriz(_escan - 1, _escan2 - 1) = _ficha2
                            Grid.SetColumn(_matriz(_escan - 1, _escan2 - 1), _escan - 1)
                            Grid.SetRow(_matriz(_escan - 1, _escan2 - 1), _escan2 - 1)
                            Tablero.Children.Add(_matriz(_escan - 1, _escan2 - 1))
                            Exit For
                        ElseIf _matriz2(_escan, _escan2) = "" Then
                            Exit For
                        End If
                    End If
                ElseIf _matriz2(_alternar, _alternar2) = "Negra" Then
                    _escan = _escan + 1
                    _escan2 = _escan2 + 1
                    If _escan < 8 And _escan2 < 8 Then
                        If _matriz2(_escan, _escan2) = "Negra" Then
                            _matriz2(_escan - 1, _escan2 - 1) = "Negra"
                            _matriz(_escan - 1, _escan2 - 1) = _ficha
                            Grid.SetColumn(_matriz(_escan - 1, _escan2 - 1), _escan - 1)
                            Grid.SetRow(_matriz(_escan - 1, _escan2 - 1), _escan2 - 1)
                            Tablero.Children.Add(_matriz(_escan - 1, _escan2 - 1))
                            Exit For
                        ElseIf _matriz2(_escan, _escan2) = "" Then
                            Exit For
                        End If
                    End If
                End If
            Next
            For X As Integer = 0 To 7
                If _matriz2(_alternar, _alternar2) = "Rojo" Then
                    _escanb = _escanb - 1
                    _escanb2 = _escanb2 - 1
                    If _escanb > -1 And _escanb2 > -1 Then
                        If _matriz2(_escanb, _escanb2) = "Rojo" Then
                            _matriz2(_escanb + 1, _escanb2 + 1) = "Rojo"
                            _matriz(_escanb + 1, _escanb2 + 1) = _ficha2
                            Grid.SetColumn(_matriz(_escanb + 1, _escanb2 + 1), _escanb + 1)
                            Grid.SetRow(_matriz(_escanb + 1, _escanb2 + 1), _escanb2 + 1)
                            Tablero.Children.Add(_matriz(_escanb + 1, _escanb2 + 1))
                            Exit For
                        ElseIf _matriz2(_escanb, _escanb2) = "" Then
                            Exit For
                        End If
                    End If
                ElseIf _matriz2(_alternar, _alternar2) = "Negra" Then
                    _escanb = _escanb - 1
                    _escanb2 = _escanb2 - 1
                    If _escanb > -1 And _escanb2 > -1 Then
                        If _matriz2(_escanb, _escanb2) = "Negra" Then
                            _matriz2(_escanb + 1, _escanb2 + 1) = "Negra"
                            _matriz(_escanb + 1, _escanb2 + 1) = _ficha
                            Grid.SetColumn(_matriz(_escanb + 1, _escanb2 + 1), _escanb + 1)
                            Grid.SetRow(_matriz(_escanb + 1, _escanb2 + 1), _escanb2 + 1)
                            Tablero.Children.Add(_matriz(_escanb + 1, _escanb2 + 1))
                            Exit For
                        ElseIf _matriz2(_escanb, _escanb2) = "" Then
                            Exit For
                        End If
                    End If
                End If
            Next
        Catch rgEx As ArgumentException
        End Try
    End Sub

    Public Sub VerificarY()
        Dim _ficha As New Ficha
        _ficha.Color = Ficha.Colores.Negro
        Dim _ficha2 As New Ficha
        _ficha2.Color = Ficha.Colores.Rojo
        Dim _escan As Integer = _alternar
        Dim _escan2 As Integer = _alternar2
        Dim _escanb As Integer = _alternar
        Dim _escanb2 As Integer = _alternar2
        Try
            For X As Integer = 0 To 7
                If _matriz2(_alternar, _alternar2) = "Rojo" Then
                    _escan = _escan + 1
                    _escan2 = _escan2 - 1
                    If _escan < 8 And _escan2 > -1 Then
                        If _matriz2(_escan, _escan2) = "Rojo" Then
                            _matriz2(_escan - 1, _escan2 + 1) = "Rojo"
                            _matriz(_escan - 1, _escan2 + 1) = _ficha2
                            Grid.SetColumn(_matriz(_escan - 1, _escan2 + 1), _escan - 1)
                            Grid.SetRow(_matriz(_escan - 1, _escan2 + 1), _escan2 + 1)
                            Tablero.Children.Add(_matriz(_escan - 1, _escan2 + 1))
                            Exit For
                        ElseIf _matriz2(_escan, _escan2) = "" Then
                            Exit For
                        End If
                    End If
                ElseIf _matriz2(_alternar, _alternar2) = "Negra" Then
                    _escan = _escan + 1
                    _escan2 = _escan2 - 1
                    If _escan < 8 And _escan2 > -1 Then
                        If _matriz2(_escan, _escan2) = "Negra" Then
                            _matriz2(_escan - 1, _escan2 + 1) = "Negra"
                            _matriz(_escan - 1, _escan2 + 1) = _ficha
                            Grid.SetColumn(_matriz(_escan - 1, _escan2 + 1), _escan - 1)
                            Grid.SetRow(_matriz(_escan - 1, _escan2 + 1), _escan2 + 1)
                            Tablero.Children.Add(_matriz(_escan - 1, _escan2 + 1))
                            Exit For
                        ElseIf _matriz2(_escan, _escan2) = "" Then
                            Exit For
                        End If
                    End If
                End If
            Next
            For X As Integer = 0 To 7
                If _matriz2(_alternar, _alternar2) = "Rojo" Then
                    _escanb = _escanb - 1
                    _escanb2 = _escanb2 + 1
                    If _escanb > -1 And _escanb2 < 8 Then
                        If _matriz2(_escanb, _escanb2) = "Rojo" Then
                            _matriz2(_escanb + 1, _escanb2 - 1) = "Rojo"
                            _matriz(_escanb + 1, _escanb2 - 1) = _ficha2
                            Grid.SetColumn(_matriz(_escanb + 1, _escanb2 - 1), _escanb + 1)
                            Grid.SetRow(_matriz(_escanb + 1, _escanb2 - 1), _escanb2 - 1)
                            Tablero.Children.Add(_matriz(_escanb + 1, _escanb2 - 1))
                            Exit For
                        ElseIf _matriz2(_escanb, _escanb2) = "" Then
                            Exit For
                        End If
                    End If
                ElseIf _matriz2(_alternar, _alternar2) = "Negra" Then
                    _escanb = _escanb - 1
                    _escanb2 = _escanb2 + 1
                    If _escanb > -1 And _escanb2 < 8 Then
                        If _matriz2(_escanb, _escanb2) = "Negra" Then
                            _matriz2(_escanb + 1, _escanb2 - 1) = "Negra"
                            _matriz(_escanb + 1, _escanb2 - 1) = _ficha
                            Grid.SetColumn(_matriz(_escanb + 1, _escanb2 - 1), _escanb + 1)
                            Grid.SetRow(_matriz(_escanb + 1, _escanb2 - 1), _escanb2 - 1)
                            Tablero.Children.Add(_matriz(_escanb + 1, _escanb2 - 1))
                            Exit For
                        ElseIf _matriz2(_escanb, _escanb2) = "" Then
                            Exit For
                        End If
                    End If
                End If
            Next
        Catch rgEx As ArgumentException
        End Try
    End Sub

    Public Sub Ganador()
        Dim Rojas As Integer = 0
        Dim Negras As Integer = 0
        If _contandor = 64 Then
            For contand As Integer = 0 To 7
                Console.WriteLine(contand)
                If _matriz(0, contand).Color = Ficha.Colores.Rojo And _matriz2(0, contand) = "Rojo" Then
                    Rojas = Rojas + 1
                End If
                If _matriz(1, contand).Color = Ficha.Colores.Rojo And _matriz2(1, contand) = "Rojo" Then
                    Rojas = Rojas + 1
                End If
                If _matriz(2, contand).Color = Ficha.Colores.Rojo And _matriz2(2, contand) = "Rojo" Then
                    Rojas = Rojas + 1
                End If
                If _matriz(3, contand).Color = Ficha.Colores.Rojo And _matriz2(3, contand) = "Rojo" Then
                    Rojas = Rojas + 1
                End If
                If _matriz(4, contand).Color = Ficha.Colores.Rojo And _matriz2(4, contand) = "Rojo" Then
                    Rojas = Rojas + 1
                End If
                If _matriz(5, contand).Color = Ficha.Colores.Rojo And _matriz2(5, contand) = "Rojo" Then
                    Rojas = Rojas + 1
                End If
                If _matriz(6, contand).Color = Ficha.Colores.Rojo And _matriz2(6, contand) = "Rojo" Then
                    Rojas = Rojas + 1
                End If
                If _matriz(7, contand).Color = Ficha.Colores.Rojo And _matriz2(7, contand) = "Rojo" Then
                    Rojas = Rojas + 1
                End If
                If _matriz(0, contand).Color = Ficha.Colores.Negro And _matriz2(0, contand) = "Negra" Then
                    Negras = Negras + 1
                End If
                If _matriz(1, contand).Color = Ficha.Colores.Negro And _matriz2(1, contand) = "Negra" Then
                    Negras = Negras + 1
                End If
                If _matriz(2, contand).Color = Ficha.Colores.Negro And _matriz2(2, contand) = "Negra" Then
                    Negras = Negras + 1
                End If
                If _matriz(3, contand).Color = Ficha.Colores.Negro And _matriz2(3, contand) = "Negra" Then
                    Negras = Negras + 1
                End If
                If _matriz(4, contand).Color = Ficha.Colores.Negro And _matriz2(4, contand) = "Negra" Then
                    Negras = Negras + 1
                End If
                If _matriz(5, contand).Color = Ficha.Colores.Negro And _matriz2(5, contand) = "Negra" Then
                    Negras = Negras + 1
                End If
                If _matriz(6, contand).Color = Ficha.Colores.Negro And _matriz2(6, contand) = "Negra" Then
                    Negras = Negras + 1
                End If
                If _matriz(7, contand).Color = Ficha.Colores.Negro And _matriz2(7, contand) = "Negra" Then
                    Negras = Negras + 1
                End If
            Next
            If Negras > Rojas Then
                MsgBox("Ganan Moradas")
            ElseIf Rojas > Negras Then
                MsgBox("Ganan Verdes")
            ElseIf Rojas = Negras Then
                MsgBox("Empate")
            End If
        End If
    End Sub

    Sub Contador()
        Dim Rojas As Integer = 0
        Dim Negras As Integer = 0

        For contand As Integer = 0 To 7
            Console.WriteLine(contand)
            If _matriz2(0, contand) = "Rojo" Then
                Rojas = Rojas + 1
            End If
            If _matriz2(1, contand) = "Rojo" Then
                Rojas = Rojas + 1
            End If
            If _matriz2(2, contand) = "Rojo" Then
                Rojas = Rojas + 1
            End If
            If _matriz2(3, contand) = "Rojo" Then
                Rojas = Rojas + 1
            End If
            If _matriz2(4, contand) = "Rojo" Then
                Rojas = Rojas + 1
            End If
            If _matriz2(5, contand) = "Rojo" Then
                Rojas = Rojas + 1
            End If
            If _matriz2(6, contand) = "Rojo" Then
                Rojas = Rojas + 1
            End If
            If _matriz2(7, contand) = "Rojo" Then
                Rojas = Rojas + 1
            End If
            If _matriz2(0, contand) = "Negra" Then
                Negras = Negras + 1
            End If
            If _matriz2(1, contand) = "Negra" Then
                Negras = Negras + 1
            End If
            If _matriz2(2, contand) = "Negra" Then
                Negras = Negras + 1
            End If
            If _matriz2(3, contand) = "Negra" Then
                Negras = Negras + 1
            End If
            If _matriz2(4, contand) = "Negra" Then
                Negras = Negras + 1
            End If
            If _matriz2(5, contand) = "Negra" Then
                Negras = Negras + 1
            End If
            If _matriz2(6, contand) = "Negra" Then
                Negras = Negras + 1
            End If
            If _matriz2(7, contand) = "Negra" Then
                Negras = Negras + 1
            End If
        Next
        CM.Content = Negras
        CV.Content = Rojas
    End Sub

    Sub Permiso()
        _permiso = False
        _permiso2 = False
        If variable = 0 And _alternar > 0 And _alternar2 > 0 Then
            If _matriz2(_alternar, _alternar2 - 1) = "Rojo" Or _matriz2(_alternar, _alternar2 + 1) = "Rojo" Or _matriz2(_alternar + 1, _alternar2) = "Rojo" Or _matriz2(_alternar - 1, _alternar2) = "Rojo" Or _matriz2(_alternar + 1, _alternar2 + 1) = "Rojo" Or _matriz2(_alternar - 1, _alternar2 - 1) = "Rojo" Or _matriz2(_alternar + 1, _alternar2 - 1) = "Rojo" Or _matriz2(_alternar - 1, _alternar2 + 1) = "Rojo" Then
                _permiso = True
            End If
        End If
        If variable = 0 And _alternar = 0 And _alternar2 > 0 Then
            If _matriz2(_alternar, _alternar2 - 1) = "Rojo" Or _matriz2(_alternar, _alternar2 + 1) = "Rojo" Or _matriz2(_alternar + 1, _alternar2) = "Rojo" Or _matriz2(_alternar + 1, _alternar2 + 1) = "Rojo" Or _matriz2(_alternar + 1, _alternar2 - 1) = "Rojo" Then
                _permiso = True
            End If
        End If
        If variable = 0 And _alternar2 = 0 And _alternar > 0 Then
            If _matriz2(_alternar, _alternar2 + 1) = "Rojo" Or _matriz2(_alternar + 1, _alternar2) = "Rojo" Or _matriz2(_alternar - 1, _alternar2) = "Rojo" Or _matriz2(_alternar + 1, _alternar2 + 1) = "Rojo" Or _matriz2(_alternar - 1, _alternar2 + 1) = "Rojo" Then
                _permiso = True
            End If
        End If
        If variable = 0 And _alternar = 0 And _alternar2 = 0 Then
            If _matriz2(_alternar, _alternar2 + 1) = "Rojo" Or _matriz2(_alternar + 1, _alternar2) = "Rojo" Or _matriz2(_alternar + 1, _alternar2 + 1) = "Rojo" Then
                _permiso = True
            End If
        End If

        If variable = 1 And _alternar > 0 And _alternar2 > 0 Then
            If _matriz2(_alternar, _alternar2 - 1) = "Negra" Or _matriz2(_alternar, _alternar2 + 1) = "Negra" Or _matriz2(_alternar + 1, _alternar2) = "Negra" Or _matriz2(_alternar - 1, _alternar2) = "Negra" Or _matriz2(_alternar + 1, _alternar2 + 1) = "Negra" Or _matriz2(_alternar - 1, _alternar2 - 1) = "Negra" Or _matriz2(_alternar + 1, _alternar2 - 1) = "Negra" Or _matriz2(_alternar - 1, _alternar2 + 1) = "Negra" Then
                _permiso2 = True
            End If
        End If
        If variable = 1 And _alternar = 0 And _alternar2 > 0 Then
            If _matriz2(_alternar, _alternar2 - 1) = "Negra" Or _matriz2(_alternar, _alternar2 + 1) = "Negra" Or _matriz2(_alternar + 1, _alternar2) = "Negra" Or _matriz2(_alternar + 1, _alternar2 + 1) = "Negra" Or _matriz2(_alternar + 1, _alternar2 - 1) = "Negra" Then
                _permiso2 = True
            End If
        End If
        If variable = 1 And _alternar2 = 0 And _alternar > 0 Then
            If _matriz2(_alternar, _alternar2 + 1) = "Negra" Or _matriz2(_alternar + 1, _alternar2) = "Negra" Or _matriz2(_alternar - 1, _alternar2) = "Negra" Or _matriz2(_alternar + 1, _alternar2 + 1) = "Negra" Or _matriz2(_alternar - 1, _alternar2 + 1) = "Negra" Then
                _permiso2 = True
            End If
        End If
        If variable = 1 And _alternar = 0 And _alternar2 = 0 Then
            If _matriz2(_alternar, _alternar2 + 1) = "Negra" Or _matriz2(_alternar + 1, _alternar2) = "Negra" Or _matriz2(_alternar + 1, _alternar2 + 1) = "Negra" Then
                _permiso2 = True
            End If
        End If

    End Sub
End Class

