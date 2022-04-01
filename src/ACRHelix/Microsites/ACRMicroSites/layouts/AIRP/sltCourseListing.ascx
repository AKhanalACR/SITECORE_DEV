<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltCourseListing.ascx.cs" Inherits="ACR.layouts.AIRP.sltCourseListing" %>

				<!--ul class="courseList cf"-->
                <table border="0">
					<asp:Repeater runat="server" ID="rptCourseListings" OnItemDataBound="rptCourseListings_OnItemDataBound">
						<ItemTemplate>
							<tr>
                                <td style="padding-right: 50px;">
								    <asp:Image runat="server" ID="imgCourseThumbnail" Width="23" Height="22" />
								    <asp:HyperLink runat="server" ID="hypCourseLink"></asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Literal runat="server" ID="date"></asp:Literal>
                                </td>
							</tr>
						</ItemTemplate>
					</asp:Repeater>
				</table>