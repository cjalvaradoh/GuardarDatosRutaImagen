Imports System.IO

Public Class Form1
    Private rutaImagen As String ' Variable para almacenar la ruta de la imagen

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Preparar ruta de carpeta
        Dim rutaCarpeta As String = "C:\USPG24\"

        ' Preparar ruta final y nombre de archivo
        Dim rutaArchivo As String = Path.Combine(rutaCarpeta, "datos.txt")

        ' Leer el contenido de los campos
        Dim producto As String = TextBox1.Text
        Dim precio As String = TextBox2.Text

        ' Establecer/preparar fila que se almacenará en el documento de texto
        Dim datos As String = $"Nombre Producto: {producto}, Precio: {precio}, Ruta Imagen: {rutaImagen}"

        ' Insertar/agregar fila con datos en archivos de texto
        Try
            Using escritor As New StreamWriter(rutaArchivo, True)
                escritor.WriteLine(datos)
            End Using

            ' Limpiar los TextBox después de guardar
            TextBox1.Clear()
            TextBox2.Clear()

            MessageBox.Show("Información guardada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error al guardar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim buscarFoto As New OpenFileDialog()

        ' Nos permite abrir el diálogo para buscar un archivo
        buscarFoto.Filter = "Archivos de Imagen | *.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*"

        If buscarFoto.ShowDialog() = DialogResult.OK Then
            rutaImagen = buscarFoto.FileName ' Almacenar la ruta de la imagen
            mostrarFoto(rutaImagen)
        End If

        ' Liberar recursos del OpenFileDialog
        buscarFoto.Dispose()
    End Sub

    Private Sub mostrarFoto(ubicacionFoto As String)
        Dim nuevaImagen As Image = Image.FromFile(ubicacionFoto)
        PictureBox1.Image = nuevaImagen ' Inserción de la imagen
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom ' Amplía la imagen de la foto
    End Sub
End Class
