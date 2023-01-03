Imports System.Data.SqlClient
Imports System.Data
Public Class Book
  
    Dim str As String = ""
    Dim dr As SqlDataReader
    Dim rw As Integer = 0
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btninsert.Click
       
        If txtid.Text = "" Then
            MsgBox("Please Enter Book ID ")
        ElseIf txtname.Text = "" Then
            MsgBox("Please Enter Book Name")

        ElseIf txtAname.Text = "" Then
            MsgBox("Please Enter Book Author")
        ElseIf txtcategory.Text = "" Then
            MsgBox("Please Enter Book Category")
        Else
            MessageBox.Show("Data Inserted Successfully")
        End If

        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
        cmd = New SqlCommand("insert into Book values(" & txtid.Text & ",'" & txtname.Text & "','" & txtAname.Text & "','" & txtcategory.Text & "')", cn)
        cmd.ExecuteNonQuery()
        cn.Close()

        DispData()
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
        cmd = New SqlCommand("delete from Book where (bid=" & txtid.Text & ")", cn)
        cmd.ExecuteNonQuery()
        cn.Close()
        MessageBox.Show("Data Deleted Successfully")
        DispData()
    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Me.txtname.Text = ""
        Me.txtAname.Text = ""
        Me.txtcategory.Text = ""
        Me.txtid.Text = ""
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
        cmd = New SqlCommand("update Book set bname='" & txtname.Text & "',bauthor='" & txtAname.Text & "' where (bid=" & txtid.Text & ")", cn)
        cmd.ExecuteNonQuery()
        cn.Close()
        MessageBox.Show("Data Updated Successfully")
        DispData()
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub txtid_KeyDown(sender As Object, e As KeyEventArgs) Handles txtid.KeyDown
        If e.KeyCode = Keys.Enter Then
            str = "Select * From Book Where Id=" & txtid.Text
            cmd = New SqlCommand(str, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtid.Text = dr("bid")
                txtname.Text = dr("bname")
                txtAname.Text = dr("bauthor")
                txtcategory.Text = dr("category")


            End While
            dr.Close()
            txtid.Enabled = False
            txtname.Enabled = True
            txtAname.Enabled = True
            txtAname.Enabled = True


        End If
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtid.TextChanged

    End Sub

    Private Sub Book_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 350
        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
        DispData()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Me.Height = Me.Height - 10
        If Me.Height <= 350 Then
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Height = Me.Height + 10
        If Me.Height >= 550 Then
            Timer1.Enabled = False
        End If
    End Sub
 

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Timer1.Enabled = True
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Timer2.Enabled = True
    End Sub
  
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgdata.CellContentClick

    End Sub

    Private Sub DispData()
        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Library Management .mdf;Integrated Security=True")
        cn.Open()
        dgdata.Rows.Clear()
        Dim x As Integer = 0
        str = "Select * From Book Order By bid"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            dgdata.Rows.Add()
            dgdata.Rows(x).Cells(0).Value = dr("bid")
            dgdata.Rows(x).Cells(1).Value = dr("bname")
            dgdata.Rows(x).Cells(2).Value = dr("bauthor")
            dgdata.Rows(x).Cells(3).Value = dr("category")
            x = x + 1
        End While
        dr.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        txtid.Enabled = True
        txtname.Enabled = False
        txtAname.Enabled = False
        txtcategory.Enabled = False
        txtid.Focus()
    End Sub
End Class

