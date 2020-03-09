Imports System.Data.OleDb
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.DataTable
Public Class Form3
    Public currentUser As String = Form1.currentUser
    Public currentPriv As String = Form1.currentPriv

    Dim provider As String
    Dim dataFile As String
    Dim conString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim dataAdapter As OleDbDataAdapter
    Dim dataSet As DataSet
    Dim sourceDB As BindingSource
    Private Sub Form3_Current(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim barCodePrompt As String = TextBox1.Text
        Dim productNamePrompt As String = TextBox2.Text
        provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
        dataFile = "../../db/itemDB.accdb"
        conString = provider & dataFile
        myConnection.ConnectionString = conString
        myConnection.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("Select * FROM [itemList] WHERE [Product BarCode] = '" & TextBox1.Text & "' OR [Product Name] = '" & TextBox2.Text & "' ", myConnection)
        Dim dr As OleDbDataReader = cmd.ExecuteReader

        Dim barCode As String = vbNull
        Dim productName As String = vbNull
        Dim productType As String = vbNull
        Dim productPrice As Integer = vbNull
        Dim productQuantity As Integer = 1

        While dr.Read
            barCode = dr("Product BarCode")
            productName = dr("Product Name").ToString
            productType = dr("Product Type").ToString
            productPrice = dr("Price")
        End While
        myConnection.Close()

        If barCodePrompt = barCode Or productNamePrompt = productName Then
            DataGridView1.Rows.Add(New String() {barCode, productName, productType, productPrice, productQuantity})
            MsgBox("error")
        Else
            MsgBox("fail")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        MsgBox("Change quantity")
    End Sub
End Class