﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PM.Web.Account.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>能源计量监测平台</title>
    <link href="~/assets/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/assets/css/custom-theme/jquery-ui-1.10.0.custom.css" rel="stylesheet"
        type="text/css" />
    <link href="~/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="~/assets/css/pygments-manni.css" rel="stylesheet" />
</head>
<body class="login">
    <div class="header">
        </div>
    <div class="login-body">
        <div class="bg">
            <div class="loginformwrap">
             <div class="loginformtitle">
                    <span>能源计量监测平台</span>
                </div>
            
            <form class="form-horizontal" role="form" runat="server">
            <div class="form-group">
                <label for="inputEmail1" class="col-lg-4 control-label">
                    用户名：</label>
                <div class="col-lg-8">
                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="用户名"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        CssClass="failureNotification" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。"
                        ValidationGroup="LoginUserValidationGroup" Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword1" class="col-lg-4 control-label">
                    密码：</label>
                <div class="col-lg-8">
                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"
                        placeholder="密码"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        CssClass="failureNotification" placeholder="Password" ErrorMessage="必须填写“密码”。"
                        ToolTip="必须填写“密码”。" ValidationGroup="LoginUserValidationGroup" Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            <div class="form-group">
                <div class="col-lg-offset-8 col-lg-4">
                    <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-default" CommandName="Login"
                        Text="登陆系统" ValidationGroup="LoginUserValidationGroup" />
                </div>
            </div>
            </form>
            </div>
        </div>
    </div>
    <div class="footer">Copyright &copy;2015-2015 北京菲波安乐仪表有限公司 Verson:3.0</div>
</body>
</html>
