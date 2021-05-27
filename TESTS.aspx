<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TESTS.aspx.cs" Inherits="Report_XCS.TESTS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        $(document).ready(function () {
           $('#BTsend').click(function () {  
        var url = "/Webform1.aspx";  
        var name = $("#TB1").val(); 
        $.post(url, { InvestigateCode: name}, function (data) {  
            $("#msg").html(data);  
        }); 

        });
        function onValiddate() {
            var isValid;
            isValid = true;
            var datafrom = $('#TB1').val();
           
            if (datafrom != '') {               
                    isValid = true;
                } else {
                    isValid = false;
                }
            }
            return isValid;
        }
        function LoadData(id) {
            var param = "{'InvestigateCode':" + JSON.stringify(id) + "}";
            var dataurl = 'Webform1.aspx';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "data": param,
                "url": dataurl,
                "success": PopulateGrid
            });
        }
        function sendData() {
            var datafrom = $('#TB1').val();
             $.post("Webform1.aspx",
        { InvestigateCode: datafrom },
        function (result) {
            alert(result);                   
        });
        }
       
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TB1" runat="server"></asp:TextBox>
            TEST<Button ID="BTsend" Text="Button" />
        </div>
    </form>
</body>
</html>
