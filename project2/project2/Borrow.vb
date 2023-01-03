Imports System.Data.SqlClient
Imports System.Data
Public Class Borrow
    Dim str As String = ""
    Dim dr As SqlDataReader
    Dim rw As Integer = 0
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Borrow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 300

        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Timer1.Enabled = True
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Timer2.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Height = Me.Height + 10
        If Me.Height >= 500 Then
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Me.Height = Me.Height - 10
        If Me.Height <= 310 Then
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub btnissue_Click(sender As Object, e As EventArgs) Handles btnissue.Click
        If TextBox1.Text = "" Then
            MsgBox("Please Enter Student ID ")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Please Enter Book ID")
        ElseIf datetime.Text = "" Then
            MsgBox("Please Enter Date")
        Else
            MessageBox.Show("Data Inserted Successfully")

        End If
        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
        cmd = New SqlCommand("insert into Borrow values(" & TextBox1.Text & "," & TextBox2.Text & "," & datetime.Text & ")", cn)
        cmd.ExecuteNonQuery()
        cn.Close()

        DispData()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click

        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
        cmd = New SqlCommand("update Borrow set sid=" & TextBox1.Text & ",bid=" & TextBox2.Text & " where (bid=" & TextBox1.Text & ")", cn)
        cmd.ExecuteNonQuery()
        cn.Close()
        MessageBox.Show("Data Updated Successfully")
        DispData()
    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
        Me.datetime.Text = ""

    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
    Private Sub DispData()
        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
        dgdata.Rows.Clear()
        Dim x As Integer = 0
        str = "Select * From Borrow Order By sid"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            dgdata.Rows.Add()
            dgdata.Rows(x).Cells(0).Value = dr("sid")
            dgdata.Rows(x).Cells(1).Value = dr("bid")
            dgdata.Rows(x).Cells(2).Value = dr("date")

            x = x + 1
        End While
        dr.Close()
    End Sub
End Class