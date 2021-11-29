Public Class Form1

    Dim strKey As String = "EncypherKey"
    Dim objSimpleDes As New Simple3Des(strKey)
    Dim lstPlain As New List(Of String)
    Dim lstEncoded As New List(Of String)
    Dim lstDecoded As New List(Of String)
    Dim intItemLength As New List(Of Integer)
    Dim rnd As New Random
    Dim strWords As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Dim strNumbers As String = "1234567890"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Encrypt and Decrypt"
        Button1.Text = "Encrypt List"
        Button2.Text = "Decrypt List"
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        FillTheListOne()
    End Sub

    Private Sub FillTheListOne()
        Dim intLength As Integer = 9
        Dim strFinal As String = strWords & strNumbers & strWords.ToLower

        For i As Integer = 0 To 49
            Dim iStart As Integer = rnd.Next(0, strFinal.Length - intLength + 1)
            Dim strSubstring As String = strFinal.Substring(iStart, intLength)
            lstPlain.Add(strSubstring)
            ListBox1.Items.Add(strSubstring)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each str As String In lstPlain
            Dim strEncrypted As String = objSimpleDes.Encrypt(str)
            intItemLength.Add(strEncrypted.Length)
            lstEncoded.Add(strEncrypted)
        Next
        ListBox2.DataSource = lstEncoded
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each str As String In lstEncoded
            lstDecoded.Add(objSimpleDes.Decrypt(str))
        Next
        ListBox2.DataSource = lstDecoded
    End Sub
End Class
