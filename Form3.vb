Imports System.Data.OleDb
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.DataTable
Public Class Form3
    Public currentUser As String = Form1.currentUser
    Public currentPriv As String = Form1.currentPriv
    Public checkArr As New ArrayList
    Public productStock As Integer = vbNull

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
        Dim productPrompt As String = TextBox2.Text
        provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
        dataFile = "../../db/itemDB.accdb"
        conString = provider & dataFile
        myConnection.ConnectionString = conString
        myConnection.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("Select * FROM [itemList] WHERE [Product BarCode] = '" & TextBox2.Text & "' OR [Product Name] = '" & TextBox2.Text & "' ", myConnection)
        Dim dr As OleDbDataReader = cmd.ExecuteReader

        Dim barCode As String = vbNull
        Dim productName As String = vbNull
        Dim productType As String = vbNull
        Dim productPrice As Integer = vbNull
        Dim checkOut As Integer = vbNull

        While dr.Read
            barCode = dr("Product BarCode")
            productName = dr("Product Name").ToString
            productStock = dr("Quantity")
            productPrice = dr("Price")
        End While
        myConnection.Close()

        If productPrompt = barCode Or productPrompt = productName Then
            productQuantity = InputBox("input quantity")
            DataGridView1.Rows.Add(New String() {barCode, productName, productType, productPrice, productQuantity})
            checkOut = productPrice * productQuantity
            checkArr.Add(checkOut)

            productStock = productStock - productQuantity

            myConnection.Open()
            Dim cmdUpdate As OleDbCommand = New OleDbCommand("UPDATE itemList SET[Quantity] = '" & productStock & "' WHERE [Product Name] = '" & productName & "' ", myConnection)
            Dim drUp As OleDbDataReader = cmdUpdate.ExecuteReader
            myConnection.Close()
        Else
            MsgBox("fail")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim barCodePrompt As String = TextBox1.Text
        provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
        dataFile = "../../db/itemDB.accdb"
        conString = provider & dataFile
        myConnection.ConnectionString = conString
        myConnection.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("Select * FROM [itemList] WHERE [Product BarCode] = '" & TextBox1.Text & "' ", myConnection)
        Dim dr As OleDbDataReader = cmd.ExecuteReader

        Dim barCode As String = vbNull
        Dim productName As String = vbNull
        Dim productType As String = vbNull
        Dim productPrice As Integer = vbNull
        Dim checkOut As Integer = vbNull

        While dr.Read
            barCode = dr("Product BarCode")
            productName = dr("Product Name").ToString
            productStock = dr("Quantity")
            productPrice = dr("Price")
        End While
        myConnection.Close()

        If barCodePrompt = barCode Then
            DataGridView1.Rows.Add(New String() {barCode, productName, productType, productPrice, productQuantity})
            checkOut = productPrice * productQuantity
            checkArr.Add(checkOut)

            productStock = productStock - productQuantity

            myConnection.Open()
            Dim cmdUpdate As OleDbCommand = New OleDbCommand("UPDATE itemList SET[Quantity] = '" & productStock & "' WHERE [Product Name] = '" & productName & "' ", myConnection)
            Dim drUP As OleDbDataReader = cmdUpdate.ExecuteReader
            myConnection.Close()
        Else
            MsgBox("fail")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sum As Integer
        Dim i As Integer
        For Each i In checkArr
            sum = sum + i
        Next i
        MsgBox("TOTAL: " + sum.ToString())
        DataGridView1.Rows.Clear()
    End Sub
End Class