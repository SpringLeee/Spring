<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PV.aspx.cs" Inherits="CompanyTest.PV1" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Bootstrap 101 Template</title>

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@3.3.7/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- jQuery (Bootstrap 的所有 JavaScript 插件都依赖 jQuery，所以必须放在前边) -->
    <script src="https://cdn.jsdelivr.net/npm/jquery@1.12.4/dist/jquery.min.js"></script>

</head>

<body>

    <div class="container" style="margin-top: 30px">

        <div class="alert alert-info" role="alert">
            <span class="glyphicon glyphicon-user"></span><span>填表数据:</span> <b><%= list.Count %></b>
            <br />
            <br />
            <span class="glyphicon glyphicon-save"></span><span>模糊下载数据:</span> <b><%= list.Count %></b>
        </div>

        
        <div class="form-inline">

             <div class="form-group">
                <label>手机号</label>
                <input id="mobile" type="text" class="form-control" >
            </div>

            <div class="form-group">
                <label>开始时间</label>
                <input id="starttime" type="datetime-local" class="form-control" >
            </div>

              <div class="form-group">
                <label>结束时间</label>
                <input id="endtime" type="datetime-local" class="form-control" >
            </div>

            <button type="submit" id="Query" class="btn btn-info">查询</button> 

             <button id="import" type="submit" class="btn btn-info">导出</button> 

        </div> 


        <table class="table table-striped" style="border:1px solid #ccc;margin-top:20px">

            <thead>
                <tr>
                    <td>手机号</td>
                    <td>渠道</td>
                    <td>时间</td>
                </tr>
            </thead>

            <tbody id="content-data">

                <% foreach (var item in list) { %> 

                <tr>
                    <td><%= item.Mobile %></td>
                    <td><%= item.Code %></td>
                    <td><%= item.CreateTime.ToString("yyyy/MM/dd HH:mm") %></td>
                </tr>

                  <%  } %> 

            </tbody>


        </table>
    </div>


    <script>

$(function(){

    $("#Query").click(function () {

        var mobile = $("#mobile").val();
        var start = $("#starttime").val();
        var end = $("#endtime").val(); 


        $.ajax({
            url: "PV.aspx",
            type: "POST",
            data: {
                action:"submit",
                mobile: mobile,
                start: start,
                end:end
            },
            success: function (data) {

                var items = JSON.parse(data);

                $("#content-data").html(""); 
               

                $.each(items, function (index, value) {

                    var html = "<tr><td>" + value.Mobile + "</td><td>" + value.Code + "</td><td>" + value.ShowTime + "</td></tr >";
                    $("#content-data").append(html);  
                }); 


              
            }
        });



         

    });


    $("#import").click(function () { 

        var mobile = $("#mobile").val();
        var start = $("#starttime").val();
        var end = $("#endtime").val(); 

        location.href = "PV.aspx?mobile=" + mobile + "&start=" + start + "&end=" + end+"&action=import"; 

    });


}); 

    </script>



</body>
</html>
