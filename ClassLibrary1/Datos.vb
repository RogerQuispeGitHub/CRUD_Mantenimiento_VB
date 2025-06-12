Imports System.Data.SqlClient

''' <summary>
''' Autor: Roger Quispe
''' </summary>
Public Class Datos
    Dim cnx As New SqlConnection("server=localhost\SQLEXPRESS;integrated security=true;Database=RegistroAsistentes")

    Public Function ListarAlumnos() As DataTable
        Dim da As New SqlDataAdapter("pb_listar", cnx)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function Insertar(codigo As String, apellidos As String, nombres As String, carrera As String, ciclo As Int16)
        Dim da As New SqlCommand("pb_nuevo", cnx)
        da.CommandType = CommandType.StoredProcedure
        da.Parameters.AddWithValue("@codigo", codigo)
        da.Parameters.AddWithValue("@apellidos", apellidos)
        da.Parameters.AddWithValue("@nombres", nombres)
        da.Parameters.AddWithValue("@carrera", carrera)
        da.Parameters.AddWithValue("@ciclo", ciclo)
        cnx.Open()
        Dim resp As Integer
        Try
            resp = da.ExecuteNonQuery
            cnx.Close()
        Catch ex As Exception
            MsgBox("Error al registrar Estudiante")
        End Try
        Return resp
    End Function

    Public Function Eliminar(codigo As String)
        Dim elim As New SqlCommand("pb_eliminar", cnx)
        elim.CommandType = CommandType.StoredProcedure
        elim.Parameters.AddWithValue("@codigo", codigo)
        cnx.Open()
        Dim elim1 As String = elim.ExecuteNonQuery
        cnx.Close()
        Return elim1
    End Function

    Public Function Modificar(codigo As String, apellidos As String, nombres As String, carrera As String, ciclo As Int16) As Integer
        Dim act As New SqlCommand("pb_modificar", cnx)
        act.CommandType = CommandType.StoredProcedure
        act.Parameters.AddWithValue("@codigo", codigo)
        act.Parameters.AddWithValue("@apellidos", apellidos)
        act.Parameters.AddWithValue("@nombres", nombres)
        act.Parameters.AddWithValue("@carrera", carrera)
        act.Parameters.AddWithValue("@ciclo", ciclo)
        cnx.Open()
        Dim resp As Integer
        Try
            resp = act.ExecuteNonQuery
            cnx.Close()
        Catch ex As Exception
            MsgBox("Error al registrar Estudiante")
        End Try

        Return resp
    End Function

End Class
