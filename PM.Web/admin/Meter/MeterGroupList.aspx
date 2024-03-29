﻿<%@ Page Title="计量器组" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="MeterGroupList.aspx.cs" Inherits="PM.Web.admin.Meter.MeterGroupList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="bs-docs-section">
        <div class="page-header">

                <a href="MeterGroupForm.aspx" class="btn btn-info">新增</a>
                <asp:DropDownList ID="ddlFields" runat="server">
                    <asp:ListItem Value="GROUPNAME">组名</asp:ListItem>
                    <asp:ListItem Value="DESCRIPTION">描述</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-info" Text="查询" />
                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-info" Text="导出" />

        </div>
    </div>
    <!-- /toolbar -->
    <asp:Repeater ID="rptMeterGroup" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table table-bordered table-hover table-striped">
                <tr>
                    <th width="20%">
                        计量器组
                    </th>
                    <th>
                        描述
                    </th>
                    <th></th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("GroupName") %>
                </td>
                <td>
                    <%# Eval("Description") %>
                </td>
                <td>
                <a href="MeterGroupForm.aspx?metergroupid=<%# Eval("METERGROUPID") %>">编辑</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
