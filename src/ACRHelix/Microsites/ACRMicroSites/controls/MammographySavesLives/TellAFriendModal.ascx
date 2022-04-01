<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TellAFriendModal.ascx.cs" Inherits="ACR.controls.MammographySavesLives.TellAFriendModal" %>
	
       <!-- Tell-a-Friend Modal Window -->
        <div class="friend-modal" style="display:none;">
                <div class="form-row">
                        <asp:Label ID="Label1" runat="server" CssClass="modal-input-title" AssociatedControlID="txtEmail" Text="Your Email:" />
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="modal-input" ValidationGroup="TellAFriend" />
                        <asp:RequiredFieldValidator runat="server" ID="reqEmail" CssClass="form-error" ControlToValidate="txtEmail" ValidationGroup="TellAFriend" ErrorMessage="(Required)" />
                        <asp:RegularExpressionValidator runat="server" ID="regEmail" CssClass="form-error" ControlToValidate="txtEmail" ValidationGroup="TellAFriend" ErrorMessage="(Invalid Email Address)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />     
                </div>
                <div class="form-row">
                        <asp:Label ID="Label2" runat="server" CssClass="modal-input-title" AssociatedControlID="txtFriend" Text="Friend's Email:" />
                        <asp:TextBox runat="server" ID="txtFriend" CssClass="modal-input" ValidationGroup="TellAFriend" />
                        <asp:RequiredFieldValidator runat="server" CssClass="form-error" ID="reqFriend" ControlToValidate="txtFriend" ValidationGroup="TellAFriend" ErrorMessage="(Required)" />
                        <asp:RegularExpressionValidator runat="server" CssClass="form-error" ID="regFriend" ControlToValidate="txtFriend" ValidationGroup="TellAFriend" ErrorMessage="(Invalid Email Address)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                </div>
                <div class="form-row">
                        <asp:Label ID="Label3" runat="server" CssClass="modal-input-title" AssociatedControlID="txtMessage" Text="Message:" />
                        <asp:TextBox runat="server" ID="txtMessage" CssClass="modal-textbox tell-a-friend-textbox" Rows="7" Columns="10" TextMode="MultiLine" Text="" ValidationGroup="TellAFriend">I saw this and thought of you. Please visit the site. It could help save your life!</asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="reqMessage" ControlToValidate="txtMessage" ErrorMessage="(Required)" InitialValue="" ValidationGroup="TellAFriend" />
                </div>
                <div class="modal-buttons">
                        <asp:LinkButton runat="server" ID="btnSend" type="submit" CssClass="friend-modal-send" Text="Send" ValidationGroup="TellAFriend" OnClick="btnSend_Click" />
                        <asp:LinkButton runat="server" ID="btnReset" type="reset" CssClass="friend-modal-cancel" Text="Cancel" />
                </div>
        </div>

