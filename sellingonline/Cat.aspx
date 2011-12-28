<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Cat.aspx.cs" Inherits="Cat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Cat.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery.cookie.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".deleteCookie").bind("click", function () {
                var stt = parseInt($(this).attr('id'));
                console.log(' stt ', stt);

                var code = $.trim($.cookie('ProductCode'));
                var index = $.trim($.cookie('ProductIndex'));
                var count = $.trim($.cookie('ProductNumber'));

                // cho vào mảng
                var ProductArr = code.split(" ");
                var ProductIndex = index.split(" ");

                // trước
                console.log('Product arr ', ProductArr);
                console.log('Product index ', ProductIndex);
                console.log('Product number ', count);

                count -= parseInt(ProductIndex[stt]);

                ProductArr.splice(stt, 1);
                ProductIndex.splice(stt, 1)

                /*
                update table
                */

                code = ProductArr.join(' ');
                index = ProductIndex.join(' ');

                $.cookie('ProductCode', code);
                $.cookie('ProductIndex', index);
                $.cookie('ProductNumber', count);

                // sau
                console.log('Product arr ', ProductArr);
                console.log('Product index ', ProductIndex);
                console.log('Product number ', count);

                window.location.reload();
            });


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id = 'showProductItem'>
       <div id ='Title'></div> 
       <div id ='ProductTable' runat="server"></div>
    </div>
    <div id = 'showDirectionInfo'></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdditionalContent" Runat="Server">

</asp:Content>

