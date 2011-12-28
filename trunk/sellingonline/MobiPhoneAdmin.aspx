<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="MobiPhoneAdmin.aspx.cs" Inherits="MobiPhoneAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/MobilePhone.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery.tooltip.js"></script>
    <script type="text/javascript" src="Scripts/jquery.cookie.js"></script>

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
    <div id="divMobilePhoneDisplay" runat="server">
    </div>     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdditionalContent" Runat="Server">
</asp:Content>

