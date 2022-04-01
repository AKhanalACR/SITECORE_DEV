<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Accordion.ascx.cs" Inherits="ACR.layouts.ACRInformatics.sublayouts.content.Accordion" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>



<asp:Repeater runat="server" ID="groupRepeater" OnItemDataBound="groupRepeater_ItemDataBound">
    <ItemTemplate>
            <a name="s<%# Container.ItemIndex %>"></a>
            <span class="groupTitle"><sc:Text runat="server" ID="groupTitle" /></span>
        <div class="text-content"><sc:Text runat="server" ID="groupText" /></div>
        <div class="accordion">
            <asp:Repeater runat="server" ID="accordionRepeater" OnItemDataBound="accordionRepeater_ItemDataBound">
                <ItemTemplate>
                    <section class="accordion-item">
                        <div class="accordion-header">
                            <h4>
                                <sc:Text runat="server" ID="title" />
                            </h4>
                        </div>
                        <div class="accordion-details" style="display: none">
                            <h5>
                                <sc:Text runat="server" ID="subTitle" />
                            </h5>
                            <p>
                                <sc:Text ID="text" runat="server" />
                            </p>

                            <div class="text-right">
                                <sc:Link CssClass="button" ID="link" runat="server" />
                            </div>
                            <div class="accordion">
                                <asp:Repeater runat="server" ID="nestedAccordion" OnItemDataBound="accordionRepeater_ItemDataBound">
                                    <ItemTemplate>
                                        <section class="accordion-item">
                                            <div class="accordion-header">
                                                <h4>
                                                    <sc:Text runat="server" ID="title" />
                                                </h4>
                                            </div>
                                            <div class="accordion-details" style="display: none">
                                                <h5>
                                                    <sc:Text runat="server" ID="subTitle" />
                                                </h5>
                                                <p>
                                                    <sc:Text ID="text" runat="server" />
                                                </p>

                                                <div class="text-right">
                                                    <sc:Link CssClass="button" ID="link" runat="server" />
                                                </div>
                                            </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </section>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </ItemTemplate>
</asp:Repeater>

