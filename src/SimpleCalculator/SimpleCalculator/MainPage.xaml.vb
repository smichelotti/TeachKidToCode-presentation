Imports Windows.UI.Popups

' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    
    Private firstNumber As Nullable(Of Decimal)
    Private secondNumber As Nullable(Of Decimal)
    Private selectedOperator As String
    Private reset As Boolean = True

    Private Sub NumberButton_Click(sender As Object, e As RoutedEventArgs)
        Dim btn = CType(sender, Button)
        If reset Then
            txtNumber.Text = ""
            reset = False
        End If

        txtNumber.Text = txtNumber.Text + btn.Content
    End Sub

    Private Sub OperatorButton_Click(sender As Object, e As RoutedEventArgs)
        If Not selectedOperator Is Nothing Then
            Dim dialog = New MessageDialog("You have already selected an operator!")
            Return
        End If

        Dim btn = CType(sender, Button)
        selectedOperator = btn.Content
        firstNumber = Decimal.Parse(txtNumber.Text)
        txtEquation.Text = txtNumber.Text + "  " + btn.Content
        txtNumber.Text = ""
    End Sub

    Private Sub Equals_Click(sender As Object, e As RoutedEventArgs)
        txtEquation.Text = ""
        secondNumber = Decimal.Parse(txtNumber.Text)

        If selectedOperator = "+" Then
            txtNumber.Text = firstNumber + secondNumber
        ElseIf selectedOperator = "-" Then
            txtNumber.Text = firstNumber - secondNumber
        ElseIf selectedOperator = "*" Then
            txtNumber.Text = firstNumber * secondNumber
        ElseIf selectedOperator = "/" Then
            txtNumber.Text = firstNumber / secondNumber
        End If

        ResetEquation()
    End Sub

    Private Sub Clear_Click(sender As Object, e As RoutedEventArgs)
        txtNumber.Text = "0"
        ResetEquation()
    End Sub

    Private Sub ResetEquation()
        firstNumber = Nothing
        secondNumber = Nothing
        selectedOperator = Nothing
        reset = True
    End Sub
End Class
