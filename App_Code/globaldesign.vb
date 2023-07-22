Imports Microsoft.VisualBasic

Public Class globaldesign


    Public Function alertmsg(ByVal msg As String, ByVal type As String) As String
        Dim sb As StringBuilder = New StringBuilder
        Select Case type
            Case "success"
                sb.Append("<div><div class='alert alert-success'><h5><i class='icon fas fa-check'></i>Success!</h5>" & msg & "</div></div>")
            Case "error"
                sb.Append("<div><div class='alert alert-danger'><h5><i class='icon fas fa-ban'></i>Error!</h5>" & msg & "</div></div>")
            Case "info"
                sb.Append("<div><div class='alert alert-info'><h5><i class='icon fas fa-info'></i>Information!</h5>" & msg & "</div></div>")
        End Select
        Return sb.ToString
    End Function

    Public Function validmsg(ByVal msg As String, ByVal type As String) As String
        Dim sb As StringBuilder = New StringBuilder
        Select Case type
            Case "success"
                sb.Append("<p class='text-success'><i class='fas fa-check'></i>&nbsp;<span>" & msg & "</span></p>")
            Case "error"
                sb.Append("<p class='text-danger'><i class='fas fa-xmark'></i>&nbsp;<span>" & msg & "</span></p>")
        End Select
        Return sb.ToString
    End Function

End Class
