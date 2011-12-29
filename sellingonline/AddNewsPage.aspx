<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="AddNewsPage.aspx.cs" Inherits="AddNewsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Home.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery.tooltip.js"></script>
    <script type="text/javascript" src="Scripts/jquery.cookie.js"></script>
    <script type="text/javascript" src="Scripts/quickpager.jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /*
            show a tool tip of a product
            */

            $(".producting").tooltip({
                delay: 0,
                showURL: false,
                bodyHandler: function () {
                    var ob = $("<img/>").attr("src", this.src);
                    var name = $(this).attr("imgName");
                    ob.css('position', 'relative');
                    ob.css('float', 'left');
                    var title = $("<div/>").html("<b>" + name + "<b>");
                    title.css('position', 'relative');
                    title.css('background-color', 'gray');
                    title.css('color', 'blue');
                    var textcontent = $("<span/>").html('');
                    $.merge(title, ob);
                    $.merge(title, textcontent);
                    return title;
                }
            });

            /*
            slideToggle menu item when move to
            */
            $('.dropdown').each(function () {
                $(this).parent().eq(0).hoverIntent({
                    timeout: 100,
                    over: function () {
                        var current = $('.dropdown:eq(0)', this);
                        current.slideDown(100);
                    },
                    out: function () {
                        var current = $('.dropdown:eq(0)', this);
                        current.fadeOut(200);
                    }
                });
            });

            $('.dropdown a').hover(function () {
                $(this).stop(true).animate({ paddingLeft: '35px' }, { speed: 100, easing: 'easeOutBack' });
            }, function () {
                $(this).stop(true).animate({ paddingLeft: '0' }, { speed: 100, easing: 'easeOutBounce' });
            });

            /*
            show chi tiết sản phẩm khi vào đó
            */

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  
    <p>
        &nbsp;</p>
    <p>
        Title&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="textTitle" runat="server" Height="24px" Width="544px"></asp:TextBox>
    </p>
    <p>
        MainContent&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="textMainContent" runat="server" Height="199px" 
            TextMode="MultiLine" Width="542px"></asp:TextBox>
    </p>
    <p>
        Author&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="textAuthor" runat="server" Height="26px" Width="538px"></asp:TextBox>
    </p>
    <p>
        DatePost&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="textDatePost" runat="server" Height="26px" Width="539px"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="POST" />
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdditionalContent" Runat="Server">
</asp:Content>

