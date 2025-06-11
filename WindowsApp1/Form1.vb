Imports Logaresi.Negocio

Public Class Form1

    Dim obj As New Datos

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.DataSource = obj.ListarAlumnos

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        txtCodigo.Text = DataGridView1.Item(0, e.RowIndex).Value
        txtApellidos.Text = DataGridView1.Item(1, e.RowIndex).Value
        txtNombres.Text = DataGridView1.Item(2, e.RowIndex).Value
        txtCarrera.Text = DataGridView1.Item(3, e.RowIndex).Value
        txtCiclo.Text = DataGridView1.Item(4, e.RowIndex).Value

    End Sub

    Private Sub btnregistrar_Click(sender As Object, e As EventArgs) Handles btnregistrar.Click

        Try
            obj.Insertar(txtCodigo.Text, txtApellidos.Text, txtNombres.Text, txtCarrera.Text, txtCiclo.Text)
            DataGridView1.DataSource = obj.ListarAlumnos
            MsgBox("Se registro el Estudiante: " + txtApellidos.Text)

            txtCodigo.Text = ""
            txtApellidos.Text = ""
            txtNombres.Text = ""
            txtCarrera.Text = ""
            txtCiclo.Text = ""
        Catch ex As Exception
            MsgBox("404 Error al registrar ")
        End Try

    End Sub

    Private Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click

        Try
            obj.Modificar(txtCodigo.Text, txtApellidos.Text, txtNombres.Text, txtCarrera.Text, txtCiclo.Text)
            DataGridView1.DataSource = obj.ListarAlumnos
            MsgBox("Se modifico el Estrudiante con código: " + txtCodigo.Text)

            txtApellidos.Text = ""
            txtNombres.Text = ""
            txtCarrera.Text = ""
            txtCodigo.Text = ""
            txtCiclo.Text = ""

        Catch ex As Exception
            MsgBox("404 Error al modificar ")
        End Try

    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click

        Try
            obj.Eliminar(txtCodigo.Text)
            DataGridView1.DataSource = obj.ListarAlumnos
            MsgBox("Se elimino el Estudiante con código: " + txtCodigo.Text)

            txtApellidos.Text = ""
            txtNombres.Text = ""
            txtCarrera.Text = ""
            txtCodigo.Text = ""
            txtCiclo.Text = ""
        Catch ex As Exception

            MsgBox("404 Error al eliminar ")
        End Try

    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        txtCodigo.Text = ""
        txtApellidos.Text = ""
        txtNombres.Text = ""
        txtCarrera.Text = ""
        txtCiclo.Text = ""
        txtCodigo.Select()
    End Sub

End Class
