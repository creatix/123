<%@ Control Language="VB" AutoEventWireup="false" CodeFile="paramslist.ascx.vb" Inherits="components_paramslist" %>
<table cellpadding="8" cellspacing="2" border="0" class="paramstable" width="100%">
    <asp:Repeater ID="paramsRepeater" runat="server">
        <ItemTemplate>
            <tr class="odd">
                <td><%#Eval("value")%></td>
                <th><%#getParamName(Eval("paramsstructureid"))%></th>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="even">
                <td><%#Eval("value")%></td>
                <th><%#getParamName(Eval("paramsstructureid"))%></th>
            </tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
</table>